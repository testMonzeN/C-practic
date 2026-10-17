int count_student, ball;
while (true)
{
    Console.Write("Введите число (1..50): ");
    bool status_count = int.TryParse(Console.ReadLine(), out count_student);
    if (status_count == true && 1 <= count_student && count_student <= 50)
    {
        break;
    }
}
int[] balls_student = new int[count_student];

int max = 0;
int studen_have_max_ball = 0;

int count_neud = 0;
int count_ud = 0;
int count_horosho = 0;
int count_otl = 0;

int count = 0;

for (int i = 0; i < count_student; i++)
{
    while (true)
    {
        Console.Write($"Балл студента {i + 1} (0..100): ");
        bool status_ball = int.TryParse(Console.ReadLine(), out ball);

        if (status_ball == true && 0 <= ball && ball <= 100)
        {
            break;

        }
    }
    balls_student[i] = ball;

    if (ball > max)
    {
        max = ball;
        studen_have_max_ball = i + 1;
    }

    if (0 <= ball && ball <= 39)
    {
        count_neud += 1;
    }
    else if (40 <= ball && ball <= 59)
    {
        count_ud += 1;
    }
    else if (60 <= ball && ball <= 79)
    {
        count_horosho += 1;
    }
    else if (80 <= ball && ball <= 100)
    {
        count_otl += 1;
    }


}
float sr_ball = (float)balls_student.Sum() / count_student;
for (int j = 0; j < count_student; j++)
{
    if (balls_student[j] > sr_ball) { count++; }
}


Console.WriteLine("Средний балл: " + sr_ball.ToString());
Console.WriteLine("Лучший результат: " + max.ToString() + $" (студент #{studen_have_max_ball.ToString()})");
Console.WriteLine($"Выше среднего: {count} из {count_student} \n");
Console.WriteLine("Распределение оценок");
Console.WriteLine("неуд.    (0-39)      | " + new string('*', count_neud) + " " + count_neud.ToString());
Console.WriteLine("удовл.   (40-59)     | " + new string('*', count_ud) + " " + count_ud.ToString());
Console.WriteLine("хор.     (60-79)     | " + new string('*', count_horosho) + " " + count_horosho.ToString());
Console.WriteLine("отл.     (80-100)    | " + new string('*', count_otl) + " " + count_otl.ToString());

