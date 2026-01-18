/*
해당 SQL 쿼리문은 TellTok 프로그램에 필요한 데이터베이스 초기 설정 스크립트입니다.
마지막 수정: 2024-11-26
*/

-- telltok 데이터베이스 생성
CREATE DATABASE [telltok];
GO

-- telltok 데이터베이스로 전환
USE [telltok];
GO

-- user(유저 정보) 테이블 생성
CREATE TABLE [user] (
    u_no INT PRIMARY KEY IDENTITY,             -- 유저 고유번호
    u_id VARCHAR(50) NOT NULL,                 -- 유저의 로그인 전용 ID
    u_pw VARCHAR(255) NOT NULL,                -- 유저의 로그인 전용 PW
    u_name NVARCHAR(100) NOT NULL,             -- 유저의 이름
    u_status_text NVARCHAR(255),               -- 유저의 상태메세지
    u_like_count INT DEFAULT 0 NOT NULL,       -- 유저 프로필의 좋아요 갯수
    u_friend_id INT,                           -- 친구추가 전용 고유 번호
    u_birthdate DATE NOT NULL,                 -- 생년월일
    u_gender TINYINT CHECK (u_gender BETWEEN 0 AND 2) NOT NULL, -- 유저의 성별 (0=비공개, 1=여성, 2=남성)
    u_friend_fix VARCHAR(255),                 -- 유저의 고정 친구 목록 (콤마로 구분된 고유번호)
    u_friend VARCHAR(255),                      -- 유저의 친구 목록 (콤마로 구분된 고유번호)
	u_tellpay INT,								-- TellPay 포인트
	u_emoticon VARCHAR(255),					-- 보유중인 이모티콘(콤마로 구분된 고유번호)(emoticon_store)
	u_profile_image VARBINARY(MAX)
);

-- file(파일 전송 내역) 테이블 생성
CREATE TABLE [file] (
    f_no INT PRIMARY KEY IDENTITY,             -- 파일 고유번호
    f_name VARCHAR(255) NOT NULL               -- 파일 이름 (확장명 포함)
);

-- chat_group(채팅 그룹) 테이블 생성
CREATE TABLE chat_group (
    cg_no INT PRIMARY KEY IDENTITY,
	cg_tamp INT NOT NULL
);

-- chat(채팅) 테이블 생성
CREATE TABLE chat (
    c_no INT PRIMARY KEY IDENTITY,             -- 채팅 고유번호
    c_date DATETIME NOT NULL,                  -- 채팅 전송 날짜
    c_go INT NOT NULL,                         -- 전송한 유저의 고유번호 (FK)
    c_take INT NOT NULL,                       -- 받은 유저의 고유번호 (FK)
    c_message NVARCHAR(300),                   -- 메세지 내용
	e_no INT,								   -- 전송한 이모티콘
    f_no INT,                                  -- 전송된 파일의 고유번호 (FK)
	c_delete BIT NOT NULL,					   -- 삭제 여부
	cg_no INT NOT NULL,
    FOREIGN KEY (c_go) REFERENCES [user](u_no),
    FOREIGN KEY (c_take) REFERENCES [user](u_no),
	FOREIGN KEY (e_no) REFERENCES [emoticon](e_no),
	FOREIGN KEY (f_no) REFERENCES [file](f_no),
    FOREIGN KEY (cg_no) REFERENCES [chat_group](cg_no)
);

-- add_friend(친구 추가 요청 기록) 테이블 생성
CREATE TABLE add_friend (
    af_no INT PRIMARY KEY IDENTITY,            -- 친구 추가 요청 고유번호
    af_go INT NOT NULL,                        -- 요청 보낸 유저 고유번호 (FK)
    af_take INT NOT NULL,                      -- 요청 받은 유저 고유번호 (FK)
    FOREIGN KEY (af_go) REFERENCES [user](u_no),
    FOREIGN KEY (af_take) REFERENCES [user](u_no)
);

-- alim(알림) 테이블 생성
CREATE TABLE alim (
    a_no INT PRIMARY KEY IDENTITY,             -- 알림 고유번호
    a_date DATETIME NOT NULL,                  -- 알림 생성 날짜
    af_no INT,                                 -- 친구 추가 요청 고유번호 (FK, 선택적)
    FOREIGN KEY (af_no) REFERENCES add_friend(af_no)
);

-- ads(광고) 테이블 생성
CREATE TABLE ads (
    ad_no INT PRIMARY KEY IDENTITY,             -- 광고 고유번호
	ad_image VARBINARY(MAX)
);

-- emoticon_store(이모티콘 상점) 테이블 생성
CREATE TABLE emoticon_store (
    es_no INT PRIMARY KEY IDENTITY,				-- 이모티콘 상점 고유번호
	es_name NVARCHAR(100),						-- 이모티콘 이름
	es_price INT								-- 이모티콘 가격
);

-- emoticon(이모티콘) 테이블 생성
CREATE TABLE emoticon (
    e_no INT PRIMARY KEY IDENTITY,				-- 이모티콘 고유번호
	e_image VARBINARY(MAX),						-- 이모티콘 이미지
	es_no INT,									-- 이모티콘 상점 번호 (상속)
	FOREIGN KEY (es_no) REFERENCES emoticon_store(es_no)
);

-- transfer(송금내역) 테이블 생성
CREATE TABLE [transfer] (
    t_no INT PRIMARY KEY IDENTITY,				-- 송금내역 고유번호
	t_go INT,									-- 포인트를 보낸 유저번호
	t_take INT,									-- 포인트를 받은 유저번호
	t_price INT,								-- 포인트
	t_message NVARCHAR(255),					-- 메세제
	t_date DATETIME NOT NULL,                  -- 생성 날짜
	FOREIGN KEY (t_go) REFERENCES [user](u_no),
    FOREIGN KEY (t_take) REFERENCES [user](u_no)
);