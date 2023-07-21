using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuizApp
{
    public partial class Form1 : Form
    {

        private List<Question> questions;
        private int currentQuestionIndex;
        private int score;

        public Form1()
        {
            InitializeComponent();
            InitializeQuiz();
        }

        private void InitializeQuiz()
        {
            // Initialize the list of questions
            questions = new List<Question>()
            
            {
                new Question("Which anime is the power system Haki used?", new List<string>{"Demon Slayer", "Dr. Stone", "Jujutsu Kaisen", "One Piece"}, 0),
                new Question("How many court guards are there in Bleach?", new List<string>{"4", "13, 45", "0"}, 0),
                new Question("What is the name of Luffy's father?", new List<string>{"Ishigami Senku", "Monkey D. Dragon", "Gojo", "Sasuke"}, 0)
            };
            currentQuestionIndex = 0;
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (currentQuestionIndex < questions.Count)
            {
                Question currentQuestion = questions[currentQuestionIndex];
                lblQuestion.Text = currentQuestion.Text;
                radioButton1.Text = currentQuestion.Options[0];
                radioButton2.Text = currentQuestion.Options[1];
                radioButton3.Text = currentQuestion.Options[2];
                radioButton4.Text = currentQuestion.Options[3];

                // Clear selection
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }
            else
            {
                // Quiz is over, show the score
                lblQuestion.Text = "Quiz Over!";
                MessageBox.Show($"Your Score: {score}/{questions.Count}");


            }
        }


            private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (currentQuestionIndex < questions.Count)
                {
                    if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked)
                    {
                        int selectedOptionIndex = GetSelectedOptionIndex();

                        if (selectedOptionIndex == questions[currentQuestionIndex].CorrectOptionIndex)
                        {
                            score++;
                        }

                        currentQuestionIndex++;
                    }
                    else
                    {
                        MessageBox.Show("Please select an option!");
                    }
                }
            }

             int GetSelectedOptionIndex()
            {
                if (radioButton1.Checked)
                    return 0;
                else if (radioButton2.Checked)
                    return 1;
                else if (radioButton3.Checked)
                    return 2;
                else if (radioButton4.Checked)
                    return 3;
                else
                    return -1;
            }
        }

        public class Question
        {
            public string Text { get; set; }
            public List<string> Options { get; set; }
            public int CorrectOptionIndex { get; set; }

            public Question(string text, List<string> options, int correctOptionIndex)
            {
                Text = text;
                Options = options;
                CorrectOptionIndex = correctOptionIndex;
            }
        }

       
            }
        }
    


