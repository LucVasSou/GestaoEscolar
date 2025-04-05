using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoEscolar
{
    public partial class Mainform: Form
    {
        StudentClass student = new StudentClass();
        public Mainform()
        {
            InitializeComponent();
            customizedDesign();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            label_totalStd.Text = "Total Students: " + student.totalStudent();
        }

        private void customizedDesign()
        {
            panel_stdsubmenu.Visible = false;
            panel_courseSubmenu.Visible = false;
            panel_scoreSubmenu.Visible = false;
        }

        private void hideSubmenu()
        {
            if (panel_stdsubmenu.Visible == true)
                panel_stdsubmenu.Visible = false;
            if (panel_courseSubmenu.Visible == true)
                panel_courseSubmenu.Visible = false;
            if (panel_scoreSubmenu.Visible == true)
                panel_scoreSubmenu.Visible = false;
        }

        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        private void button_std_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_stdsubmenu);
        }
        #region studentsSubmenu 
        private void button_registration_Click(object sender, EventArgs e)
        {
            openChildForm(new RegisterForm());
            //...
            //..Your code
            //...
            hideSubmenu();
        }

        private void button_manageStd_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageStudentForm());
            //...
            //..Your code
            //...
            hideSubmenu();
        }

        private void button_status_Click(object sender, EventArgs e)
        {
            //...
            //..Your code
            //...
            hideSubmenu();
        }

        private void button_stdPrint_Click(object sender, EventArgs e)
        {
            //...
            //..Your code
            //...
            hideSubmenu();
        }
        #endregion studentsSubmenu 
        private void button_course_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_courseSubmenu);
        }
        #region courseSubmenu
        private void button_newCourse_Click(object sender, EventArgs e)
        {
            //...
            //..Your code
            //...
            hideSubmenu();
        }

        private void button_manageCourse_Click(object sender, EventArgs e)
        {
            //...
            //..Your code
            //...
            hideSubmenu();
        }

        private void button_coursePrint_Click(object sender, EventArgs e)
        {
            //...
            //..Your code
            //...
            hideSubmenu();
        }
        #endregion courseSubmenu
        private void button_score_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_scoreSubmenu);

        }
        #region scoreSubmenu
        private void button_newScore_Click(object sender, EventArgs e)
        {
            //...
            //..Your code
            //...
            hideSubmenu();
        }

        private void button_manageScore_Click(object sender, EventArgs e)
        {
            //...
            //..Your code
            //...
            hideSubmenu();
        }

        private void button_managePrint_Click(object sender, EventArgs e)
        {
            //...
            //..Your code
            //...
            hideSubmenu();
        }
        #endregion studentsSubmenu

        //to show register form in mainform
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);
            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button_dashboard_Click(object sender, EventArgs e)
        {

        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            panel_main.Controls.Add(panel_cover);
        }
    }
}
