using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GestaoEscolar
{
    public partial class RegisterForm: Form
    {
        StudentClass student = new StudentClass();
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            // browse photo from your computer
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo(*.jpg;*.png;*.gif) | *.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox_student.Image = Image.FromFile(opf.FileName);
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            // add new student
            string fname = textBox_Fname.Text;
            string lname = textBox_Lname.Text;
            DateTime bdate = dateTimePicker_birthdate.Value;
            string phone = textBox_phone.Text;
            string address = textBox_address.Text;
            string gender = radioButton_male.Checked ? "Male" : "Female";

            //we need to check student age between 10 and 100
            int born_year = dateTimePicker_birthdate.Value.Year;
            int this_year = DateTime.Now.Year;
            if ((this_year - born_year) < 10 || (this_year - born_year) > 100)
            {
                MessageBox.Show("The student age must be between 10 and 100", "invalid Birthdate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verify())
            {
                try
                {
                    // to get photo from picture box
                    MemoryStream ms = new MemoryStream();
                    pictureBox_student.Image.Save(ms, pictureBox_student.Image.RawFormat);
                    byte[] img = ms.ToArray();

                    if (student.isertStudent(fname, lname, bdate, gender, phone, address, img))
                    {
                        showTable();
                        MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //create a function to verify
        bool verify()
        {
            if((textBox_Fname.Text == "") || (textBox_Lname.Text == "") || (textBox_phone.Text == "") || 
               (textBox_address.Text == "") || (pictureBox_student.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_Fname.Clear();
            textBox_Lname.Clear();
            textBox_phone.Clear();
            textBox_address.Clear();
            pictureBox_student.Image = null;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            showTable();
        }

        // To show student list in Datagrid
        public void showTable()
        {
            DataGridView_student.DataSource = student.getStudentlist();
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
    }
}
