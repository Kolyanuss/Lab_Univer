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
model <- train(Species ~ ., data = train_data, method = "glm",
               family = "binomial", trControl = trainControl(method = "cv", summaryFunction = multiClassSummary))

# Перевірка моделі на тестовому наборі
predictions <- predict(model, newdata = test_data)
print("predictions:")
print(head(predictions))
# Обчислення RMSE
actual_values <- test_data$Species
rmse <- sqrt(mean((predictions - actual_values)^2))
print(paste("RMSE:", rmse))