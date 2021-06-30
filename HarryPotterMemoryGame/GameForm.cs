using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HarryPotterMemoryGame
{
    public partial class GameForm : Form
    {
        public List<String> ImageFileStrings { get; set; }
        public List<PictureBox> Images { get; set; }
        public List<PictureBox> QuestionMarks { get; set; }
        public int Score { get; set; }
        public PictureBox ClickedPic { get; set; }
        public PictureBox[,] PictureGrid { get; set; }
        public PictureBox[,] QuestionGrid {get;set;}
        public string[,] PicStrings { get; set; }
        public int Rows { get; set; } = 4;
        public int Columns { get; set; } = 4;

        int index = 0;

        Random rand;
        private bool frontLayerMade;

        public GameForm()
        {
            InitializeComponent();
            InitializeGameObjects();

          
        }

        public void InitializeGameObjects()
        {
            rand = new Random(Guid.NewGuid().GetHashCode());

            QuestionGrid = new PictureBox[Rows, Columns];

            QuestionMarks = new List<PictureBox>() {pictureBox1q, pictureBox2q,
                pictureBox3q, pictureBox4q, pictureBox5q, pictureBox6q,
                pictureBox7q, pictureBox8q, pictureBox9q, pictureBox10q,
                pictureBox11q, pictureBox12q, pictureBox13q, pictureBox14q,
                 pictureBox15q, pictureBox16q };

            foreach (PictureBox question in QuestionMarks)
            {
                question.MouseClick += new MouseEventHandler(Question_MouseClick);
            }

            PictureGrid = new PictureBox[Rows, Columns];

            PicStrings = new string[Rows, Columns];

            Images = new List<PictureBox>() {pictureBox1, pictureBox2,
                pictureBox3, pictureBox4, pictureBox5, pictureBox6,
                pictureBox7, pictureBox8, pictureBox9, pictureBox10,
                pictureBox11, pictureBox12, pictureBox13, pictureBox14,
                 pictureBox15, pictureBox16};

            foreach (PictureBox pics in Images)
            {
                pics.MouseClick += new MouseEventHandler(Image_MouseClick);
            }

            ImageFileStrings = new List<string>() {"harry", "harry2", "ron", "ron2", "hermione", "hermione2", "snape", "snape2",
             "draco", "draco2", "hagrid", "hagrid2", "dumble", "dumble2", "mgoni", "mgoni2" };

            ImageFileStrings = ImageFileStrings.OrderBy(x => rand.Next()).ToList();
        }

        public void PopulatePictureGrid(List<PictureBox> picBoxlist, PictureBox[,] grid, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {

                    grid[i, j] = picBoxlist[index];
                    index++;
                    grid[i, j].Image = (Image)Properties.Resources.ResourceManager.GetObject("question");

                    frontLayerMade = true;
                    
                    if (frontLayerMade)
                    {
                        grid[i, j] = picBoxlist[index];
                        index++;
                        grid[i, j].Image = (Image)Properties.Resources.ResourceManager.GetObject(ImageFileStrings.ElementAt(index));
                    }
                }
            }
        }

        public void Image_MouseClick(Object sender, MouseEventArgs e)
        {
         
            ClickedPic = (PictureBox)sender;

            
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (PictureGrid[i, j].Equals(ClickedPic))
                    {
                        QuestionGrid[i, j].Visible = true;
                    }
                }
            }
        }


        public void Question_MouseClick(Object sender, MouseEventArgs e)
        {
            PictureBox questionClicked = (PictureBox)sender;

            questionClicked.Visible = false;
        }
 
    }
}
