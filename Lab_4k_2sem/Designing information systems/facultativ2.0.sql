-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Мар 01 2023 г., 12:19
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
(2, 'С++', 10, 10, 15);

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
(5, 'Михайло', 'Гандабура', 'Юрійович', 'м. Заставна', '0998765177');

-- --------------------------------------------------------

--
-- Структура таблицы `syllabus`
--

CREATE TABLE `syllabus` (
  `id_student` int(11) NOT NULL,
  `id_predmet` int(11) NOT NULL,
  `year` year(4) NOT NULL,
  `semester` tinyint(1) NOT NULL COMMENT '0 = first sem, 1 = second sem',
  `grade` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `syllabus`
--

INSERT INTO `syllabus` (`id_student`, `id_predmet`, `year`, `semester`, `grade`) VALUES
(2, 1, 2023, 1, 100),
(2, 1, 2023, 0, 100);

--
-- Индексы сохранённых таблиц
--

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
  ADD KEY `id_student` (`id_student`),
  ADD KEY `id_predmet` (`id_predmet`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `predmets`
--
ALTER TABLE `predmets`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `students`
--
ALTER TABLE `students`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

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
