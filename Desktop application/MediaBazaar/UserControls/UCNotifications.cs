using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;
using System.Diagnostics;

namespace MediaBazaar.UserControls
{
    public partial class UCNotifications : UserControl
    {
        private NotificationManager notificationManager
        {
            get
            {
                try
                {
                    return new NotificationManager();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    this.Hide();
                    return null;
                }
            }
        }

        private int employeeId;
        private List<Notification> notifications;


        public UCNotifications()
        {
            InitializeComponent();
        }

        public void Setup(int employee_Id)
        {
            employeeId = employee_Id;
            RefreshUserControl();
            lVNotifications.Scrollable = true;
            lVNotifications.View = View.SmallIcon;
            lVNotifications.HeaderStyle = ColumnHeaderStyle.None;

        }

        public void RefreshUserControl()
        {
            RefrechNotificationsList();
            refreshLVNotifications();
        }

        private void RefrechNotificationsList()
        {
            try
            {
                notifications = notificationManager.GetNotificationsPerEmployee(employeeId, Platform.Desktop);
                notifications.Reverse();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                this.Hide();
                return;
            }
        }

        public int GetNumberOfUnseenNotifications()
        {
            try
            {
                RefrechNotificationsList();

                int notSeenNotifications = 0;
            for (int i = 0; i < notifications.Count; i++)
            {
                if (notifications[i].HasBeenSeen == false)
                {
                    notSeenNotifications++;
                }
            }
            return notSeenNotifications;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                this.Hide();
                return 0;
            }
        }

        private void refreshLVNotifications()
        {
            try
            {
                lVNotifications.Clear();

                foreach (var notification in notifications)
                {
                    ListViewItem notificationItem;

                    notificationItem = new ListViewItem(notification.Title);

                    if (!notificationManager.IsNotificationHasBeenSeen(notification.Id, employeeId))
                    {
                        notificationItem.BackColor = Color.LightGray;
                        notificationItem.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    }
                    else
                    {
                        notificationItem.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    }
                    lVNotifications.Items.Add(notificationItem);

                    String[] splitedDescription = notification.Description.Split(' ');

                    string newLine = string.Empty;
                    for (int i = 0; i < splitedDescription.Length; i++)
                    {
                        newLine += splitedDescription[i] + " ";

                        if (i % 5 == 0)
                        {
                            addingNewLineForDescription(newLine);
                            newLine = string.Empty;
                        }
                    }
                    if (newLine.Any())
                    {
                        addingNewLineForDescription(newLine);
                    }

                    void addingNewLineForDescription(string newLine)
                    {
                        notificationItem = new ListViewItem(newLine);

                        if (!notificationManager.IsNotificationHasBeenSeen(notification.Id, employeeId))
                        {
                            notificationItem.BackColor = Color.LightGray;
                            notificationItem.Font = new Font("Segoe UI", 7, FontStyle.Regular);
                        }
                        else
                        {
                            notificationItem.Font = new Font("Segoe UI", 7, FontStyle.Regular);
                        }
                        lVNotifications.Items.Add(notificationItem);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                this.Hide();
                MessageBox.Show("Something went wrong");
                return;
            }

        }

        private void SetAllToSeen()
        {
            try
            {
                if (GetNumberOfUnseenNotifications() == 0) 
                {
                    return;
                }
                foreach (Notification notification in notifications)
                {
                    notificationManager.SetNotiticationToSeen(notification.Id, employeeId);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                this.Hide();
                MessageBox.Show("Something went wrong");
                return;
            }
        }

        public void SetAfterSeen()
        {
            SetAllToSeen();
            RefrechNotificationsList();
        }
    }
}
