using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model
{
    public class Date
    {
        private static int minYear = 1900;
        private static int maxYear = 2200;

        private int d;
        private int m;
        private int y;

        public int D
        {
            get => d;
            set
            {
                if (value <= 1)
                {
                    d = 1;
                }
                else if (value >= 31)
                {
                    d = 31;
                }
                else
                {
                    d = value;
                }
            }
        }
        public int M
        {
            get => m;
            set
            {
                if (value <= 1)
                {
                    m = 1;
                }
                else if (value >= 12)
                {
                    m = 12;
                }
                else
                {
                    m = value;
                }
            }
        }
        public int Y
        {
            get => y;
            set
            {
                if (value <= minYear)
                {
                    y = minYear;
                }
                else if (value >= maxYear)
                {
                    y = maxYear;
                }
                else
                {
                    y = value;
                }
            }
        }

        public Date(int day, int month, int year)
        {
            this.D = day;
            this.M = month;
            this.Y = year;

            while (this.d > Date.DaysOfMonth(this.m, this.y))
            {
                this.d--;
            }
        }

        public Date(DateTime dt)
        {
            this.D = dt.Day;
            this.M = dt.Month;
            this.Y = dt.Year;
        }

        public Date(string str)
        {
        }

        #region Operator
        public static Date operator ++(Date date)
        {
            if (date.D == Date.DaysOfMonth(date.M, date.Y))
            {
                date.D = 1;

                if (date.M == 12)
                {
                    date.M = 1;
                    date.Y++;
                }
                else
                {
                    date.M++;
                }
            }
            else
            {
                date.D++;
            }
            return date;
        }

        public static Date operator --(Date date)
        {
            if (date.D == 1)
            {
                if (date.M == 1)
                {
                    date = new Date(31, 12, date.Y - 1);
                }
                else
                {
                    date.M--;
                    date.D = Date.DaysOfMonth(date.M, date.Y);
                }

            }
            else
            {
                date.D--;
            }
            return date;
        }

        public static bool operator !=(Date date1, Date date2)
        {
            if (date1.D != date2.D)
            {
                return true;
            }
            if (date1.M != date2.M)
            {
                return true;
            }
            if (date1.Y != date2.Y)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(Date date1, Date date2)
        {
            return (!(date1 != date2));
        }

        public static bool operator >(Date date1, Date date2)
        {
            if (date1.Y > date2.Y)
            {
                return true;
            }
            else if (date1.Y < date2.Y)
            {
                return false;
            }

            if (date1.M > date2.M)
            {
                return true;
            }
            else if (date1.M < date2.M)
            {
                return false;
            }

            if (date1.D > date2.D)
            {
                return true;
            }

            return false;
        }

        public static bool operator >=(Date date1, Date date2)
        {
            return (!(date1 < date2));
        }

        public static bool operator <(Date date1, Date date2)
        {
            if (date1.Y < date2.Y)
            {
                return true;
            }
            else if (date1.Y > date2.Y)
            {
                return false;
            }

            if (date1.M < date2.M)
            {
                return true;
            }
            else if (date1.M > date2.M)
            {
                return false;
            }

            if (date1.D < date2.D)
            {
                return true;
            }

            return false;
        }

        public static bool operator <=(Date date1, Date date2)
        {
            return (!(date1 > date2));
        }

        #endregion

        public static bool IsLeapYear(int year)
        {
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                return true;
            }
            return false;
        }

        public static int DaysOfMonth(int month, int year)
        {
            switch (month)
            {
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    if (Date.IsLeapYear(year))
                    {
                        return 29;
                    }
                    return 28;
                default:
                    return 31;
            }
        }
    }
}
