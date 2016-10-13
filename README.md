# in-game-rl
게임 내에서 머신러닝 알고리즘을 이용하는 방안에 대한 repo.

### R Machine Learning 스크립트
스터디에 사용되는 R 스크립트  
https://github.com/m-duel-project/in-game-rl/blob/master/r-script.r  

위의 스크립트를 활용해 기본 R에 대한 스터디를 진행  

### D-TREE 분석 스크립트
Decision tree 분석 알고리듬을 이용하는 전체 스크립트  
```
###################################
########## D-TREE 분 석 ###########
###################################
# install.packages("party")
library(party)

set.seed(2)
# train / test 분할
ind <- sample(2, nrow(iris), replace=TRUE, prob=c(0.7,0.3))
trainData <- iris[ind==1, ]
testData <- iris[ind==2, ]

# 모델링
formula <- Species ~ Sepal.Length + Sepal.Width + Petal.Length + Petal.Width
iris_ctree <- ctree(formula, data=trainData)

plot(iris_ctree)

# test 예측
ctreepred <- predict(iris_ctree, newdata=testData)
table(testData$Species, ctreepred)
```

### 로지스틱 회귀분석
Logistic Regression 분석 알고리듬을 이용하는 전체 스크립트
```

###################################
##### 로 지 스 틱 회 귀 분 석 #####
###################################
# install.packages("glm2")
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
#일반선형모형(GLM)이 아닌 로지스틱 회귀를 실행하기 위해, R 프로그램에 family=binomial 이란 옵션을 설정해야 하는 것

# test 예측
#data.frame(adj_iris$Species, as.numeric(adj_iris$Species)-1) #versicolor=0, virginica=1

logitpred_a <- predict(iris_logit, newdata=testData, type="response")
logitpred <- ifelse(logitpred_a>=0.5, "virginica", "versicolor")

table(testData$Species , logitpred)
```
### R로 제작한 분석 모델을 C# 또는 C++에서 호출하는 방안
위의 R 스크립트 중,  
- D-TREE 분석 스크립트로 제작된 모델  
- 로지스틱 회귀분석  

두개의 모델을 blue 팀과 red 팀에서 각각 C 또는 C++로 호출하는 미션을 수행  
R.NET 오픈소스 프로젝트 : http://jmp75.github.io/rdotnet/  



