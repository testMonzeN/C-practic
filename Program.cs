static (bool, int) numberCheck(int min, int max) {
    bool status = int.TryParse(Console.ReadLine(), out int number);
    if (status == true && min <= number && number <= max)
    {
        return (true, number);
    }

    return (false, 0);
}

static double AverageScore(int c_students, int[] student_points)
{
    return (double)student_points.Sum() / c_students;
}


int c_students, ball;
do
{
    Console.Write("Введите число (1..50): ");
}
while (numberCheck(1, 50).Item1 == false);

int[] student_points = new int[c_students];

int max = 0;
int studen_have_max_ball = 0;

int с_bad = 0;
int с_satisFactorily = 0;
int с_success = 0;
int c_great = 0;

int count = 0;
double averageScore = 0;

c_students = numberCheck(1, 50).Item2;
for (int student_number = 0; student_number < c_students; student_number++)
{
    do
    {
        Console.Write($"Балл студента {student_number + 1} (0..100): ");
    }
    while (numberCheck(0, 100).Item1 == false);

    ball = numberCheck(1, 100).Item2;
    student_points[student_number] = ball;

    if (ball > max)
    {
        max = ball;
        studen_have_max_ball = student_number + 1;
    }

    if (0 <= ball && ball <= 39)
    {
        с_bad += 1;
    }
    else if (40 <= ball && ball <= 59)
    {
        с_satisFactorily += 1;
    }
    else if (60 <= ball && ball <= 79)
    {
        с_success += 1;
    }
    else if (80 <= ball && ball <= 100)
    {
        c_great += 1;
    }
}


averageScore = AverageScore(c_students, student_points);
foreach (int point in student_points)
{
    if (point > averageScore) { count++; }
}


Console.WriteLine("Средний балл: " + averageScore);
Console.WriteLine("Лучший результат: " + max + $" (студент #{studen_have_max_ball})");
Console.WriteLine($"Выше среднего: {count} из {c_students} \n");
Console.WriteLine("Распределение оценок");
Console.WriteLine("неуд.    (0-39)      | " + new string('*', с_bad) + " " + с_bad);
Console.WriteLine("удовл.   (40-59)     | " + new string('*', с_satisFactorily) + " " + с_satisFactorily);
Console.WriteLine("хор.     (60-79)     | " + new string('*', с_success) + " " + с_success);
Console.WriteLine("отл.     (80-100)    | " + new string('*', c_great) + " " + c_great);

