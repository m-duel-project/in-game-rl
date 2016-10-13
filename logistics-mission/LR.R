###################################
##### 로 지 스 틱 회 귀 분 석 #####
###################################
#install.packages("glm2")
library(glm2)

# target 변수 2개 범주로만 선택 (범주형변수로변환)
adj_iris <- iris
adj_iris$Species <- as.character(adj_iris$Species)
adj_iris <- subset(adj_iris, Species %in% c('versicolor', 'virginica'))
adj_iris$Species <- as.factor(adj_iris$Species)

set.seed(10)
# train / test 분할
ind <- sample(2, nrow(adj_iris), replace=TRUE, prob=c(0.7,0.3))
trainData <- adj_iris[ind==1, ]
testData <- adj_iris[ind==2, ]

# 모델링
formula <- Species ~ Sepal.Length + Sepal.Width + Petal.Length + Petal.Width
iris_logit <- glm(formula, data=trainData, family=binomial())

# 모델링 결과를 .rds로 저장
flower_func_logit =
function(sl, sw, pl, pw){
  testData <- data.frame(Sepal.Length=sl, Sepal.Width=sw, 
                         Petal.Length=pl, Petal.Width=pw)
  
  logitpred_a <- predict(iris_logit, newdata=testData, type="response")
  logitpred <- ifelse(logitpred_a>=0.5, "virginica", "versicolor")
  
  logitpred
}

save(iris_logit, flower_func_logit, file = "c:/Users/hcs64648/Desktop/iris_logit.RData")
