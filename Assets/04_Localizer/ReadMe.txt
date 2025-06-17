중국어, 일본어는 유니코드 범위를 설정해줘야 하는 것 같은데

일본어는 30A0-30FF 이거로 하면 됨

중국어 폰트는 일본어 폰트를 설정하면 알아서 되던 것도 있어서 잘 모름

(중국어도 저거로 하면 되긴 하는데...)

Window -> TextMeshPro -> Font Asset Creator

만들어진 폰트에셋 인스펙터에서
Atlas Population Mode를 Dynamic으로
Sampling Point Size를 조절해가면서 나오나 안나오나 확인


통합으로 사용할 폰트 인스펙터 아래에 Fallback Font Assets에
다른 나라 폰트에셋을 추가하면 하나로 전부 사용 가능함


로컬라이저도 엑셀->json으로 변환해야 하니 JDataTransformer로 json으로 변환해야 함

데이터 매니저랑 로컬라이즈 데이터를 가져오는 건 똑같음