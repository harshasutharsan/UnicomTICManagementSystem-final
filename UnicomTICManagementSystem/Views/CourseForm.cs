using System;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms



;

namespace UnicomTICManagementSystem.Views
{
    public partial class CourseForm : Form
    {
        public CourseForm()
        {
            InitializeComponent();
            LoadCourses();  // Load course list when form opens

        }
        // Load all courses into the DataGridView
        private void LoadCourses()
        {
            dgvCourses.DataSource = CourseController.GetAllCourses();
            dgvCourses.Columns["CourseID"].Visible = false; // hide ID column
        }

        // Add a new course
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Course name cannot be empty.");
                return;
            }

            CourseController.AddCourse(txtCourseName.Text.Trim());
            LoadCourses(); // Refresh the list
            txtCourseName.Clear();
        }

        // Update selected course
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCourses.SelectedRows[0].Cells["CourseID"].Value);
                string newName = txtCourseName.Text.Trim();
                if (string.IsNullOrEmpty(newName))
                {
                    MessageBox.Show("Enter course name.");
                    return;
                }

                CourseController.UpdateCourse(id, newName);
                LoadCourses();
            }
            else
            {
                MessageBox.Show("Please select a course to update.");
            }
        }

        // Delete selected course
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCourses.SelectedRows[0].Cells["CourseID"].Value);
                CourseController.DeleteCourse(id);
                LoadCourses();
            }
            else
            {
                MessageBox.Show("Please select a course to delete.");
            }
        }

        // Fill textbox when a row is clicked
        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCourseName.Text = dgvCourses.Rows[e.RowIndex].Cells["CourseName"].Value.ToString();
            }
        }

        private void dgvCourses_CancelRowEdit(object sender, QuestionEventArgs e)
        {

        }

        private void dgvCourses_CellClick(object sender, KeyPressEventArgs e)
        {

        }
    }
}








