using MediaBazaar.Forms;
using static System.Windows.Forms.Control;

namespace MediaBazaar.Design
{
    internal class DesignClass
    {

        public static void AutoDesginerForForms(ControlCollection controls, Form? form)
        {

            List<Button> buttons = new List<Button>();
            //Adding form buttons
            foreach (Control control in controls)
            {
                if (control is Button button)
                {
                    buttons.Add(button);
                }
            }

            //it is geting the icons from Administration form
            System.ComponentModel.ComponentResourceManager administrationResources = new System.ComponentModel.ComponentResourceManager(typeof(Administration));
            form.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            form.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(106)))), ((int)(((byte)(123)))));
            form.MaximizeBox = false;
            form.MdiChildrenMinimizedAnchorBottom = false;
            form.MinimizeBox = false;
            form.ShowInTaskbar = false;
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            form.Icon = ((System.Drawing.Icon)(administrationResources.GetObject("$this.Icon")));

            foreach (Control control in controls)
            {
                if (form != null)
                {
                    String[] parentForms = new String[] { "Administration", "HumanResources", "Logistics", "Management", "Sales" };
                    String[] authorizationForms = new String[] { "DepartmentChoice", "Login" };
                    String[] childForms = new String[] { "CreateReshelveRequest", "RegisterBrokenReshelve", "ReshelveRequestInfo", "EmployeeInfo", "AddContract","Settings", "AutoScheduling" };


                    if (parentForms.Contains(form.Name))
                    {

                        setControlButtons();


                        form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;


                        if (control is TabControl tabControl)
                        {
                            foreach (Control tabControlChildControl in tabControl.Controls)
                            {
                                if (tabControlChildControl is TabPage tabPage)
                                {
                                    //Adding icons of the tabs
                                    if (tabPage.Name == "tpageHome")
                                    {
                                        tabPage.ImageKey = "Home icon.png";
                                    }
                                    if (tabPage.Name == "tpageEmployees")
                                    {
                                        tabPage.ImageKey = "Employees.png";
                                    }
                                    if (tabPage.Name == "tpageSchedule")
                                    {
                                        tabPage.ImageKey = "schedule.png";
                                    }
                                    if (tabPage.Name == "tpageProducts")
                                    {
                                        tabPage.ImageKey = "Products.png";
                                    }
                                    if (tabPage.Name == "tPageReshelveRequests")
                                    {
                                        tabPage.ImageKey = "Reshelve Requests.png";
                                    }
                                    if (tabPage.Name == "tabReshelve")
                                    {
                                        tabPage.ImageKey = "Reshelve Requests.png";
                                    }

                                    tabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
                                    tabPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);

                                    foreach (Control control1 in tabPage.Controls)
                                    {
                                        if (control1 is Button button)
                                        {
                                            if (button.Name == "btnAddEmployee")
                                            {
                                                button.Image = ((System.Drawing.Image)(administrationResources.GetObject("btnAddEmployee.Image")));
                                                button.Text = String.Empty;
                                            }

                                            if (button.Name != "btnCreateRequest")
                                            {
                                                button.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                                                button.BackColor = System.Drawing.Color.White;
                                                button.FlatAppearance.BorderColor = System.Drawing.Color.White;
                                                button.FlatAppearance.BorderSize = 0;
                                            }


                                            if (button.Width == 86 && button.Height == 31)
                                            {
                                                button.Font = new System.Drawing.Font("Segoe UI Semibold", 9, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                    else if (authorizationForms.Contains(form.Name))
                    {
                        form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    }
                    else if (childForms.Contains(form.Name))
                    {
                        form.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                    }
                    if (control is Label label)
                    {
                        if (label.Text.Contains("⮬"))
                        {
                            label.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
                        }
                        else if (label.Name == "lbNotificationsCount")
                        {
                            label.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                        }
                        else if (form.BackColor == System.Drawing.Color.FromArgb((int)(byte)84, (int)(byte)106, (int)(byte)123))
                        {
                            label.ForeColor = Color.White;
                        }
                        else
                        {
                            label.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                        }
                    }
                    else if (control is Button button)
                    {
                        if (button.Size.Width > 180)
                        {

                            if (button.Text.Length < 8)
                            {
                                button.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                            }

                            button.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                        }
                        else if (button.Size.Width > 129 && button.Size.Height <= 33)
                        {
                            button.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                        }
                        else
                        {
                            button.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                        }


                        button.BackColor = System.Drawing.Color.White;
                        button.FlatAppearance.BorderColor = System.Drawing.Color.White;
                        button.FlatAppearance.BorderSize = 0;

                        //Adding log out icon to add log out buttons in forms
                        if (button.Name == "btLogOut")
                        {
                            button.Text = String.Empty;
                            button.Image = ((System.Drawing.Image)(administrationResources.GetObject("btLogOut.Image")));
                        }
                        if (button.Name == "btnChangeView")
                        {
                            button.Image = ((System.Drawing.Image)(administrationResources.GetObject("btnChangeView.Image")));
                            button.Text = String.Empty;
                        }
                        if (button.Name == "btnShowNotifcations")
                        {
                            button.Image = ((System.Drawing.Image)(administrationResources.GetObject("btnShowNotifcations.Image")));
                            button.Text = String.Empty;
                        }

                    }
                    else if (control is ListBox listBox)
                    {
                        listBox.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    }
                    else if (control is TextBox textBox)
                    {
                        if (!textBox.Enabled)
                        {
                            textBox.Font = new System.Drawing.Font("Segoe UI Variable Small", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                        }
                        else
                        {
                            textBox.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        }

                    }
                }
                else if (control is DataGridView dataGridView)
                {
                    dataGridView.AllowUserToAddRows = false;
                    dataGridView.AllowUserToDeleteRows = false;
                    dataGridView.AllowUserToResizeColumns = false;
                    dataGridView.AllowUserToResizeRows = false;
                    dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;

                    dataGridView.BorderStyle = BorderStyle.None;
                    dataGridView.DefaultCellStyle.Font = new Font("Segoe UI Semilight", 9, GraphicsUnit.Point);
                    dataGridView.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#62929E");
                    dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView.EnableHeadersVisualStyles = false;

                    dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#B6C3CD");
                    dataGridView.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#CFD7DE");
                    dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
                    dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
                }
            }

           


            //This method to reorganize the controls buttons based if they are visible or not
            void setControlButtons()
            {
                if (!IsVisible("btnChangeView") && !IsVisible("btnShowNotifcations"))
                {
                    btnChangesViewIsNotVisiableAndbtnChangesViewIsNotVisiable();
                }
                else if (!IsVisible("btnChangeView"))
                {
                    btnChangesViewIsNotVisiable();
                }
                else if (!IsVisible("btnShowNotifcations"))
                {
                    btnShowNotifcationsIsNotVisiable();
                }
                else
                    allButtonsAreVisisble();

                void btnChangesViewIsNotVisiable()
                {
                    foreach (Button button in buttons)
                    {
                        switch (button.Name)
                        {
                            case "btLogOut":
                                button.Location = new System.Drawing.Point(1220, 8);
                                break;
                            case "btnShowNotifcations":
                                button.Location = new System.Drawing.Point(1180, 8);
                                controls["ucNotifications"].Location = new System.Drawing.Point(952, 16);
                                controls["lbNotificationsCount"].Location = new System.Drawing.Point(1212, 8);
                                break;
                            case "btAnnouncement":
                                button.Location = new System.Drawing.Point(1078, 8);
                                break;
                            case "buttonSettings":
                                button.Location = new System.Drawing.Point(1134, 8);
                                break;
                        }
                    }
                }
                void btnShowNotifcationsIsNotVisiable()
                {
                    foreach (Button button in buttons)
                    {
                        switch (button.Name)
                        {
                            case "btLogOut":
                                button.Location = new System.Drawing.Point(1220, 8);
                                break;
                            case "btnShowNotifcations":
                                button.Location = new System.Drawing.Point(1137, 8);
                                controls["ucNotifications"].Location = new System.Drawing.Point(896, 16);
                                controls["lbNotificationsCount"].Location = new System.Drawing.Point(1256, 8);
                                break;
                            case "buttonSettings":
                                button.Location = new System.Drawing.Point(1177, 8);
                                break;
                            case "btAnnouncement":
                                button.Location = new System.Drawing.Point(992, 8);
                                break;
                            case "btnChangeView":
                                button.Location = new System.Drawing.Point(1050, 8);
                                break;

                        }
                    }
                }
                void btnChangesViewIsNotVisiableAndbtnChangesViewIsNotVisiable()
                {
                    foreach (Button button in buttons)
                    {
                        switch (button.Name)
                        {
                            case "btAnnouncement":
                                button.Location = new System.Drawing.Point(1116, 8);
                                break;
                            case "btLogOut":
                                button.Location = new System.Drawing.Point(1220, 8);
                                break;
                            case "buttonSettings":
                                button.Location = new System.Drawing.Point(1175, 8);
                                break;
                        }
                    }
                }
                void allButtonsAreVisisble()
                {
                    foreach (Button button in buttons)
                    {
                        switch (button.Name)
                        {
                            case "btLogOut":
                                button.Location = new System.Drawing.Point(1220, 8);
                                break;
                            case "btnShowNotifcations":
                                button.Location = new System.Drawing.Point(1137, 8);
                                controls["ucNotifications"].Location = new System.Drawing.Point(896, 16);
                                controls["lbNotificationsCount"].Location = new System.Drawing.Point(1256, 8);
                                break;
                            case "buttonSettings":
                                button.Location = new System.Drawing.Point(1177, 8);
                                break;
                            case "btAnnouncement":
                                button.Location = new System.Drawing.Point(950, 8);
                                break;
                            case "btnChangeView":
                                button.Location = new System.Drawing.Point(1008, 8);
                                break;
                        }
                    }
                }
                bool IsVisible(string buttonName)
                {
                    foreach (Button button in buttons)
                    {
                        if (button.Name == buttonName && button.Visible  == true)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
        }



        public static void AutoDesginerForUserControl(ControlCollection controls, UserControl? userControl)
        {
            foreach (Control control in controls)
            {
                if (userControl != null)
                {
                    userControl.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
                    userControl.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                    userControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
                }

                if (control is Label label)
                {
                    if (label.Text.Contains("⮬"))
                    {
                        label.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
                    }
                    else if (userControl.BackColor == System.Drawing.Color.FromArgb((int)(byte)84, (int)(byte)106, (int)(byte)123))
                    {
                        label.ForeColor = Color.White;
                    }
                    else
                    {
                        label.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                    }
                }
                else if (control is TextBox textBox)
                {
                    textBox.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = System.Drawing.Color.White;
                    comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                    comboBox.Font = new System.Drawing.Font("Segoe UI Semilight", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    comboBox.FormattingEnabled = true;
                }
                else if (control is ListBox listBox)
                {
                    listBox.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                }
                else if (control is Button button)
                {
                    if (button.Name != "buttonInactive")
                    {
                        if (button.Size.Width > 180)
                        {
                            button.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                        }
                        else if (button.Size.Width > 129 && button.Size.Height <= 33)
                        {
                            button.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                        }
                        else
                        {
                            button.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                        }
                        button.BackColor = System.Drawing.Color.White;
                        button.FlatAppearance.BorderColor = System.Drawing.Color.White;
                        button.FlatAppearance.BorderSize = 0;
                    }
                }
                else if (control is DataGridView dataGridView)
                {
                    dataGridView.AllowUserToAddRows = false;
                    dataGridView.AllowUserToDeleteRows = false;
                    dataGridView.AllowUserToResizeColumns = false;
                    dataGridView.AllowUserToResizeRows = false;
                    dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;

                    dataGridView.BorderStyle = BorderStyle.None;
                    dataGridView.DefaultCellStyle.Font = new Font("Segoe UI Semilight", 9, GraphicsUnit.Point);
                    dataGridView.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#62929E");
                    dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView.EnableHeadersVisualStyles = false;

                    dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#B6C3CD");
                    dataGridView.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#CFD7DE");
                    dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
                    dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
                }
            }
        }


    }
}
