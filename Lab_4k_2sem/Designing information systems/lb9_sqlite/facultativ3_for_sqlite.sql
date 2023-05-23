
CREATE TABLE `mylog` (
  `id` integer primary key autoincrement,
  `user` varchar(20) NOT NULL,
  `query` varchar(15) NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
)


INSERT INTO `mylog` (`id`, `user`, `query`, `timestamp`) VALUES
(2, 'root@localhost', 'insert', '2023-03-06 11:38:32');



CREATE TABLE `predmets` (
   `id` integer primary key autoincrement,
  `name` varchar(50) NOT NULL,
  `lecturesize` integer NOT NULL,
  `practicesize` integer NOT NULL,
  `labsize` integer NOT NULL
)



INSERT INTO `predmets` (`id`, `name`, `lecturesize`, `practicesize`, `labsize`) VALUES
(1, 'Математика', 10, 10, 0),
(2, 'С++', 10, 10, 15),
(3, 'Філософія', 10, 10, 0),
(4, 'Теорія розпізнавання обєктів', 13, 13, 13),
(5, 'Системи керування базами даних', 10, 10, 10),
(6, 'Проектування інформаційних систем', 13, 7, 8),
(7, 'Іноземна мова', 0, 15, 0),
(8, 'Теорія прийняття рішень', 9, 9, 2),
(9, 'Інтелектуальні геоінформаційні системи', 15, 15, 8),
(10, 'Програмування мобільних додатків', 10, 10, 6),
(12, 'TEST', 1, 1, 1);



CREATE TABLE `students` (
   `id` integer primary key autoincrement,
  `name` varchar(30) NOT NULL,
  `surname` varchar(30) NOT NULL,
  `lastname` varchar(30) NOT NULL,
  `address` varchar(100) NOT NULL,
  `phone` varchar(15) NOT NULL
)  



INSERT INTO `students` (`id`, `name`, `surname`, `lastname`, `address`, `phone`) VALUES
(2, 'Микола', 'Максимович', 'Юрійович', '', '0996478177'),
(4, 'Мирослав', 'Любомирович', 'По батькові', 'м Заставна', '0991234567'),
(5, 'Михайло', 'Гандабура', 'Юрійович', 'м. Заставна', '0998765177'),
(6, 'Артур', 'Гостюк', '', 'не Чернівці', '0981111111'),
(7, 'Мирослав', 'Гудима', 'Вікторович', 'десь на півдні чернівців', 'незнаю'),
(8, 'Максим', 'Клейман', 'Олександрович', 'Чернівці', ''),
(9, 'Олександр', 'Кодряну', 'Олександрович', 'Чернівці?', ''),
(10, 'Юлія', 'Савескул', 'Іллівна', 'Чернівці', ''),
(11, 'Анна', 'Баланюк', 'Анатоліївна', 'Чернівці', ''),
(12, 'Антон', 'Хоміцький', 'Олексійович', 'Чернівці', '0986956785'),
(13, 'Святослав', 'Тащук', 'Валентинович', 'Чернігів', ''),
(14, 'Олександр', 'Шлемкевич', 'Олександрович', 'Вінниця', '094654653'),
(15, 'Світлана', 'Савчук', 'Сергіївна', 'Лондон', '0689567456735'),
(16, 'Владислав', 'Рощенюк', 'Олександрович', 'Воєнкомат', '07685674763'),
(17, 'Максим', 'Дудукал', 'Віталійович', 'Воєнкомат', '7805674763565');



CREATE TABLE `syllabus` (
  `id` integer primary key autoincrement,
  `id_student` integer NOT NULL,
  `id_predmet` integer NOT NULL,
  `year` year(4) NOT NULL,
  `semester` tinyint(1) NOT NULL,
  `grade` integer NOT NULL,
  FOREIGN KEY (`id_student`)  REFERENCES `students` (`id`),
  FOREIGN KEY (`id_predmet`)  REFERENCES `predmets` (`id`)
)



INSERT INTO `syllabus` (`id`, `id_student`, `id_predmet`, `year`, `semester`, `grade`) VALUES
(1, 2, 1, 2023, 1, 100),
(2, 2, 1, 2023, 0, 100),
(4, 2, 5, 2023, 1, 99),
(5, 2, 9, 2023, 1, 95),
(6, 2, 8, 2023, 1, 90),
(7, 5, 8, 2023, 0, 50),
(8, 5, 9, 2023, 1, 50),
(9, 2, 3, 2023, 1, 0),
(10, 8, 6, 2023, 1, 49),
(11, 8, 6, 2023, 1, 49),
(12, 6, 6, 2023, 1, 90),
(13, 5, 2, 2020, 0, 99),
(15, 11, 8, 2023, 1, 100),
(16, 10, 8, 2023, 1, 100),
(17, 14, 8, 2023, 1, 100),
(18, 13, 8, 2023, 1, 100),
(19, 12, 7, 2023, 1, 75),
(20, 13, 4, 2023, 1, 80),
(21, 15, 9, 2023, 1, 88),
(22, 15, 1, 2023, 1, 65),
(23, 5, 10, 2023, 0, 55),
(24, 2, 12, 2023, 0, 100),
(25, 4, 3, 2023, 0, 33),
(26, 8, 3, 2023, 1, 50);
