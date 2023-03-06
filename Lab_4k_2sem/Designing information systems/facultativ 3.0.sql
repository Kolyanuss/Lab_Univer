-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Мар 06 2023 г., 14:43
-- Версия сервера: 5.6.51-log
-- Версия PHP: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `facultativ`
--

-- --------------------------------------------------------

--
-- Структура таблицы `mylog`
--

CREATE TABLE `mylog` (
  `id` int(11) NOT NULL,
  `user` varchar(20) NOT NULL,
  `query` varchar(15) NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `mylog`
--

INSERT INTO `mylog` (`id`, `user`, `query`, `timestamp`) VALUES
(2, 'root@localhost', 'insert', '2023-03-06 11:38:32');

-- --------------------------------------------------------

--
-- Структура таблицы `predmets`
--

CREATE TABLE `predmets` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `lecturesize` int(11) NOT NULL,
  `practicesize` int(11) NOT NULL,
  `labsize` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `predmets`
--

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

--
-- Триггеры `predmets`
--
DELIMITER $$
CREATE TRIGGER `my_trigger3` BEFORE INSERT ON `predmets` FOR EACH ROW INSERT INTO `mylog` SET `user`= USER(), `query`='insert'
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Структура таблицы `students`
--

CREATE TABLE `students` (
  `id` int(11) NOT NULL,
  `name` varchar(30) NOT NULL,
  `surname` varchar(30) NOT NULL,
  `lastname` varchar(30) NOT NULL,
  `address` varchar(100) NOT NULL,
  `phone` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `students`
--

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

-- --------------------------------------------------------

--
-- Структура таблицы `syllabus`
--

CREATE TABLE `syllabus` (
  `id` int(11) NOT NULL,
  `id_student` int(11) NOT NULL,
  `id_predmet` int(11) NOT NULL,
  `year` year(4) NOT NULL,
  `semester` tinyint(1) NOT NULL COMMENT '0 = first sem, 1 = second sem',
  `grade` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `syllabus`
--

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

--
-- Триггеры `syllabus`
--
DELIMITER $$
CREATE TRIGGER `my_trigger` BEFORE INSERT ON `syllabus` FOR EACH ROW INSERT INTO `mylog` SET `user`= USER(), `query`='insert'
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `my_trigger2` AFTER INSERT ON `syllabus` FOR EACH ROW INSERT INTO `mylog` SET `user`= USER(), `query`='insert'
$$
DELIMITER ;

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `mylog`
--
ALTER TABLE `mylog`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `predmets`
--
ALTER TABLE `predmets`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `syllabus`
--
ALTER TABLE `syllabus`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_student` (`id_student`),
  ADD KEY `id_predmet` (`id_predmet`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `mylog`
--
ALTER TABLE `mylog`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `predmets`
--
ALTER TABLE `predmets`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT для таблицы `students`
--
ALTER TABLE `students`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT для таблицы `syllabus`
--
ALTER TABLE `syllabus`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `syllabus`
--
ALTER TABLE `syllabus`
  ADD CONSTRAINT `syllabus_ibfk_1` FOREIGN KEY (`id_student`) REFERENCES `students` (`id`),
  ADD CONSTRAINT `syllabus_ibfk_2` FOREIGN KEY (`id_predmet`) REFERENCES `predmets` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
