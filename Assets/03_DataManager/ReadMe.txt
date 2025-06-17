엑셀파일을 유니티가 읽게 하려면
Assets 폴더 하위에 Plugins 폴더에 .dll 파일 2개가 있어야 함

Assets 폴더 하위에 Editor 폴더를 만들고 거기에 JDataTransformer를 넣어야
에디터 툴바에서 엑셀을 json으로 바꿀 수 있음. 경로는 상황에 맞게 수정해줘야 함

json을 읽으려면 패키지 매니저에서 Install package by name으로
com.unity.nuget.newtonsoft-json
를 설치해야 사용할 수 있음
그 후 using Newtonsoft.Json using해주기

Addressable
패키지 매니저에서 Unity Registry -> Addressable 검색 후 설치해야 함

데이터 매니저 초기화 순서를 가장 먼저 설정해줘야 함


데이터 클래스의 맴버변수 이름과 엑셀의 데이터 이름이 같아야 함


JDataTransformer 클래스 내부

new { Items = rawData }로 필드를 만들면 리스트로 바로 역직렬화 할 수 없음
리스트를 감싸는 클래스가 필요함
string json = JsonConvert.SerializeObject(new { Items = rawData }, Formatting.Indented);

string json = JsonConvert.SerializeObject(rawData, Formatting.Indented);