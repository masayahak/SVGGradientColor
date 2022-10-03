using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Svg;

namespace SVGGradientColor
{
    public partial class FormMain : Form
    {

        // ----------------------------------------------------------------
        // Constructor
        // ----------------------------------------------------------------
        public FormMain()
        {
            InitializeComponent();
        }


        private void Form_Load(object sender, EventArgs e)
        {
            cbDirection.SelectedIndex = 0;           // Left Top to Right Bottom
            cbOutSize.SelectedIndex = 3;             // 64px
        }

        // ----------------------------------------------------------------
        // File Open
        // ----------------------------------------------------------------
        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.InitialDirectory = "";

            openFileDialog.Filter = "SVG|*.svg";
            openFileDialog.FilterIndex = 0;

            // Dialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog.FileName;

                // Draw SVG
                DrawSVG();
            }

        }

        private void txtFile_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Beep Off
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
            }
        }

        private void txtFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DrawSVG();
            }
        }

        private void txtFile_Leave(object sender, EventArgs e)
        {
        }

        // ----------------------------------------------------------------
        // ロード
        // ----------------------------------------------------------------
        private XDocument xDoc;

        private void btnLoad_Click(object sender, EventArgs e)
        {
            ShowSVG();
        }

        private void DrawSVG()
        {
            var filePath = txtFile.Text;
            xDoc = XDocument.Load(filePath);

            // check stroke attribute
            lblStroke.Visible = false;
            if (isStrokeAttrExist())
            {
                lblStroke.Visible = true;
            }

            // Draw With Params
            DrawSVGWithParams();
        }

        private bool isStrokeAttrExist()
        {
            if (xDoc.Root.Attributes("stroke").Count() > 0)
            {
                return true;
            }

            return false;
        }

        // ----------------------------------------------------------------
        // Direction
        // ----------------------------------------------------------------
        private void cbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawSVGWithParams();
        }

        // ----------------------------------------------------------------
        // Draw SVG with Params in Display
        // ----------------------------------------------------------------
        private void DrawSVGWithParams()
        {
            if (xDoc == null) return;

            IconResize();
            RemoveGradientDefs();
            AddGradientDefs();
            ReplaceFill();

            ShowSVG();
        }

        // ----------------------------------------------------------------
        // Select Color
        // ----------------------------------------------------------------
        private void pbColor1_DoubleClick(object sender, EventArgs e)
        {
            colorDialog1.Color = pbColor1.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pbColor1.BackColor = colorDialog1.Color;
                DrawSVGWithParams();
            }
        }

        private void pbColor2_DoubleClick(object sender, EventArgs e)
        {
            colorDialog2.Color = pbColor2.BackColor;
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                pbColor2.BackColor = colorDialog2.Color;
                DrawSVGWithParams();
            }
        }

        private void pbBackColor_DoubleClick(object sender, EventArgs e)
        {
            colorDialogBackColor.Color = pbBackColor.BackColor;
            if (colorDialogBackColor.ShowDialog() == DialogResult.OK)
            {
                pbBackColor.BackColor = colorDialogBackColor.Color;
                pbTestImage.BackColor = colorDialogBackColor.Color;

                DrawSVGWithParams();
            }
        }

        // Switch
        private void btnSwitchColor_Click(object sender, EventArgs e)
        {
            Color c1 = pbColor1.BackColor;
            Color c2 = pbColor2.BackColor;

            pbColor1.BackColor = c2;
            pbColor2.BackColor = c1;

            DrawSVGWithParams();
        }

        // ----------------------------------------------------------------
        // Resize
        // ----------------------------------------------------------------
        private void cbOutSize_SelectedIndexChanged(object sender, EventArgs e)
        {

            string mySize = cbOutSize.SelectedItem.ToString();
            int iSize = int.Parse(mySize);

            pbTestImage.Width = iSize;
            pbTestImage.Height = iSize;

            int backWidth = panelImageBack.Width;
            int imageWidth = iSize;

            int locationX = backWidth/2 - imageWidth/2;

            pbTestImage.Location = new Point(locationX, locationX);

            DrawSVGWithParams();
        }


        private void IconResize()
        {
            XAttribute xStyle = xDoc.Root.Attribute("style");

            if (xStyle != null) 
            {
                // when style in Root

                // style="width: 256px; height: 256px; opacity: 1;" 
                string newSize = cbOutSize.SelectedItem.ToString() + "px";
                string newStyle = string.Format("width: {0}; height: {0}; opacity: 1;", newSize);

                xStyle.Value = newStyle;
            }
            else
            {
                // when style not in Root

                XAttribute xWidth = xDoc.Root.Attribute("width");
                if (xWidth != null)
                {
                    xWidth.Value = cbOutSize.SelectedItem.ToString();
                }
                else
                {
                    xDoc.Root.Add(new XAttribute("width", cbOutSize.SelectedItem.ToString()));
                }

                XAttribute xHeight = xDoc.Root.Attribute("height");
                if (xHeight != null)
                {
                    xHeight.Value = cbOutSize.SelectedItem.ToString();
                }
                else
                {
                    xDoc.Root.Add(new XAttribute("height", cbOutSize.SelectedItem.ToString()));
                }

            }

        }


        // ----------------------------------------------------------------
        // Remove <defs><linearGradient>
        // ----------------------------------------------------------------
        private void RemoveGradientDefs()
        {
            // <svg><defs><linearGradient>
            XElement xlinearGradient = xDoc.Root.Element("{http://www.w3.org/2000/svg}defs")?
                                            .Element("{http://www.w3.org/2000/svg}linearGradient");
            xlinearGradient?.Remove();
        }


        // ----------------------------------------------------------------
        // Add <defs><linearGradient>
        // ----------------------------------------------------------------
        private void AddGradientDefs()
        {

            //< defs >
            //    < linearGradient id = "grad1" x1 = "0" y1 = "0" x2 = "1" y2 = "1" >
            //      < stop offset = "0%" style = "stop-color:rgb(255,255,0);stop-opacity:1" />
            //      < stop offset = "100%" style = "stop-color:rgb(255,0,0);stop-opacity:1" />
            //    </ linearGradient >
            //</ defs >

            // Direction
            var direct = GetGradientDirection();

            // Color
            string rgb1 = string.Format("{0}, {1}, {2}", pbColor1.BackColor.R, pbColor1.BackColor.G, pbColor1.BackColor.B);
            string rgb2 = string.Format("{0}, {1}, {2}", pbColor2.BackColor.R, pbColor2.BackColor.G, pbColor2.BackColor.B);


            // XElement
            XElement linearGradient = 
                new XElement("{http://www.w3.org/2000/svg}defs",
                    new XElement("{http://www.w3.org/2000/svg}linearGradient",
                        new XAttribute("id", "grad1"),
                        new XAttribute("x1", direct.x1),
                        new XAttribute("y1", direct.y1),
                        new XAttribute("x2", direct.x2),
                        new XAttribute("y2", direct.y2),
                        // カラー1⃣
                        new XElement("{http://www.w3.org/2000/svg}stop",
                                new XAttribute("offset", "0%"),
                                new XAttribute("style", "stop-color:rgb(" + rgb1 + ");stop-opacity:1")
                        ),
                        // カラー2⃣
                        new XElement("{http://www.w3.org/2000/svg}stop",
                                new XAttribute("offset", "100%"),
                                new XAttribute("style", "stop-color:rgb(" + rgb2 + ");stop-opacity:1")
                        )
                    )
                );

            xDoc.Root.AddFirst(linearGradient);

        }

        // -----------------------------------
        // Direction
        // -----------------------------------
        class GradientDirection
        {
            public int x1 = 0;
            public int y1 = 0;
            public int x2 = 0;
            public int y2 = 0;
        }

        private GradientDirection GetGradientDirection()
        {
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;

            var 方向 = this.cbDirection.SelectedItem;
            switch (方向)
            {
                case "Left Top to Right Bottom":
                    {
                        x1 = 0;
                        y1 = 0;
                        x2 = 1;
                        y2 = 1;
                        break;
                    }
                case "Right Top to Left Bottom":
                    {
                        x1 = 0;
                        y1 = 1;
                        x2 = 1;
                        y2 = 0;
                        break;
                    }
                case "Top to Bottom":
                    {
                        x1 = 0;
                        y1 = 0;
                        x2 = 0;
                        y2 = 1;
                        break;
                    }
                case "Left to Right":
                    {
                        x1 = 0;
                        y1 = 0;
                        x2 = 1;
                        y2 = 0;
                        break;
                    }
            }

            var direct = new GradientDirection()
            {
                x1 = x1,
                y1 = y1,
                x2 = x2,
                y2 = y2
            };

            return direct;

        }

        // ----------------------------------------------------------------
        // Replace Fill
        // ----------------------------------------------------------------
        private void ReplaceFill()
        {
            // in all nodes
            foreach (XObject obj in xDoc.Root.DescendantNodes())
            {
                XElement el = obj as XElement;

                if (el != null)
                {
                    // parent is not linearGradient
                    // no child element

                    if ((!el.Parent.Name.ToString().Contains("linearGradient"))
                        && (!el.HasElements))
                    {
                        ReplaceAttribute(el);
                    }
                }

            }
        }

        // style, fill -> style
        private void ReplaceAttribute(XElement Element)
        {
            Element.Attributes("style").Remove();
            Element.Attributes("fill").Remove();

            Element.Add(new XAttribute("style", "fill: url(#grad1);"));
        }



        // ----------------------------------------------------------------
        // Show SVG Image
        // ----------------------------------------------------------------
        private void ShowSVG()
        {
            var tmpFilePath = txtFile.Text + ".tmp";

            try
            {
                // SvgDocument.Open(XDocument) not working
                xDoc.Save(tmpFilePath);

                var svgDoc = SvgDocument.Open(tmpFilePath);
                pbTestImage.BackColor = pbBackColor.BackColor;
                pbTestImage.Image = svgDoc.Draw();
            }
            finally
            {
                try
                {
                    File.Delete(tmpFilePath);
                }
                catch { }
            }

        }

        // ----------------------------------------------------------------
        // Save
        // ----------------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(txtFile.Text);

            string fileName = Path.GetFileNameWithoutExtension(txtFile.Text);
            string size = cbOutSize.Text;
            saveFileDialog.FileName = fileName + "_" + size + "px.PNG";

            // Filter
            saveFileDialog.Filter = "PNG|*.png|JPEG|*.jpeg|GIF|*.gif|SVG|*.svg";
            saveFileDialog.FilterIndex = 0;

            saveFileDialog.ShowDialog();

        }

        private void saveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string extension = Path.GetExtension(saveFileDialog.FileName);

            switch (extension.ToUpper())
            {
                case ".PNG":
                    pbTestImage.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    break;
                case ".JPEG":
                    pbTestImage.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;
                case ".GIF":
                    pbTestImage.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                    break;
                case ".SVG":
                    xDoc.Save(saveFileDialog.FileName);
                    break;
            }
        }


    }
}
