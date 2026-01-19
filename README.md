![icon_text](./icon_text_.ico)

# TellTok

> **2025년 전국기능경기대회 정보기술 직종 1과제(C#) 출전 작품**
> 
> 강원도 대표로 출전하여 제작한 Windows 기반 메신저 프로그램입니다.
> 카카오톡의 UI/UX에서 영감을 받아, 제한된 대회 환경 내에서 사용자 편의성과 UI 완성도를 극대화하는 데 초점을 두었습니다.


## 프로젝트 소개

**TellTok**은 전국기능경기대회 정보기술 직종 과제로 제출한  
C# WinForms 기반 메신저 애플리케이션입니다.

**Client-to-DB(MSSQL) 직접 연결 방식**으로 채팅기능을 구현 하였습니다.

대회 과제 특성상 일부 구조는 일반적인 실무 패턴과 다를 수 있습니다.

## 개발 기간
- **2024.12 ~ 2025.06**


## 풀이 환경
1. Visual Studio에서 C#(.NET Framework 4.7.2) WinForm 환경에서 제작하세요.
2. 데이터베이스로는 Microsoft SQL Server (MSSQL)을 사용하세요. 현재 프로젝트를 기준으로 ID: `sa`, PW: `1234` 환경으로 세팅되어있습니다.
   만약 변경을 원한다면, [app.config](./App.config)에서 `connectionStrings` 항목에 `user id=sa;password=1234;` 값을 원하는 값으로 변경해주세요.
```xml
﻿<?xml version="1.0" encoding="utf-8"?>
<configuration>
...
 <connectionStrings>
  <add name="telltokEntities" connectionString="metadata=res://*/db.data.csdl|res://*/db.data.ssdl|res://*/db.data.msl;...user id=[아이디];password=[패스워드]..." providerName="..." />
 </connectionStrings>
</configuration>
```


## 문제지

[PDF 문제지](./전국기능경기대회%20강원도%201과제.pdf)  [HWP 문제지](./전국기능경기대회%20강원도%201과제.hwp)

## 기술 스택

- **Language:** C# (.NET Framework 4.7.2)
- **UI Framework:** Windows Forms (WinForms)
- **Database:** Microsoft SQL Server (MSSQL)
- **IDE / Tools:** Visual Studio 2022, SQL Server Management Studio 19.x (SSMS)


## 데이터베이스 구조
데이터베이스 이름: `telltok`

1. `add_friend` (친구 추가 요청)

   | 필드명 | 데이터 형식 | 속성 | 설명 |
   | --- | --- | --- | --- |
   | **af_no** | INT | PK, ID | 친구 추가 요청 고유번호 |
   | **af_go** | INT | NOT NULL, FK(user) | 요청 보낸 유저 고유번호 |
   | **af_take** | INT | NOT NULL, FK(user) | 요청 받은 유저 고유번호 |

2. `ads` (광고)

   | 필드명 | 데이터 형식 | 속성 | 설명 |
   | --- | --- | --- | --- |
   | **ad_no** | INT | PK, ID | 광고 고유번호 |
   | **ad_image** | VARBINARY(MAX) | - | 광고 이미지 |

3. `alim` (알림)

   | 필드명 | 데이터 형식 | 속성 | 설명 |
   | --- | --- | --- | --- |
   | **a_no** | INT | PK, ID | 알림 고유번호 |
   | **a_date** | DATETIME | NOT NULL | 알림 생성 날짜 |
   | **af_no** | INT | FK(add_friend) | 친구 요청 고유번호 |

4. `chat` (채팅)

   | 필드명 | 데이터 형식 | 속성 | 설명 |
   | --- | --- | --- | --- |
   | **c_no** | INT | PK, ID | 채팅 고유번호 |
   | **c_date** | DATETIME | NOT NULL | 전송 날짜 |
   | **c_go** | INT | NOT NULL, FK(user) | 보낸 유저 |
   | **c_take** | INT | NOT NULL, FK(user) | 받은 유저 |
   | **c_message** | NVARCHAR(300) | - | 메세지 내용 |
   | **e_no** | INT | FK(emoticon) | 전송 이모티콘 |
   | **f_no** | INT | FK(file) | 전송 파일 |
   | **c_delete** | BIT | NOT NULL | 삭제 여부 |
   | **cg_no** | INT | NOT NULL, FK(chat_group) | 채팅 그룹 |

5. `chat_group` (채팅 그룹)

   | 필드명 | 데이터 형식 | 속성 | 설명 |
   | --- | --- | --- | --- |
   | **cg_no** | INT | PK, ID | 채팅 그룹 번호 |
   | **cg_tamp** | INT | NOT NULL | 임시값 |

6. `emoticon` (이모티콘)

   | 필드명 | 데이터 형식 | 속성 | 설명 |
   | --- | --- | --- | --- |
   | **e_no** | INT | PK, ID | 이모티콘 번호 |
   | **e_image** | VARBINARY(MAX) | - | 이모티콘 이미지 |
   | **eq_no** | INT | FK(emoticon_group) | 이모티콘 그룹 고유번호 |

7. `emoticon_group` (이모티콘 그룹)

   | 필드명 | 데이터 형식 | 속성 | 설명 |
   | --- | --- | --- | --- |
   | **eq_no** | INT | PK, ID | 그룹 고유번호 |
   | **eg_name** | NVARCHAR(100) | - | 이모티콘 이름 |

8. `file` (파일)

   | 필드명 | 데이터 형식 | 속성 | 설명 |
   | --- | --- | --- | --- |
   | **f_no** | INT | PK, ID | 파일 고유번호 |
   | **f_name** | VARCHAR(255) | NOT NULL | 파일 이름 (확장자 포함) |

9. `user` (유저)

   | 필드명 | 데이터 형식 | 속성 | 설명 |
   | --- | --- | --- | --- |
   | **u_no** | INT | PK, ID | 유저 고유번호 |
   | **u_id** | VARCHAR(50) | NOT NULL | 로그인 ID |
   | **u_pw** | VARCHAR(255) | NOT NULL | 로그인 PW |
   | **u_name** | NVARCHAR(100) | NOT NULL | 이름 |
   | **u_status_text** | NVARCHAR(255) | - | 상태메시지 |
   | **u_like_count** | INT | DEFAULT 0, NOT NULL | 좋아요 수 |
   | **u_friend_id** | INT | - | 친구추가용 고유번호 |
   | **u_birthdate** | DATE | NOT NULL | 생년월일 |
   | **u_gender** | TINYINT | NOT NULL | 성별 (0:비공개, 1:여, 2:남) |
   | **u_friend_fix** | VARCHAR(255) | - | 고정 친구 목록 |
   | **u_friend** | VARCHAR(255) | - | 친구 목록 |
   | **u_tellpay** | INT | - | TellPay 포인트 |
   | **u_emoticon** | VARCHAR(255) | - | 보유 이모티콘 |
   | **u_profile_image** | VARBINARY(MAX) | - | 프로필 이미지 |
   | **u_background_image** | VARBINARY(MAX) | - | 프로필 배경 이미지 |

## 실행 화면

![1](./screenshots/1.png)
![2](./screenshots/2.png)
![3](./screenshots/3.png)
![4](./screenshots/4.png)
![5](./screenshots/5.png)
![6](./screenshots/6.png)
![7](./screenshots/7.png)
![8](./screenshots/8.png)
