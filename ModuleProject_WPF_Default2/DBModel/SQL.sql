-- --------------------------------------------------------
-- 호스트:                          192.168.0.210
-- 서버 버전:                        11.3.2-MariaDB - mariadb.org binary distribution
-- 서버 OS:                        Win64
-- HeidiSQL 버전:                  11.0.0.5919
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- vms_bss_dev 데이터베이스 구조 내보내기
DROP DATABASE IF EXISTS `vms_bss_dev`;
CREATE DATABASE IF NOT EXISTS `vms_bss_dev` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;
USE `vms_bss_dev`;

-- 테이블 vms_bss_dev.alarmactionprocess 구조 내보내기
DROP TABLE IF EXISTS `alarmactionprocess`;
CREATE TABLE IF NOT EXISTS `alarmactionprocess` (
  `no` int(11) NOT NULL AUTO_INCREMENT,
  `groupno` int(11) DEFAULT NULL,
  `index` int(11) DEFAULT NULL,
  `sensorsort` int(11) DEFAULT NULL,
  `actiontarget` varchar(50) DEFAULT NULL,
  `actioncode` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `param` int(11) DEFAULT NULL,
  `delay` int(11) DEFAULT NULL,
  `description` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`no`)
) ENGINE=InnoDB AUTO_INCREMENT=10129 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 vms_bss_dev.alarmoperation 구조 내보내기
DROP TABLE IF EXISTS `alarmoperation`;
CREATE TABLE IF NOT EXISTS `alarmoperation` (
  `no` int(11) NOT NULL AUTO_INCREMENT,
  `groupno` int(11) DEFAULT NULL,
  `alarmname` varchar(50) DEFAULT NULL,
  `index` int(11) DEFAULT NULL,
  `sensorsort` int(11) DEFAULT NULL,
  `actioncode` varchar(50) DEFAULT NULL,
  `param` int(11) DEFAULT NULL,
  `subsensorsort` int(11) DEFAULT NULL,
  `subactioncode` varchar(50) DEFAULT NULL,
  `subparam` int(11) DEFAULT NULL,
  `alarmcombination` varchar(50) DEFAULT NULL,
  `section` int(11) DEFAULT NULL,
  `ignoretime` int(11) DEFAULT NULL,
  `broadcastno` int(11) DEFAULT NULL,
  `endtime` int(11) DEFAULT NULL,
  `checkalarmsmstime` int(11) DEFAULT NULL,
  `alarmoccursprocessno` int(11) DEFAULT NULL,
  `alarmfiredcode` varchar(50) DEFAULT NULL,
  `alarmfiredprocessno` int(11) DEFAULT NULL,
  `isstream` varchar(1) DEFAULT NULL,
  `isdblog` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`no`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 vms_bss_dev.alarmprocess 구조 내보내기
DROP TABLE IF EXISTS `alarmprocess`;
CREATE TABLE IF NOT EXISTS `alarmprocess` (
  `no` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 vms_bss_dev.audioencoder 구조 내보내기
DROP TABLE IF EXISTS `audioencoder`;
CREATE TABLE IF NOT EXISTS `audioencoder` (
  `serialno` int(11) NOT NULL AUTO_INCREMENT,
  `encodername` varchar(50) DEFAULT NULL,
  `displayname` varchar(50) DEFAULT NULL,
  `sort` int(11) DEFAULT NULL,
  `livevolume` int(11) DEFAULT NULL,
  `source` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`serialno`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 vms_bss_dev.camera 구조 내보내기
DROP TABLE IF EXISTS `camera`;
CREATE TABLE IF NOT EXISTS `camera` (
  `camno` int(11) NOT NULL AUTO_INCREMENT,
  `camname` varchar(50) NOT NULL,
  `userid` varchar(50) DEFAULT NULL,
  `pwd` varchar(50) DEFAULT NULL,
  `ipaddr` varchar(50) DEFAULT NULL,
  `portno` int(11) DEFAULT NULL,
  `url` varchar(50) DEFAULT NULL,
  `isptz` int(11) DEFAULT NULL,
  `resx` int(11) DEFAULT NULL,
  `resy` int(11) DEFAULT NULL,
  `codecid` int(11) DEFAULT NULL,
  `model` varchar(50) DEFAULT NULL,
  `modelindex` int(11) DEFAULT NULL,
  `destsvrip` varchar(50) DEFAULT NULL,
  `destport` int(11) DEFAULT NULL,
  `destch` int(11) DEFAULT NULL,
  `audioon` int(11) DEFAULT NULL,
  `fps` int(11) DEFAULT NULL,
  `bps` int(11) DEFAULT NULL,
  `protocol` int(11) DEFAULT NULL,
  `subch` int(11) DEFAULT NULL,
  `transportmode` int(11) DEFAULT NULL,
  `description` varchar(200) DEFAULT NULL,
  `areano` int(11) DEFAULT NULL,
  `areacamno` int(11) DEFAULT NULL,
  `datacollection` char(1) DEFAULT NULL,
  `collectionkind` varchar(512) DEFAULT NULL,
  PRIMARY KEY (`camno`),
  UNIQUE KEY `camno` (`camno`)
) ENGINE=InnoDB AUTO_INCREMENT=1026 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 vms_bss_dev.cameraalarmoperation 구조 내보내기
DROP TABLE IF EXISTS `cameraalarmoperation`;
CREATE TABLE IF NOT EXISTS `cameraalarmoperation` (
  `no` int(11) NOT NULL AUTO_INCREMENT,
  `alarmcode` varchar(50) DEFAULT NULL,
  `maincamerano` int(11) DEFAULT NULL,
  `maincameraalarmcode` varchar(50) DEFAULT NULL,
  `subcamerano` int(11) DEFAULT NULL,
  `subcameraalarmcode` varchar(50) DEFAULT NULL,
  `alarmcombination` varchar(50) DEFAULT NULL,
  `islive` varchar(1) DEFAULT 'Y',
  `alarmoperation` int(11) DEFAULT 3,
  PRIMARY KEY (`no`)
) ENGINE=InnoDB AUTO_INCREMENT=163 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 vms_bss_dev.contactextension 구조 내보내기
DROP TABLE IF EXISTS `contactextension`;
CREATE TABLE IF NOT EXISTS `contactextension` (
  `no` int(11) NOT NULL AUTO_INCREMENT,
  `comp` varchar(50) DEFAULT NULL,
  `model` varchar(50) DEFAULT NULL,
  `stationno` int(11) DEFAULT NULL,
  `ipaddr` varchar(50) DEFAULT NULL,
  `port` int(11) DEFAULT NULL,
  `inputcount` int(11) DEFAULT NULL,
  `outputcount` int(11) DEFAULT NULL,
  `alive` int(1) DEFAULT 0,
  PRIMARY KEY (`no`)
) ENGINE=InnoDB AUTO_INCREMENT=102 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 vms_bss_dev.contactinput 구조 내보내기
DROP TABLE IF EXISTS `contactinput`;
CREATE TABLE IF NOT EXISTS `contactinput` (
  `no` int(11) DEFAULT NULL,
  `contactsort` int(11) DEFAULT NULL,
  `sensorno` int(11) DEFAULT NULL,
  `portno` int(11) DEFAULT NULL,
  `stationno` int(11) DEFAULT NULL,
  `onstatus` varchar(50) DEFAULT NULL,
  `alarmstatus` varchar(50) DEFAULT NULL,
  `alarmoperation` int(11) DEFAULT NULL,
  `alarmprocess` int(11) DEFAULT NULL,
  `alarmcode` varchar(50) DEFAULT NULL,
  `isalive` int(11) DEFAULT NULL,
  `description` varchar(50) DEFAULT NULL,
  KEY `no` (`no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 vms_bss_dev.contactoutput 구조 내보내기
DROP TABLE IF EXISTS `contactoutput`;
CREATE TABLE IF NOT EXISTS `contactoutput` (
  `no` int(11) DEFAULT NULL,
  `contactsort` int(11) DEFAULT NULL,
  `sensorno` int(11) DEFAULT NULL,
  `portno` int(11) DEFAULT NULL COMMENT '포트 번호',
  `stationno` int(11) DEFAULT NULL COMMENT '스테이션 번호',
  `onstatus` varchar(50) DEFAULT 'Close',
  `operationdefult` varchar(50) DEFAULT NULL COMMENT '운영시간 시 기본 접점',
  `contactoperation` int(11) DEFAULT NULL COMMENT '운영시간 스케줄 섹션',
  `alarmoperation` int(11) DEFAULT NULL,
  `alarmcode` varchar(50) DEFAULT NULL,
  `isalive` int(11) DEFAULT NULL,
  `description` varchar(30) DEFAULT NULL COMMENT '메모',
  KEY `no` (`no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 vms_bss_dev.dashboarddata 구조 내보내기
DROP TABLE IF EXISTS `dashboarddata`;
CREATE TABLE IF NOT EXISTS `dashboarddata` (
  `no` int(11) NOT NULL AUTO_INCREMENT,
  `stationno` int(11) DEFAULT NULL,
  `sortindex` int(11) DEFAULT NULL,
  `sensorsot` int(11) DEFAULT NULL,
  `datasort` varchar(50) DEFAULT NULL,
  `sensorno` int(11) DEFAULT NULL,
  `subsensorno` int(11) DEFAULT NULL,
  `sensortarget` varchar(50) DEFAULT NULL,
  `defaultvalue` varchar(50) DEFAULT NULL,
  `sensorname` varchar(50) DEFAULT NULL,
  `alarmcode` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`no`)
) ENGINE=InnoDB AUTO_INCREMENT=10000 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 vms_bss_dev.multikan 구조 내보내기
DROP TABLE IF EXISTS `multikan`;
CREATE TABLE IF NOT EXISTS `multikan` (
  `serialno` int(11) NOT NULL AUTO_INCREMENT,
  `groupno` int(11) DEFAULT NULL,
  `sort` int(11) DEFAULT NULL,
  `stationno` int(11) DEFAULT NULL,
  `devicedisplayname` varchar(50) DEFAULT NULL,
  `devicename` varchar(50) DEFAULT NULL,
  `alive` int(11) DEFAULT NULL,
  `camerano` int(11) DEFAULT NULL,
  `camerapresetno` int(11) DEFAULT NULL,
  `rs232serial1` varchar(50) DEFAULT 'NaN',
  `rs232serial2` varchar(50) DEFAULT 'NaN',
  `rs485serial1` varchar(50) DEFAULT 'NaN',
  `rs485serial2` varchar(50) DEFAULT 'NaN',
  `fwuversion` varchar(50) DEFAULT NULL,
  `isdirectsocket` varchar(50) DEFAULT 'Y',
  `isemergencycall` varchar(50) DEFAULT 'Y',
  PRIMARY KEY (`serialno`)
) ENGINE=InnoDB AUTO_INCREMENT=107 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 vms_bss_dev.multikhanautobroadcastinfo 구조 내보내기
DROP TABLE IF EXISTS `multikhanautobroadcastinfo`;
CREATE TABLE IF NOT EXISTS `multikhanautobroadcastinfo` (
  `no` int(11) NOT NULL AUTO_INCREMENT,
  `sourceno` int(11) DEFAULT NULL,
  `displayname` varchar(50) DEFAULT NULL,
  `volume` int(11) NOT NULL,
  PRIMARY KEY (`no`),
  UNIQUE KEY `displayname` (`displayname`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 vms_bss_dev.screen 구조 내보내기
DROP TABLE IF EXISTS `screen`;
CREATE TABLE IF NOT EXISTS `screen` (
  `screenno` int(11) NOT NULL AUTO_INCREMENT,
  `screenname` varchar(50) DEFAULT '0',
  `screensort` int(11) DEFAULT 0,
  `arrayx` int(11) DEFAULT 0,
  `arrayy` int(11) DEFAULT 0,
  `mapno` int(11) DEFAULT NULL,
  KEY `screenno` (`screenno`)
) ENGINE=InnoDB AUTO_INCREMENT=121 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 vms_bss_dev.screencamera 구조 내보내기
DROP TABLE IF EXISTS `screencamera`;
CREATE TABLE IF NOT EXISTS `screencamera` (
  `screenno` int(11) DEFAULT NULL,
  `camerano` int(11) DEFAULT NULL,
  `orderid` int(11) DEFAULT NULL,
  `left` int(11) DEFAULT NULL,
  `top` int(11) DEFAULT NULL,
  `right` int(11) DEFAULT NULL,
  `bottom` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 vms_bss_dev.server 구조 내보내기
DROP TABLE IF EXISTS `server`;
CREATE TABLE IF NOT EXISTS `server` (
  `serverno` int(11) NOT NULL AUTO_INCREMENT,
  `servername` varchar(50) DEFAULT NULL,
  `sort` int(11) DEFAULT NULL,
  `ipaddr` varchar(50) DEFAULT NULL,
  `secondaryportno` int(11) DEFAULT NULL,
  `city` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`serverno`),
  UNIQUE KEY `serverno` (`serverno`)
) ENGINE=InnoDB AUTO_INCREMENT=107 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 vms_bss_dev.smsprocessor 구조 내보내기
DROP TABLE IF EXISTS `smsprocessor`;
CREATE TABLE IF NOT EXISTS `smsprocessor` (
  `no` int(11) NOT NULL AUTO_INCREMENT,
  `requesturi` varchar(500) DEFAULT NULL,
  `contenttype` varchar(500) DEFAULT NULL,
  `method` varchar(500) DEFAULT NULL,
  `host` varchar(500) DEFAULT NULL,
  `smscode` varchar(50) DEFAULT NULL,
  `smstitle` varchar(50) DEFAULT NULL,
  `smsmessage` varchar(500) DEFAULT NULL,
  `sendinfo` int(11) DEFAULT NULL,
  `recvinfo` varchar(50) DEFAULT NULL,
  `description` varchar(20) DEFAULT NULL,
  KEY `no` (`no`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 vms_bss_dev.smsreceiverinfo 구조 내보내기
DROP TABLE IF EXISTS `smsreceiverinfo`;
CREATE TABLE IF NOT EXISTS `smsreceiverinfo` (
  `no` int(11) NOT NULL AUTO_INCREMENT,
  `receiver` varchar(20) DEFAULT NULL,
  `receivername` varchar(20) DEFAULT NULL,
  KEY `no` (`no`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 vms_bss_dev.smssenderinfo 구조 내보내기
DROP TABLE IF EXISTS `smssenderinfo`;
CREATE TABLE IF NOT EXISTS `smssenderinfo` (
  `no` int(11) NOT NULL AUTO_INCREMENT,
  `id` varchar(20) DEFAULT NULL,
  `pwd` varchar(30) DEFAULT NULL,
  `sender` varchar(20) DEFAULT NULL,
  `sendername` varchar(20) DEFAULT NULL,
  `msgtype` int(1) DEFAULT NULL,
  KEY `no` (`no`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 vms_bss_dev.stationinfo 구조 내보내기
DROP TABLE IF EXISTS `stationinfo`;
CREATE TABLE IF NOT EXISTS `stationinfo` (
  `no` int(11) NOT NULL AUTO_INCREMENT,
  `fullareaname` varchar(50) DEFAULT NULL,
  `localareaname` varchar(50) DEFAULT NULL,
  `fulladdress` varchar(500) DEFAULT NULL,
  `localaddress` varchar(500) DEFAULT NULL,
  `city` varchar(50) DEFAULT NULL,
  `mapdirectory` varchar(500) DEFAULT NULL,
  `starttime` time DEFAULT NULL,
  `voicetime` time DEFAULT NULL,
  `endtime` time DEFAULT NULL,
  `scheduleinterval` int(11) DEFAULT NULL,
  `stationtype` varchar(50) DEFAULT NULL,
  `stationcode` varchar(7) DEFAULT NULL,
  `isalive` int(11) DEFAULT NULL,
  `longitude` double NOT NULL DEFAULT 0,
  `latitude` double NOT NULL DEFAULT 0,
  `seasons` varchar(50) DEFAULT NULL,
  `sunday` int(11) DEFAULT NULL,
  `monday` int(11) DEFAULT NULL,
  `tuseday` int(11) DEFAULT NULL,
  `wednesday` int(11) DEFAULT NULL,
  `thursday` int(11) DEFAULT NULL,
  `friday` int(11) DEFAULT NULL,
  `saturday` int(11) DEFAULT NULL,
  `alarmoperationgroupno` int(11) DEFAULT NULL,
  PRIMARY KEY (`no`)
) ENGINE=InnoDB AUTO_INCREMENT=108 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
