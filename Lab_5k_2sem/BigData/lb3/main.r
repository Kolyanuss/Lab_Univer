# Завантаження вбудованого набору даних
data <- iris

# 2
library(dplyr)
# Профайлінг даних
data_summary <- data %>%
  summarise_all(funs(sum(is.na(.)), n_distinct(.)))
print("data_summary")
print(data_summary)
# Фільтрація даних
filtered_data <- data %>% 
  filter(Sepal.Length > 5)
print("filtered_data")
print(filtered_data)
# Даунсемплінг
downsampled_data <- filtered_data %>%
  group_by(Species) %>%
  sample_n(size = 22)
print("downsampled_data")
print(downsampled_data)

# 3
library(caret)
# Розбиття даних на навчальний та тестовий набори
set.seed(123)
train_index <- createDataPartition(data$Species, p = 0.8, list = FALSE)
train_data <- data[train_index, ]
test_data <- data[-train_index, ]

# Створення моделі логістичної регресії
model <- train(Species ~ ., data = train_data, method = "rf",
               family = "binomial", trControl = trainControl(method = "cv", summaryFunction = multiClassSummary))

# Перевірка моделі на тестовому наборі
predictions <- predict(model, newdata = test_data)
print("predictions:")
print(head(predictions))
# accurasy
accuracy <- sum(predictions == test_data$Species) / nrow(test_data)
print(paste0("Accuracy: ", accuracy))


# Завантаження необхідних бібліотек
# library(bigrf) # Warning message: package 'bigrf' is not available for this version of R
library(wsrf)

# Побудова ансамблевої моделі з використанням wsrf
wsrf_model <- wsrf(Species ~ ., data = train_data, ntree = 500, mtry = 2)
wsrf_predictions <- predict(wsrf_model, newdata = test_data)
wsrf_accuracy <- sum(wsrf_predictions$class == test_data$Species) / nrow(test_data)
print(paste0("Accuracy of wsrf model: ", wsrf_accuracy))