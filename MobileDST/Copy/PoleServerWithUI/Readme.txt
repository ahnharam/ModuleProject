2022-05-23

잔여 작업 : 
	폴링 주기 - UI 바인딩
	슬레이브 연결 상태 - 에러 카운트 -> 커넥션 표시

-----------------------
2022-05-24

잔여 작업 : 
	마스터, 슬레이브 UI 수정
	마스터 모델 추가
	Master IP 선택 후 send Data 기능

모듈 오류사항 : 
	CRC코드 비정상
	드문 확률로 마지막 바이트 3개 비정상 표출 ( 가장 마지막 FF 제외 )

모듈 구조적 문제 :
	Slave의 연결 상태를 확인불가 ( Slave의 전원을 제거해도 Master 에서 데이터 반환 )

프로그램 주의사항 :
	Auto Poling을 실행한 후 종료시 데이터가 완전히 들어온 다음 수동 폴링을 실행한다.
	폴징 주기시간이 Slave 데이터 대기 시간보다 길어야 한다 ( 약 2초~3초 정도 차이가 있어야 함 )

프로그램 설정 파일 위치 :
	프로그램 실행 디렉토리\PoleServerWithUI.exe.config

프로그램 로그 파일 위치 :
	프로그램 실행 디렉토리\Log\Log_날짜.log

-----------------------
2022-05-25
	1차 프로그램 개발 완료
	
CRC 체크 :
	GateWayConnect.cs - 451 라인

DB 수정시 :
	DeviceStateViewModel.cs - 214 라인 ( Insert 따라가시면 됩니다 )
	GateWayConnect.cs - 456 라인 