# 미션 #

제작한 분석 모델을 C# 또는 C++에서 호출하는
-  D-TREE 분석 스크립트로 제작된 모델

# 구현 #

- REngine 객체의 생성주기의 컨트롤은 caller (제작 코드에서는 Main 메서드) 에서 관리
- 분석 모델에 대한 호출 코드는 C# 확장 메서드로 구현
  - 인자:
    - REngine engine
    - double sepalLength
    - double sepalWidth
    - double petalLength
    - double petalWidth
    - string species
  - 반환 형식: string (species)

인자는 string.Format으로 REngine.Evaluate로 밀어넣고 (이스케이프 처리 안 했음), 결과는 REngine.GetSymbol로 받아온다.