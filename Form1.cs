//*****************************************************************************//
//**                                                                       ****//
//**               Name   : Taha Dervişoğlu                                ****//
//**               Number : B221202066                                     ****//
//**                                                                       ****//
//*****************************************************************************//
using System;
using System.Drawing;
using System.Windows.Forms;
using Version_0._3;

namespace Version_0._3
{
    public partial class Form1 : Form
    {
        private Polygon polygon;

        public Form1()
        {
            InitializeComponent();
            polygon = new Polygon();
            UpdatePolygon();
        }

        private void UpdatePolygon()
        {
            // Update center point
            Point2D center = polygon.Center;
            textBox1.Text = center.X.ToString();
            textBox2.Text = center.Y.ToString();

            // Update length and number of edges
            textBox3.Text = polygon.Length.ToString();
            textBox4.Text = polygon.NumberOfEdges.ToString();

            // Calculate and display edge coordinates
            listBox1.Items.Clear();
            foreach (Point2D vertex in polygon.Vertices)
            {
                listBox1.Items.Add(vertex.ToString());
            }

            
        }

        private void DrawPolygon()  //Bu kısmı  tamamen kendim yapamadım. Yapay zeka yardımıyla yaptım. Picturebox kullanımını öğrenemedim.
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height); // genişiliği alarak yeni bir bitmap oluşturuyor.
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);              // renk ayarları yapılıyor.
                Pen pen = new Pen(Color.Black);

                float scaleFactor = Math.Min((float)pictureBox1.Width / 30,(float)pictureBox1.Height / 30);   // Ölçeklendirme ayarları.
                int offsetX = pictureBox1.Width / 2;
                int offsetY = pictureBox1.Height / 2;

                for (int i = 0; i < polygon.Vertices.Count - 1; i++)
                {
                    int x1 = (int)(scaleFactor * polygon.Vertices[i].X) + offsetX;              //Kenarları çizdiriyor.
                    int y1 = (int)(scaleFactor * polygon.Vertices[i].Y) + offsetY;
                    int x2 = (int)(scaleFactor * polygon.Vertices[i + 1].X) + offsetX;
                    int y2 = (int)(scaleFactor * polygon.Vertices[i + 1].Y) + offsetY;
                    g.DrawLine(pen, x1, y1, x2, y2);
                }

                int lastX = (int)(scaleFactor * polygon.Vertices[polygon.Vertices.Count - 1].X) + offsetX;  //Son köşe noktası ile ilk köşe noktasını birbirine bağlıyor.
                int lastY = (int)(scaleFactor * polygon.Vertices[polygon.Vertices.Count - 1].Y) + offsetY;
                int firstX = (int)(scaleFactor * polygon.Vertices[0].X) + offsetX;
                int firstY = (int)(scaleFactor * polygon.Vertices[0].Y) + offsetY;
                g.DrawLine(pen, lastX, lastY, firstX, firstY);
            }

            pictureBox1.Image = bmp;    //Bmp yi pixtureboxxda görütülnemesi için koyuyoruz.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            polygon = new Polygon(); // Rastgele bir Polygon oluştur.
            textBox5.Text = new Random().Next(0, 360).ToString(); // Rastgele bir açı değeri oluştur ve textBox5'e yaz.
            UpdatePolygon();     // textboxlara random değerleri yaz.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double rotationAngle;
            if (double.TryParse(textBox5.Text, out rotationAngle))
            {
                polygon.RotatePolygon(rotationAngle); //hesaplama kısmına göderiyor.
                UpdatePolygon(); //Yeni listbox değerleri için tekrardan update atıyoruz.
                DrawPolygon();   //Çizdiriyoruz.
            }
            else
            {
                MessageBox.Show("Geçerli bir açı değeri girin."); //Hata mesajı için.

            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
                double centerX = double.Parse(textBox1.Text);  //Değerleri textboxlardan çekiyoruz.
                double centerY = double.Parse(textBox2.Text);
                int length = int.Parse(textBox3.Text);
                int numberOfEdges = int.Parse(textBox4.Text);

                polygon = new Polygon(new Point2D(centerX, centerY), length) //Yeni polygon değeri oluşturuyoruz.
                {
                    NumberOfEdges = numberOfEdges
                };
                polygon.Vertices = polygon.CalculateEdgeCoordinates();
                UpdatePolygon();            //Tekrardan yeniliyoruz.

            DrawPolygon(); // çizdiriyoruz.
        }

        private void randomizeButton_Click(object sender, EventArgs e) //Yanlışlıkla tıkladım kapanmadı.
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e) //Yanlışlıkla tıkladım kapanmadı.
        {
           
        }
        private void textBox1_TextChanged(object sender, EventArgs e)  //Yanlışlıkla tıkladım kapanmadı.
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) //Yanlışlıkla tıkladım kapanmadı.
        {

        }
    }
}
