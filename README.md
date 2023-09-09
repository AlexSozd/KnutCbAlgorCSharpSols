# KnutCbAlgorCSharpSols (English)

Realization of combinatorial searching algorithms described in Chapter 7 of Donald Knut book "The Art of Computer Programming", Volume 4A (by C# language means).

-	Generating all compositions of a positive integer n (solution of the task 12 to the Section 7.2.1.1)
-	Alphametics solution (marked as Algorithm G in the Section 7.2.1.2)
-	Generating all combinations by Gray code (7.2.1.1L)
-	Generating partitions of a positive integer n (partitions of n into m parts, 7.2.1.4H)
-	Generating all set partitions by restricted growth string (7.2.1.5H)

For the first task – generating compositions of a positive integer with writing them in the row (the AlgorStudy_Lab1 project) – basic template class List<T> is used to construct each of them. All completed instances are added elementwise to the string for result output.

For the third task – alphametics solution (the AlgorStudy_Lab2_1 project) – additional several lists based on the same template class were inserted, two symbolic ones for alphametics letters (all ones and only at the first positions in numbers’ record) and two integer ones for storage of checking calculations’ elements. Also a pair of integer array is employed for the permutation tuple and the auxiliary control table representation.

For the next cases – generating combinations and partitions – integer arrays are applied for the tuple and the auxiliary, specifying an order of its elements changing, variable-switch (focal pointer) set representation. Determined variants are collected into template strings by an instance of the special constructor class (the StringBuilder class), then added to the list (or, in the last program – the AlgorStudy_Lab5_1 project, to the sorted set represented in the C# language by the SortedSet class). Finally, this list is converted into the result string. 

# KnutCbAlgorCSharpSols (Русский)

Реализации на языке С# алгоритмов комбинаторного поиска из главы 7, входящей в том 4A книги Дональда Кнута «Искусство программирования».

-	Генерация композиций числа n (решение задачи 12 к разделу 7.2.1.1)
-	Решение «буквометика» (обозначен как алгоритм G в разделе 7.2.1.2)
-	Генерация всех сочетаний кодом Грея (7.2.1.1L)
-	Генерация разбиений целого числа n (разбиений числа n на m блоков, 7.2.1.4H)
-	Генерация всех разбиений множеств с помощью ограниченно растущей строки (7.2.1.5H)

Для первой задачи – генерации композиции числа в виде ряда (проект AlgorStudy_Lab1) – в исходном коде использовался стандартный класс-шаблон для представления списка (List<T>), с последующим переносом поэлементно каждого экземпляра в результирующую строку. Для третьей – решения «буквометика» (проект AlgorStudy_Lab2_1) – использовалось ещё несколько листов на основе того же класса-шаблона – два под целые числа, для промежуточных проверочных вычислений, и два для хранения букв, всех встречающихся в примере и отдельно для стоящих на первых позициях в записи чисел. Ещё одна пара целочисленных массивов применяется для представления кортежа перестановки (упорядоченная запись соответствующих буквам цифр) и вспомогательной управляющей таблицы.

Для последующих задач – генераций сочетаний и разбиений – также применялись целочисленные массивы для представления картежей и прилагающихся к ним наборов вспомогательных переменных-переключателей (фокусных указателей), определяющих порядок обращения к элементам кортежа. Найденные варианты собираются через соответствующий класс-конструктор (класс StringBuilder) в строки определённого формата, добавляемые в списки (в последней программе, AlgorStudy_Lab5_1 – в сортированное множество, объект класса SortedSet  языка C#), также с переносом в строки вывода.
