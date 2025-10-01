//T1 Marcus

int[] grades = {4, 7, 2, 0, 10, 4, 12};

int GetGrade(int courseId) {
    int grade = grades[courseId];
    if (grade < 2)
        throw new Exception("Student failed!"); //Manually throwing an exception!
    return grade;
}

int count = 0;
int sum = 0;

//We iterate through all grades
for (int courseId = 0; courseId < grades.Length; courseId++) {
    //GetGrade() may throw an exception, so we handle it with a try catch
    try {
        int grade = GetGrade(courseId);
        //If an exception happended in GetGrade, it is caught immeadietly, and the 2 lines below this comment will not run!
        count++;
        sum += grade;
    }
    catch (Exception e) {
        Console.WriteLine("Course " + courseId + ": " + e.Message);
    }
}

Console.WriteLine("Average: " + (sum / count));
