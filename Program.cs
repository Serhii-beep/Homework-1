using System;
using System.Collections.Generic;

namespace Education
{
    abstract class Student
    {
        protected string name;
        protected string state;

        protected Student(string name_)
        {
            name = name_;
            state = String.Empty;
        }

        public void Relax()
        {
            state += "Relax";
        }

        public void Read()
        {
            state += "Read";
        }

        public void Write()
        {
            state += "Write";
        }

        public string GetName()
        {
            return name;
        }

        public string GetState()
        {
            return state;
        }

        public abstract void Study();
    }

    class GoodStudent: Student
    { 
        public GoodStudent(string _name): base(_name)
        {
            state += "good";
        }

        public override void Study()
        {
            Read();
            Write();
            Read();
            Write();
            Relax();
        }
    }

    class BadStudent: Student
    {
        public BadStudent(string _name): base(_name)
        {
            state += "bad";
        }

        public override void Study()
        {
            Relax();
            Relax();
            Relax();
            Relax();
            Read();
        }

    }

    class Group
    {
        private string group_name;
        private List<Student> students = new List<Student>();

        public Group(string group_name_)
        {
            group_name = group_name_;
        }

        public void AddStudent(Student st)
        {
            students.Add(st);
            st.Study();
        }

        public void GetInfo()
        {
            Console.WriteLine("Група {0}, список студентiв:", group_name);
            foreach(var st in students)
            {
                Console.Write("{0} ", st.GetName());
            }
            Console.Write("\n");
        }

        public void GetFullInfo()
        {
            GetInfo();
            foreach(var st in students)
            {
                Console.WriteLine("{0}: {1}", st.GetName(), st.GetState());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Для виходу натиснiть q, для продовження будь-яку iншу клавiшу");
                if(Console.ReadKey(true).Key == ConsoleKey.Q)
                {
                    Environment.Exit(0);
                }
                Console.WriteLine("Введiть назву групи:");
                Group group = new Group(Console.ReadLine());
                Console.WriteLine("Введiть iмена хороших студентiв(в рядок без пробiлiв):");
                string[] good_students_names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine("Введiть iмена поганих студентiв(в рядок без пробiлiв):");
                string[] bad_students_names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var s in good_students_names)
                {
                    GoodStudent st = new GoodStudent(s);
                    group.AddStudent(st);
                }
                foreach (var s in bad_students_names)
                {
                    BadStudent st = new BadStudent(s);
                    group.AddStudent(st);
                }
                Console.WriteLine("Iнформацiя про групу:");
                group.GetFullInfo();
                Console.Write("\n\n\n");
            }
        }

        
    }
}
