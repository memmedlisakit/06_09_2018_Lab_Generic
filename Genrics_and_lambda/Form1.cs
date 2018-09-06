using Genrics_and_lambda.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genrics_and_lambda
{
    public partial class Form1 : Form
    {

        public GenericDataBase<Student> databse { get; set; }

        public int SelectedId { get; set; }

        public Student SelectedStudent { get; set; }

        public Form1()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnUpdate.Click += BtnUpdate_Click;
            databse = new GenericDataBase<Student>();
            cmbStudent.SelectedValueChanged += CmbStudent_SelectedValueChanged;
            
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            databse.UpdateData((Student stu) =>
            {
                if (stu.Id == SelectedId)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            },
            (Student stu) =>
            {
                stu.Name = txtName.Text;
                stu.Surname = txtSurname.Text;
                stu.Age = Convert.ToInt32(txtAge.Text);
                SelectedStudent = stu;
                return stu;
            }
            );
            FillDataGrid();
            Cleaner();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            databse.DeleteData((Student st)=> 
            {
                if(st.Id == SelectedId)
                {
                    return true; 
                }
                else
                {
                    return false;
                }
            });
            FillDataGrid(); 
        }

        private void CmbStudent_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboItem item = cmbStudent.SelectedItem as ComboItem;
            SelectedId = Convert.ToInt32(item.Value);

            SelectedStudent = databse.GetSingle((Student stu) =>
            {
                if(stu.Id == SelectedId)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });

            if(SelectedStudent != null)
            {
                txtSurname.Text = SelectedStudent.Surname;
                txtName.Text = SelectedStudent.Name;
                txtAge.Text = SelectedStudent.Age.ToString();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string surname = txtSurname.Text;
            int age = Convert.ToInt32(txtAge.Text);
            Student student = new Student
            {
                Name = name,
                Surname = surname,
                Age = age
            }; 
            databse.AddData(student);
            Cleaner();
            FillDataGrid();

        }
         
        void Cleaner()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtAge.Text = "";
        }

        void FillDataGrid()
        {
            int index = 0;
            dgvData.Rows.Clear();
            cmbStudent.Items.Clear();
            foreach (Student stu in databse.GetAllData())
            {
                dgvData.Rows.Add();
                dgvData.Rows[index].Cells[0].Value = stu.Id;
                dgvData.Rows[index].Cells[1].Value = stu.Name;
                dgvData.Rows[index].Cells[2].Value = stu.Surname;
                dgvData.Rows[index].Cells[3].Value = stu.Age;
                index++;
                cmbStudent.Items.Add(new ComboItem
                {
                    Text = stu.Name,
                    Value = stu.Id.ToString()
                });
            } 
        } 
    }
}
