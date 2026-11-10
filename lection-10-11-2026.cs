using System.Text;

class Programm
{
    private static string add_student(string count, string nickname)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(nickname);

        int int_count = int.Parse(count);
        int sum = 0;
        Console.WriteLine("Введите " + int_count + " оценок:");

        for (int i = 0; i < int_count; i++)
        {
            sb.Append(" ");
            Console.Write($"#{i + 1}: ");
            int point = int.Parse(Console.ReadLine());
            sb.Append(point.ToString());
            sum += point;
        }
        sb.Append(" " + ((double)sum / int_count).ToString());

        Console.WriteLine("Готово!");
        return sb.ToString();
    }

    private static void edit_student(List<string> list, string nickname, int number)
    {
        for (int i = 0; i < list.Count; i++)
        {
            string[] parts = list[i].Split(" ");
            string fio = parts[0] + " " + parts[1] + " " + parts[2];

            if (fio == nickname)
            {
                int grade_index = 2 + number;

                if (number < 1 || grade_index >= parts.Length - 1)
                {
                    Console.WriteLine("Нет оценки с таким номером");
                    return;
                }

                Console.WriteLine("Текущая оценка №" + number + ": " + parts[grade_index]);
                Console.Write("Новая оценка: ");
                string new_grade = Console.ReadLine();
                parts[grade_index] = new_grade;
                parts[parts.Length - 1] = calc_average(parts).ToString();

                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < parts.Length; j++)
                {
                    if (j > 0)
                    {
                        sb.Append(" ");
                    }
                    sb.Append(parts[j]);
                }

                list[i] = sb.ToString();
                sort_students(list);
                Console.WriteLine("Готово!");
                return;
            }
        }

        Console.WriteLine("Ученик не найден");
    }

    private static void search_student(List<string> list, string nickname)
    {
        for (int i = 0; i < list.Count; i++)
        {
            string[] parts = list[i].Split(" ");
            string fio = parts[0] + " " + parts[1] + " " + parts[2];

            if (fio == nickname)
            {
                Console.WriteLine(format_student(list[i]));
                return;
            }
        }

        Console.WriteLine("Ученик не найден");
    }

    private static double calc_average(string[] parts)
    {
        if (parts.Length <= 4)
        {
            return 0;
        }

        double sum = 0;
        int count = 0;

        for (int i = 3; i < parts.Length - 1; i++)
        {
            sum += int.Parse(parts[i]);
            count++;
        }

        return sum / count;
    }

    private static double get_average(string student)
    {
        string[] parts = student.Split(" ");
        return calc_average(parts);
    }

    private static void sort_students(List<string> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = 0; j < list.Count - 1 - i; j++)
            {
                if (get_average(list[j]) < get_average(list[j + 1]))
                {
                    string temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }
    }

    private static string get_status(double avg)
    {
        if (avg >= 4.5)
        {
            return "отличник";
        }
        else if (avg >= 3.5)
        {
            return "хорошист";
        }
        else if (avg >= 2.5)
        {
            return "троечник";
        }
        else
        {
            return "двоечник";
        }
    }

    private static string format_student(string student)
    {
        string[] parts = student.Split(" ");
        string fio = parts[0] + " " + parts[1] + " " + parts[2];
        double avg = calc_average(parts);

        StringBuilder grades = new StringBuilder();
        for (int i = 3; i < parts.Length - 1; i++)
        {
            if (i > 3)
            {
                grades.Append(" ");
            }
            grades.Append(parts[i]);
        }

        StringBuilder sb = new StringBuilder();
        sb.Append(fio.PadRight(50));
        sb.Append("|");
        sb.Append(grades.ToString().PadRight(30));
        sb.Append("|");
        sb.Append(avg.ToString().PadRight(20));
        sb.Append("|");
        sb.Append(get_status(avg).PadRight(20));

        return sb.ToString().PadRight(150);
    }

    private static void list_students(List<string> list, string filter)
    {
        bool found = false;

        Console.WriteLine("===========================================".PadRight(20));
        Console.WriteLine("ФИО | ОЦЕНКИ | СРЕДНИЙ БАЛЛ | КАТЕГОРИЯ".PadRight(20));
        Console.WriteLine("===========================================".PadRight(20));
        
        for (int i = 0; i < list.Count; i++)
        {
            double avg = get_average(list[i]);
            bool show = false;

            if (filter == "все")
            {
                show = true;
            }
            else if (filter == "отл" && avg >= 4.5)
            {
                show = true;
            }
            else if (filter == "хор" && avg >= 3.5 && avg < 4.5)
            {
                show = true;
            }
            else if (filter == "троеч" && avg >= 2.5 && avg < 3.5)
            {
                show = true;
            }
            else if (filter == "двоеч" && avg < 2.5)
            {
                show = true;
            }

            if (show)
            {      
                Console.WriteLine(format_student(list[i]));
                found = true;
            }
        }
        
        if (filter != "все" && filter != "отл" && filter != "хор" && filter != "троеч" && filter != "двоеч")
        {
            Console.WriteLine("Неизвестный фильтр");
            return;
        }

        if (found == false)
        {
            Console.WriteLine("Таких нету");
        }
        Console.WriteLine("===========================================");

    }

    public static void Main()
    {
        Console.WriteLine("Выберите комманду");
        Console.WriteLine("добавить <ФИО> <КОЛ-ВО оценок> - добавить ученика");
        Console.WriteLine("редактировать <ФИО> <номер оценки> - редактировать оценку ученика");
        Console.WriteLine("поиск <ФИО> - поиск ученика");
        Console.WriteLine("список <все/отл/хор/троеч/двоеч> - список учеников");
        Console.WriteLine("выход - выход");

        bool status = true;
        List<string> list = new List<string>();

        while (status)
        {
            string input = Console.ReadLine();
            string[] cmd = input.ToLower().Split(" ");

            switch (cmd[0])
            {
                case "добавить":
                    string student = add_student(cmd[4], cmd[1] + " " + cmd[2] + " " + cmd[3]);
                    list.Add(student);
                    sort_students(list);
                    break;

                case "редактировать":
                    edit_student(list, cmd[1] + " " + cmd[2] + " " + cmd[3], int.Parse(cmd[4]));
                    break;

                case "поиск":
                    search_student(list, cmd[1] + " " + cmd[2] + " " + cmd[3]);
                    break;

                case "список":
                    list_students(list, cmd[1]);
                    break;

                case "выход":
                    status = false;
                    break;

                default:
                    Console.WriteLine("Неизвестная команда");
                    break;
            }
        }
    }
}
