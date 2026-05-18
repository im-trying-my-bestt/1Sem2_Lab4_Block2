using System;
using System.Text;
using System.Linq;

namespace struct_lab_student
{
    struct Student
    {
        public string surName;
        public string firstName;
        public string patronymic;
        public char gender;
        public string dateOfBirth;
        public char mathematicsMark;
        public char physicsMark;
        public char informaticsMark;
        public int scholarship;

        public Student(string lineWithAllData)
        {
            string[] persn = lineWithAllData.Trim().Split(' ');

            surName = persn[0];//string ""
            firstName = persn[1];
            patronymic = persn[2];
            gender = persn[3][0]; //1st char of string ''
            dateOfBirth = persn[4];
            mathematicsMark = persn[5][0];
            physicsMark = persn[6][0];
            informaticsMark = persn[7][0];
            scholarship = int.Parse(persn[8]);//string to int
        }
    }
}
