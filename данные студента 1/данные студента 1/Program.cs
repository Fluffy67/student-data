using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace данные_студента_1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new entrance());
        }

    }
    static class database
    {
    public static string connectionString = @"Data Source=styd.db;Integrated Security=False; MultipleActiveResultSets=True";

    }

    static class table_students
    {
        public static string main = "Students";
        public static string student_id = "student_id";
        public static string full_name = "full_name";
        public static string course = "course";
        public static string faculty = "faculty";
        public static string specialty = "specialty";
        public static string date_of_birth = "date_of_birth";
        public static string marital_status = "marital_status";
        public static string family_info = "family_info";

    }

    static class table_groups
    {
        public static string main = "Groups";
        public static string group_id = "group_id";
        public static string group_number = "group_number";
        public static string scholarship_amount = "scholarship_amount";
        public static string enrollment_year = "enrollment_year";

    }

    static class table_faculty
    {
        public static string main = "Faculties";
        public static string faculty_id = "faculty_id";
        public static string faculty_name = "faculty_name";
        public static string faculty_capacity = "faculty_capacity";

    }
}
