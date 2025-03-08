using System;

namespace Practice.Core.LINQ;

public static class LinqQueries
{

    public static List<Student> SelectTopScoredStudents(List<Student>? students)
    {
        if (students == null) throw new ArgumentNullException(nameof(students));
        return students.Where(s => s.Score > 80).OrderByDescending(s => s.Score).ToList();
    }

}
