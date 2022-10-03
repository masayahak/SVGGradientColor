using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Svg;

namespace SVGGradientColor
{
    public partial class FormMain : Form
    {

        // ----------------------------------------------------------------
        // コンストラクタ
        // ----------------------------------------------------------------
        public FormMain()
        {
            InitializeComponent();
        }


        private void Form_Load(object sender, EventArgs e)
        {
            cbグラデーション方向.SelectedIndex = 0;  // 左上 → 右下
            cbOutSize.SelectedIndex = 3;             // 64px
        }

        // ----------------------------------------------------------------
        // ファイルを開く
        // ----------------------------------------------------------------
        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";

            openFileDialog.InitialDirectory = "";

            // フィルターの設定
            openFileDialog.Filter = "SVG|*.svg";
            openFileDialog.FilterIndex = 0;

            //ダイアログを表示する
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                txtFile.Text = openFileDialog.FileName;

                // アイコン描画
                LoadSVG();
            }

        }

        private void txtFile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //EnterやEscapeキーでビープ音が鳴らないようにする
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
            }
        }

        private void txtFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadSVG();
            }
        }

        private void txtFile_Leave(object sender, EventArgs e)
        {
        }

        // ----------------------------------------------------------------
        // ロード
        // ----------------------------------------------------------------
        private XDocument xDoc;

        private void btnロード_Click(object sender, EventArgs e)
        {
            ShowSVG();
        }

        private void LoadSVG()
        {
            // ファイルからSVGを読み込み
            var filePath = txtFile.Text;
            xDoc = XDocument.Load(filePath);

            // stroke チェック
            lblStroke.Visible = false;
            if (isStrokeAttrExist())
            {
                lblStroke.Visible = true;
            }

            // アイコン描画
            CreateGradiantSVG();
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
        // グラデーション方向
        // ----------------------------------------------------------------
        private void cbグラデーション方向_SelectedIndexChanged(object sender, EventArgs e)
        {
            // アイコン再描画
            CreateGradiantSVG();
        }

        // ----------------------------------------------------------------
        // 描画
        // ----------------------------------------------------------------
        private void CreateGradiantSVG()
        {
            if (xDoc == null) return;

            // サイズを変更する
            IconResize();

            // すでにグラデーションの定義がされていたら削除する
            RemoveGradientDefs();

            // グラデーションの定義を追加
            AddGradientDefs();

            // エレメント全体から<svg><g><path>を探しfill部分を書き換える
            ReplaceFill();

            ShowSVG();
        }

        // ----------------------------------------------------------------
        // 色の選択
        // ----------------------------------------------------------------
        private void pbColor1_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pbColor1.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pbColor1.BackColor = colorDialog1.Color;

                CreateGradiantSVG();
            }
        }

        private void pbColor2_Click(object sender, EventArgs e)
        {
            colorDialog2.Color = pbColor2.BackColor;
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                pbColor2.BackColor = colorDialog2.Color;

                CreateGradiantSVG();
            }
        }

        private void pbBackColor_Click(object sender, EventArgs e)
        {
            colorDialogBackColor.Color = pbBackColor.BackColor;
            if (colorDialogBackColor.ShowDialog() == DialogResult.OK)
            {
                pbBackColor.BackColor = colorDialogBackColor.Color;
                pbTestImage.BackColor = colorDialogBackColor.Color;

                CreateGradiantSVG();
            }
        }

        // ----------------------------------------------------------------
        // サイズを変更する
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

            CreateGradiantSVG();
        }


        private void IconResize()
        {
            XAttribute xStyle = xDoc.Root.Attribute("style");

            if (xStyle != null) 
            {
                // 新しいサイズ
                // style="width: 256px; height: 256px; opacity: 1;" 
                string newSize = cbOutSize.SelectedItem.ToString() + "px";
                string newStyle = string.Format("width: {0}; height: {0}; opacity: 1;", newSize);

                xStyle.Value = newStyle;
            }
            else
            {
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
        // すでにグラデーションの定義がされていたら削除する
        // ----------------------------------------------------------------
        private void RemoveGradientDefs()
        {
            // <svg><defs><linearGradient>
            XElement xlinearGradient = xDoc.Root.Element("{http://www.w3.org/2000/svg}defs")?
                                            .Element("{http://www.w3.org/2000/svg}linearGradient");
            xlinearGradient?.Remove();
        }


        // ----------------------------------------------------------------
        // グラデーションの定義
        // ----------------------------------------------------------------
        private void AddGradientDefs()
        {

            //< defs >
            //    < linearGradient id = "grad1" x1 = "0" y1 = "0" x2 = "1" y2 = "1" >
            //      < stop offset = "0%" style = "stop-color:rgb(255,255,0);stop-opacity:1" />
            //      < stop offset = "100%" style = "stop-color:rgb(255,0,0);stop-opacity:1" />
            //    </ linearGradient >
            //</ defs >

            // グラデーション方向
            var direct = GetGradientDirection();

            // グラデーションカラー
            string rgb1 = string.Format("{0}, {1}, {2}", pbColor1.BackColor.R, pbColor1.BackColor.G, pbColor1.BackColor.B);
            string rgb2 = string.Format("{0}, {1}, {2}", pbColor2.BackColor.R, pbColor2.BackColor.G, pbColor2.BackColor.B);


            // グラデーション方向
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
        // グラーデーション方向を設定
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

            var 方向 = this.cbグラデーション方向.SelectedItem;
            switch (方向)
            {
                case "Left Up to Right Down":
                    {
                        x1 = 0;
                        y1 = 0;
                        x2 = 1;
                        y2 = 1;
                        break;
                    }
                case "Right Up to Left Down":
                    {
                        x1 = 0;
                        y1 = 1;
                        x2 = 1;
                        y2 = 0;
                        break;
                    }
                case "Up to Down":
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

        // 色１と色２を交換
        private void btn色交換_Click(object sender, EventArgs e)
        {
            Color c1 = pbColor1.BackColor;
            Color c2 = pbColor2.BackColor;

            pbColor1.BackColor = c2;
            pbColor2.BackColor = c1;

            CreateGradiantSVG();
        }

        // ----------------------------------------------------------------
        // エレメント全体からfill部分を書き換える
        // ----------------------------------------------------------------
        private void ReplaceFill()
        {
            // 全てのノードで
            foreach (XObject obj in xDoc.Root.DescendantNodes())
            {
                XElement el = obj as XElement;

                if (el != null)
                {
                    // 親が linearGradient 以外 かつ 子要素を持たなければ
                    if ((!el.Parent.Name.ToString().Contains("linearGradient")) && (!el.HasElements))
                    {
                        ReplaceAttribute(el);
                    }
                }

            }
        }

        // path内を置き換える
        private void ReplaceAttribute(XElement Element)
        {
            // styleとfill属性は削除
            Element.Attributes("style").Remove();
            Element.Attributes("fill").Remove();

            // styleを改めて追加
            Element.Add(new XAttribute("style", "fill: url(#grad1);"));
        }



        // ----------------------------------------------------------------
        // SVGをイメージとして表示する
        // ----------------------------------------------------------------
        private void ShowSVG()
        {
            var tmpFilePath = txtFile.Text + ".tmp";

            try
            {
                // 一旦ファイル書き込み
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
        // 保存
        // ----------------------------------------------------------------
        private void btn保存_Click(object sender, EventArgs e)
        {
            // ファイル名のデフォルト
            saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(txtFile.Text);

            string fileName = System.IO.Path.GetFileNameWithoutExtension(txtFile.Text);
            string size = cbOutSize.Text;
            saveFileDialog.FileName = fileName + "_" + size + "px.PNG";

            // フィルターの設定
            saveFileDialog.Filter = "PNG|*.png|JPEG|*.jpeg|GIF|*.gif|SVG|*.svg";
            saveFileDialog.FilterIndex = 0;

            // ファイル保存ダイアログを表示
            saveFileDialog.ShowDialog();

        }

        private void saveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string extension = System.IO.Path.GetExtension(saveFileDialog.FileName);

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
