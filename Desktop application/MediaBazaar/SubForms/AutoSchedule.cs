using Logic.Models.AutoScheduling;
using MediaBazaar.Managers;
using MediaBazaar.UserControls;
using System.Diagnostics;
using System.Globalization;

namespace MediaBazaar.SubForms
{
    public partial class AutoSchedule : Form
    {
        private ScheduleManager scheduleManager;
        private ViewSchedule viewSchedule;

        public AutoSchedule(ScheduleManager scheduleManager,ViewSchedule viewSchedule)
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForForms(this.Controls, this);

            this.scheduleManager = scheduleManager;
            this.viewSchedule = viewSchedule;

            // fill comboBox with years
            foreach (int year in Enumerable.Range(DateTime.Now.Year - 5, 6))
            {
                cboxYearChoice.Items.Add(year);
            }

            // fill combobox with week numbers
            foreach (int weekNum in Enumerable.Range(1, ISOWeek.GetWeeksInYear(DateTime.Now.Year)))
            {
                cboxWeekChoice.Items.Add(weekNum);
            }

            // select current current weeknumber and year
            cboxWeekChoice.SelectedItem = ISOWeek.GetWeekOfYear(DateTime.Now);
            cboxYearChoice.SelectedItem = DateTime.Now.Year;
        }

        private void buttonGenerateSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                // setting the limit for schedule per shift
                #region Monday shifts
                ShiftLimits mondayMorning = null;
                try
                {
                    int min = Convert.ToInt32(textBoxMondayMorningMin.Text);
                    int max = Convert.ToInt32(textBoxMondayMorningMax.Text);

                    mondayMorning = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in Monday morning shift");
                    return;
                }

                ShiftLimits mondayAfternoon = null;
                try
                {
                    int min = Convert.ToInt32(textBoxMondayAfternoonMin.Text);
                    int max = Convert.ToInt32(textBoxMondayAfternoonMax.Text);

                    mondayAfternoon = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in Monday afternoon shift");
                    return;
                }

                ShiftLimits mondayEvening = null;
                try
                {
                    int min = Convert.ToInt32(textBoxMondayEveningMin.Text);
                    int max = Convert.ToInt32(textBoxMondayEveningMax.Text);

                    mondayEvening = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in Monday evening shift");
                    return;
                }
                DayLimits monday = new DayLimits(mondayMorning, mondayAfternoon, mondayEvening);
                #endregion

                #region Tuesday shifts
                ShiftLimits tuesdayMorning = null;
                try
                {
                    int min = Convert.ToInt32(textBoxTuesdayMorningMin.Text);
                    int max = Convert.ToInt32(textBoxTuesdayMorningMax.Text);

                    tuesdayMorning = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in tuesday morning shift");
                    return;
                }

                ShiftLimits tuesdayAfternoon = null;
                try
                {
                    int min = Convert.ToInt32(textBoxTuesdayAfternoonMin.Text);
                    int max = Convert.ToInt32(textBoxTuesdayAfternoonMax.Text);

                    tuesdayAfternoon = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in tuesday afternoon shift");
                    return;
                }

                ShiftLimits tuesdayEvening = null;
                try
                {
                    int min = Convert.ToInt32(textBoxTuesdayEveningMin.Text);
                    int max = Convert.ToInt32(textBoxTuesdayEveningMax.Text);

                    tuesdayEvening = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in tuesday evening shift");
                    return;
                }
                DayLimits tuesday = new DayLimits(tuesdayMorning, tuesdayAfternoon, tuesdayEvening);
                #endregion

                #region Wednesday shifts
                ShiftLimits wednesdayMorning = null;
                try
                {
                    int min = Convert.ToInt32(textBoxWednesdayMorningMin.Text);
                    int max = Convert.ToInt32(textBoxWednesdayMorningMax.Text);

                    wednesdayMorning = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in Wednesday morning shift");
                    return;
                }

                ShiftLimits wednesdayAfternoon = null;
                try
                {
                    int min = Convert.ToInt32(textBoxWednesdayAfternoonMin.Text);
                    int max = Convert.ToInt32(textBoxWednesdayAfternoonMax.Text);

                    wednesdayAfternoon = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in Wednesday afternoon shift");
                    return;
                }

                ShiftLimits wednesdayEvening = null;
                try
                {
                    int min = Convert.ToInt32(textBoxWednesdayEveningMin.Text);
                    int max = Convert.ToInt32(textBoxWednesdayEveningMax.Text);

                    wednesdayEvening = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in Wednesday evening shift");
                    return;
                }
                DayLimits wednesday = new DayLimits(wednesdayMorning, wednesdayAfternoon, wednesdayEvening);
                #endregion

                #region Thursday shifts
                ShiftLimits thursdayMorning = null;
                try
                {
                    int min = Convert.ToInt32(textBoxThursdayMorningMin.Text);
                    int max = Convert.ToInt32(textBoxThursdayMorningMax.Text);

                    thursdayMorning = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in Thursday morning shift");
                    return;
                }

                ShiftLimits thursdayAfternoon = null;
                try
                {
                    int min = Convert.ToInt32(textBoxThursdayAfternoonMin.Text);
                    int max = Convert.ToInt32(textBoxThursdayAfternoonMax.Text);

                    thursdayAfternoon = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in Thursday afternoon shift");
                    return;
                }

                ShiftLimits thursdayEvening = null;
                try
                {
                    int min = Convert.ToInt32(textBoxThursdayEveningMin.Text);
                    int max = Convert.ToInt32(textBoxThursdayEveningMax.Text);

                    thursdayEvening = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in Thursday evening shift");
                    return;
                }
                DayLimits thursday = new DayLimits(thursdayMorning, thursdayAfternoon, thursdayEvening);
                #endregion

                #region Friday shifts
                ShiftLimits fridayMorning = null;
                try
                {
                    int min = Convert.ToInt32(textBoxFridayMorningMin.Text);
                    int max = Convert.ToInt32(textBoxFridayMorningMax.Text);

                    fridayMorning = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in Friday morning shift");
                    return;
                }

                ShiftLimits fridayAfternoon = null;
                try
                {
                    int min = Convert.ToInt32(textBoxFridayAfternoonMin.Text);
                    int max = Convert.ToInt32(textBoxFridayAfteroonMax.Text);

                    fridayAfternoon = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in Friday afternoon shift");
                    return;
                }

                ShiftLimits fridayEvening = null;
                try
                {
                    int min = Convert.ToInt32(textBoxFridayEveningMin.Text);
                    int max = Convert.ToInt32(textBoxFridayEveningMax.Text);

                    fridayEvening = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in Friday evening shift");
                    return;
                }
                DayLimits friday = new DayLimits(fridayMorning, fridayAfternoon, fridayEvening);
                #endregion

                #region Saturday shifts
                ShiftLimits saturdayMorning = null;
                try
                {
                    int min = Convert.ToInt32(textBoxSaturdayMorningMin.Text);
                    int max = Convert.ToInt32(textBoxSaturdayMorningMax.Text);

                    saturdayMorning = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in Saturday morning shift");
                    return;
                }


                ShiftLimits saturdayAfternoon = null;
                try
                {
                    int min = Convert.ToInt32(textBoxSaturdayAfternoonMin.Text);
                    int max = Convert.ToInt32(textBoxSaturdayAfteroonMax.Text);

                    saturdayAfternoon = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in Saturday afternoon shift");
                    return;
                }

                ShiftLimits saturdayEvening = null;
                try
                {
                    int min = Convert.ToInt32(textBoxSaturdayEveningMin.Text);
                    int max = Convert.ToInt32(textBoxSaturdayEveningMax.Text);

                    saturdayEvening = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in Saturday evening shift");
                    return;
                }
                DayLimits Saturday = new DayLimits(saturdayMorning, saturdayAfternoon, saturdayEvening);
                #endregion

                #region Sunday shifts
                ShiftLimits sundayMorning = null;
                try
                {
                    int min = Convert.ToInt32(textBoxSundayMorningMin.Text);
                    int max = Convert.ToInt32(textBoxSundayMorningMax.Text);

                    sundayMorning = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in Sunday morning shift");
                    return;
                }


                ShiftLimits sundayAfternoon = null;
                try
                {
                    int min = Convert.ToInt32(textBoxSundayAfternoonMin.Text);
                    int max = Convert.ToInt32(textBoxSundayAfternoonMax.Text);

                    sundayAfternoon = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in Sunday afternoon shift");
                    return;
                }

                ShiftLimits sundayEvening = null;
                try
                {
                    int min = Convert.ToInt32(textBoxSundayEveningMin.Text);
                    int max = Convert.ToInt32(textBoxSundayEveningMax.Text);

                    sundayEvening = new ShiftLimits(max, min);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure that you enter only numbers in Sunday evening shift");
                    return;
                }
                DayLimits Sunday = new DayLimits(sundayMorning, sundayAfternoon, sundayEvening);
                #endregion


                WeekLimits weekLimits = new WeekLimits(monday, tuesday, wednesday, thursday, friday, Saturday, Sunday);

                int weekNum = Convert.ToInt32(cboxWeekChoice.SelectedItem);
                int year = Convert.ToInt32(cboxYearChoice.SelectedItem);


                var result = MessageBox.Show($"Are you sure you want to generate a schedule for week {weekNum} in {year}", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) 
                {
                    return;
                }

                scheduleManager.GenerateWeekSchedule(year, weekNum, weekLimits);
                viewSchedule.Refresh(year,weekNum);
                MessageBox.Show("Schedule generated successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.ToString());
            }

        }

        private void textBoxLimitAll_TextChanged(object sender, EventArgs e)
        {
            int limitAll = 0;
            try
            {
                if (String.IsNullOrWhiteSpace(textBoxLimitAll.Text)) 
                {
                    return;
                }
                limitAll = Convert.ToInt32(textBoxLimitAll.Text);
            }
            catch (FormatException) 
            {
                MessageBox.Show("Please make sure that you enter only numbers for limits");
                return;
            }

            foreach (Control control in this.Controls) 
            {
                if (control.Name.Contains("textBox")) 
                {
                    control.Text = limitAll.ToString();
                }
            }
        }
    }
}
