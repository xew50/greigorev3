using ghuschyan3rkis.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;   
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ghuschyan3rkis
{
    public partial class Form1 : Form
    {

        Model1 db = new Model1();

        public Form1()
        {
            InitializeComponent();
        }


        private void StartLoadData()
        {
            db.Roles.Load();
            db.Users.Load();
            rolesBindingSource.DataSource = db.Roles.Local.ToBindingList();
            usersBindingSource.DataSource = db.Users.Local.ToBindingList();
        }

   
        private void SaveData()
        {
            try
            {
                this.Validate();

                usersBindingSource.EndEdit();
                rolesBindingSource.EndEdit();

                db.SaveChanges();

                MessageBox.Show("Данные успешно сохранены!",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            StartLoadData();
        }


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (role_NameComboBox.Items.Count > 0)
            {
                role_NameComboBox.SelectedIndex = 0;
            }
        }

 
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}
