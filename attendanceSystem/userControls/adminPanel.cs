using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace attendanceSystem.userControls
{
    public partial class adminPanel : UserControl
    {
        int usersPerPage = 7;
        int currentPage = 0;
        List<User> users = new List<User>();
        public adminPanel()
        {
            InitializeComponent();

        }

        private void usersGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var columnName = usersGridView.Columns[e.ColumnIndex].Name;
                var clickedUserId = usersGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                var clickedUserName = usersGridView.Rows[e.RowIndex].Cells[1].Value.ToString();

                //Console.WriteLine(columnName, clickedUserName, clickedUserId);

                if (columnName == "deleteBtn")
                {
                    DialogResult d = MessageBox.Show($"delete user: {clickedUserName} with id: {clickedUserId}", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        try
                        {
                            DataManager.deleteUserById(clickedUserId);
                            usersGridView.Rows.RemoveAt(e.RowIndex);
                            MessageBox.Show("Removed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        
                    }
                }

                else if (columnName == "editBtn")
                {
                    // edit user
                }
            }
        }

        private void adminPanel_Load(object sender, EventArgs e)
        {

            string usersXml = DataManager.getUsers();
            displayUsersInTheGrid(deserilizaedUsers(usersXml).GetRange(currentPage * usersPerPage, usersPerPage));
        }

        private void searchByNameBox_TextChanged(object sender, EventArgs e)
        {
            currentPage = 0;
            displayUsersInCurrentPage();
        }

        private List<User> deserilizaedUsers(string usersXml)
        {
            users.Clear();
            XmlDocument usersDoc = new XmlDocument();

            usersDoc.LoadXml(usersXml);

            foreach (XmlNode u in usersDoc.SelectNodes("//user"))
            {
                var role = u.SelectSingleNode("Role").InnerText;

                if (role == "Student")
                {
                    Student studentt = FormatsConverter.Deserialize<Student>(u.InnerXml, "Student");
                    users.Add(studentt);
                }
                else if (role == "Teacher")
                {
                    Teacher teachert = FormatsConverter.Deserialize<Teacher>(u.InnerXml, "Teacher");
                    users.Add(teachert);
                }
            }
            return users;
        }

        private void displayUsersInTheGrid(List<User> users)
        {
            usersGridView.Rows.Clear();

            foreach (var user in users)
            {
                if (user.Role != "Admin")
                    usersGridView.Rows.Add(user.Id, user.Name, user.Email, user.Role);
            }
            //usersGridView.AutoResizeColumns();
        }

        private void nxtPgaeBtn_Click(object sender, EventArgs e)
        {
            if(currentPage+1 >= getPagesCount())
                return;

            currentPage++;
            displayUsersInCurrentPage();
        }

        private void prvPageBtn_Click(object sender, EventArgs e)
        {
            if (currentPage - 1 == -1)
                return;
            currentPage--;
            displayUsersInCurrentPage();
        }

        private int getPagesCount()
        {
            int pagesCount = users.Count / usersPerPage;
            pagesCount += (users.Count % usersPerPage == 0 ? 0 : 1);

            return pagesCount;
        }

        private void displayUsersInCurrentPage()
        {
      
            string newText = searchByNameBox.Text;
            //Console.WriteLine("Text changed: " + newText);
            string searchResultUsers = DataManager.getUsersByName(newText);
            Console.WriteLine((searchResultUsers));
            Console.WriteLine("============= deserialized users =============");
            foreach (User u in deserilizaedUsers(searchResultUsers))
            {
                Console.WriteLine(u);
            }
            int startIndex = currentPage * usersPerPage;
            users = deserilizaedUsers(searchResultUsers);
            //Console.WriteLine(users.Count);
            int itemsCount = users.Count;

            int remainingItems = itemsCount - startIndex;

            if (remainingItems == 0)
            {
                usersGridView.Rows.Clear();
                return;
            }
                

            int count = Math.Min(usersPerPage, remainingItems);

            displayUsersInTheGrid(deserilizaedUsers(searchResultUsers).GetRange(startIndex, count));
        }
    }
}
