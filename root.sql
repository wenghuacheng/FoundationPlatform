/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50712
Source Host           : localhost:3306
Source Database       : wordrepository

Target Server Type    : MYSQL
Target Server Version : 50712
File Encoding         : 65001

Date: 2017-12-18 20:46:19
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `root`
-- ----------------------------
DROP TABLE IF EXISTS `root`;
CREATE TABLE `root` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `Derivative` varchar(100) DEFAULT NULL,
  `Type` int(11) NOT NULL,
  `Mean` varchar(100) DEFAULT NULL,
  `ChineseMean` varchar(100) DEFAULT NULL,
  `Remark` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=128 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of root
-- ----------------------------
INSERT INTO `root` VALUES ('7', 'ag', '', '1', 'to do,to drive', '做，驱使', '与act同源');
INSERT INTO `root` VALUES ('8', 'act', null, '0', 'to do,to drive', '做,驱使', '与ag前缀同源');
INSERT INTO `root` VALUES ('9', 'am', 'amat', '0', 'to love', '爱', null);
INSERT INTO `root` VALUES ('10', 'anim', null, '0', 'life', '生命', 'animal的词根');
INSERT INTO `root` VALUES ('11', 'ann', 'enn', '0', 'year', '年', '通常ann针对的是年,如一年n次。enn针对的是事，如几年一次');
INSERT INTO `root` VALUES ('12', 'anthrop', 'anthropo', '0', 'man,human kind', '人类', '一般带连接词o');
INSERT INTO `root` VALUES ('13', 'arch', null, '0', 'rule', '统治', null);
INSERT INTO `root` VALUES ('14', 'aud', 'audit', '0', 'to hear', '听', null);
INSERT INTO `root` VALUES ('15', 'aug', 'auct,auth', '0', 'to increase', '增加，使增大', null);
INSERT INTO `root` VALUES ('16', 'bi', 'bio', '0', 'life', '生命', '通常bi有连接词o，所以通常为bio');
INSERT INTO `root` VALUES ('17', 'cad', 'cas,cid', '0', 'to fall,befall', '降,降临', null);
INSERT INTO `root` VALUES ('18', 'cap', 'capt,cept,ceive', '0', 'to take', '取', 'ceive是古语法中一个变体');
INSERT INTO `root` VALUES ('19', 'ced', 'ceed,cess', '0', 'to go', '走', 'ceed目前只有proceed,succeed,exceed三个词使用');
INSERT INTO `root` VALUES ('20', 'centr', null, '0', 'sharp point', '尖端点,中心点', null);
INSERT INTO `root` VALUES ('21', 'cern', 'cret', '0', 'to separate', '分离', 'cret分词词干，一般用于名词,形容词');
INSERT INTO `root` VALUES ('22', 'cid', 'cis', '0', 'to cut', '切', null);
INSERT INTO `root` VALUES ('23', 'claim', null, '0', 'to call out', '喊', null);
INSERT INTO `root` VALUES ('24', 'clin', 'clim', '0', 'to lean,slope', '倾斜', null);
INSERT INTO `root` VALUES ('25', 'clud', 'clus', '0', 'to shut,close', '关闭', null);
INSERT INTO `root` VALUES ('26', 'cord', null, '0', 'heart', '心', null);
INSERT INTO `root` VALUES ('27', 'corp', 'corpor', '0', 'body', '体,人体', null);
INSERT INTO `root` VALUES ('28', 'cred', 'credit', '0', 'to believe,to trust', '相信,信任', null);
INSERT INTO `root` VALUES ('29', 'cresc', 'cret,cre', '0', 'to grow', '生长', null);
INSERT INTO `root` VALUES ('30', 'cub', 'cumb', '0', 'to lie down', '卧', null);
INSERT INTO `root` VALUES ('31', 'cult', 'col', '0', 'to till', '耕作', null);
INSERT INTO `root` VALUES ('32', 'cur(r)', 'curs,cours', '0', 'to run', '跑', 'curr用来构成动词,curs,cours一般只出现在名词形容词中');
INSERT INTO `root` VALUES ('33', 'cur', null, '0', 'care', '关心', '需要与cur(r)区别，意为to run');
INSERT INTO `root` VALUES ('34', 'cycl', null, '0', 'circle', '圆环', null);
INSERT INTO `root` VALUES ('35', 'dem', 'demo', '0', 'the people', '人民', '通常带连接件词o');
INSERT INTO `root` VALUES ('36', 'dic', 'dict(at)', '0', 'to say', '说', null);
INSERT INTO `root` VALUES ('37', 'doc', 'doct', '0', 'to teach', '教', null);
INSERT INTO `root` VALUES ('38', 'duc', 'duct', '0', 'to lead', '引导', null);
INSERT INTO `root` VALUES ('39', 'equ', null, '0', 'even,equal', '相等的', null);
INSERT INTO `root` VALUES ('40', 'fac', 'fact,fect', '0', 'to do,make', '做', null);
INSERT INTO `root` VALUES ('41', 'fer', null, '0', 'to carry,to bring,to bear', '拿,带,负担', null);
INSERT INTO `root` VALUES ('42', 'fid', null, '0', 'to trust', '信任', null);
INSERT INTO `root` VALUES ('43', 'fig', 'figur,fict', '0', 'to shape', '塑造', 'fig的常用形式是figur');
INSERT INTO `root` VALUES ('44', 'fin', null, '0', 'end,limit', '末尾', null);
INSERT INTO `root` VALUES ('45', 'flu', 'flux', '0', 'to flow', '流动', null);
INSERT INTO `root` VALUES ('46', 'form', 'format', '0', 'shape,to form', '形状,形成', '名词的含义是形状,动词的含义是形成');
INSERT INTO `root` VALUES ('47', 'fort', 'forc', '0', 'strong,strength', '强,力量', null);
INSERT INTO `root` VALUES ('48', 'frag', 'fract', '0', 'to break', '破', null);
INSERT INTO `root` VALUES ('49', 'fund', 'found,fus', '0', 'to melt,to pour', '熔化,浇注', null);
INSERT INTO `root` VALUES ('50', 'gen', 'gener', '0', 'birth,race', '出生,种类', null);
INSERT INTO `root` VALUES ('51', 'ger', 'gest', '0', 'to bear,carry', '承担,运送', 'ger只出现在belligerent,congeries,gerund');
INSERT INTO `root` VALUES ('52', 'gnos', 'gnit,gniz', '0', 'to know', '知道', null);
INSERT INTO `root` VALUES ('53', 'grad', 'gress', '0', 'to step,step', '迈步,步', '分别具有动词和名词的含义');
INSERT INTO `root` VALUES ('54', 'gram(m)', 'graph', '0', 'written character', '书写符号,书写物', null);
INSERT INTO `root` VALUES ('55', 'grat', 'grac', '0', 'pleasing,thankful', '使人高兴的,感激的', null);
INSERT INTO `root` VALUES ('56', 'hab(it)', 'hibit', '0', 'to hold,have', '拥有，占有', null);
INSERT INTO `root` VALUES ('57', 'it', null, '0', 'to go', '走', null);
INSERT INTO `root` VALUES ('58', 'jac', 'ject', '0', 'to throw', '投掷', null);
INSERT INTO `root` VALUES ('59', 'junct', 'join', '0', 'to connect', '连接', null);
INSERT INTO `root` VALUES ('60', 'jur', 'just', '0', 'law,right', '法律，公正', 'jur做动词时意为to swear');
INSERT INTO `root` VALUES ('61', 'lat', null, '0', 'to carry,to bring,to bear', '拿,带，负担', '与词根fer同义');
INSERT INTO `root` VALUES ('62', 'leg', 'lig,lect', '0', 'to gather,to pick', '收集,挑选', null);
INSERT INTO `root` VALUES ('63', 'leg', 'legis', '0', 'law', '法律', null);
INSERT INTO `root` VALUES ('64', 'loc', null, '0', 'place', '地方', null);
INSERT INTO `root` VALUES ('65', 'log', 'logue', '0', 'speech,reason', '说话,推理', null);
INSERT INTO `root` VALUES ('66', 'loqu', 'locut', '0', 'to speak', '  讲', null);
INSERT INTO `root` VALUES ('67', 'lud', 'lus', '0', 'to play,mock', '玩,戏弄', null);
INSERT INTO `root` VALUES ('68', 'man(u)', null, '0', 'hand', '手', 'u为连接词');
INSERT INTO `root` VALUES ('69', 'mand', 'mend', '0', 'to entrust', '委托', '该词根为man(hand),dare(to give)的复合词，意为give sb one\'s hand，引申为委托');
INSERT INTO `root` VALUES ('70', 'medi', null, '0', 'middle', '中间', null);
INSERT INTO `root` VALUES ('71', 'min', null, '0', 'smaller,less', '较小，较少', null);
INSERT INTO `root` VALUES ('72', 'mit', 'miss', '0', 'to send', '发,送', null);
INSERT INTO `root` VALUES ('73', 'mod', null, '0', 'measure,manner', '度量,方式', '引申意:size，limit(限度)，method，manner等含义');
INSERT INTO `root` VALUES ('74', 'mont', 'mount', '0', 'hill，to climb', '山,攀登', null);
INSERT INTO `root` VALUES ('75', 'mort', null, '0', 'death', '死', null);
INSERT INTO `root` VALUES ('76', 'mov', 'mot,mob', '0', 'to move', '运动', null);
INSERT INTO `root` VALUES ('77', 'nasc', 'nat', '0', 'to be born', '出生', 'nasc一般只有nascent,renaissance这几个');
INSERT INTO `root` VALUES ('78', 'not', '', '0', 'to get to know', '知晓', null);
INSERT INTO `root` VALUES ('79', 'nounc', 'nunci', '0', 'to tell', '讲述', null);
INSERT INTO `root` VALUES ('80', 'ord(i)', '', '0', 'order', '顺序', null);
INSERT INTO `root` VALUES ('81', 'par', 'per', '0', 'to get ready', '准备', null);
INSERT INTO `root` VALUES ('82', 'part', '', '0', 'part,to part', '部分，分开', null);
INSERT INTO `root` VALUES ('83', 'pati', 'pass', '0', 'to suffer,endure,feeling', '忍受,感受', 'pati一般是忍受的意思，衍生词pass有感觉的意思');
INSERT INTO `root` VALUES ('84', 'patri', 'patern', '0', 'father,fatherland', '父亲,祖国', null);
INSERT INTO `root` VALUES ('85', 'ped', 'pod', '0', 'foot', '脚', null);
INSERT INTO `root` VALUES ('86', 'pel', 'puls', '0', 'to drive,push', '促使,推动', null);
INSERT INTO `root` VALUES ('87', 'pend', 'pens', '0', 'to hang,to weight,to pay', '悬挂,称量,支付', '来源古罗马 天平（悬挂）称重金银用于支付费用');
INSERT INTO `root` VALUES ('88', 'pet(it)', '', '0', 'to seek,strive', '寻求,追求', null);
INSERT INTO `root` VALUES ('89', 'ple(t)', 'plen', '0', 'to fill,full', '装满,充满', null);
INSERT INTO `root` VALUES ('90', 'plic', 'pli,ply', '0', 'to bend,fold', '弯,折', 'ply只能用于动词词尾');
INSERT INTO `root` VALUES ('91', 'polic', 'polis,polit', '0', 'city,citizen', '城市,市民', null);
INSERT INTO `root` VALUES ('92', 'pon', 'pos(it)', '0', 'to place,to put', '放置', null);
INSERT INTO `root` VALUES ('93', 'port(at)', '', '0', 'to carry', '拿,运', '与port无关,原意是山隘,大门');
INSERT INTO `root` VALUES ('94', 'prehend', 'prehens,pris', '0', 'to reize', '抓住', null);
INSERT INTO `root` VALUES ('95', 'press', '', '0', 'to press', '压', null);
INSERT INTO `root` VALUES ('96', 'prob', 'prov', '0', 'to test', '试验,验证', null);
INSERT INTO `root` VALUES ('97', 'quer', 'ques(i)t,quir,quisit', '0', 'to seek,ask for', '寻求,要求', null);
INSERT INTO `root` VALUES ('98', 'reg', 'rect', '0', 'to rule,to guide,to govern', '划直线,引导,治理', '意思中都包含正,直的概念');
INSERT INTO `root` VALUES ('99', 'rog(at)', '', '0', 'to ask', '询问', null);
INSERT INTO `root` VALUES ('100', 'rupt', '', '0', 'to break', '破', null);
INSERT INTO `root` VALUES ('101', 'sci', '', '0', 'to know', '知晓', null);
INSERT INTO `root` VALUES ('102', 'scrib', 'script', '0', 'to write', '写', null);
INSERT INTO `root` VALUES ('103', 'sect', '', '0', 'to cut', '切', null);
INSERT INTO `root` VALUES ('104', 'sent', 'sens', '0', 'to feel', '感觉', null);
INSERT INTO `root` VALUES ('105', 'sequ', 'secut', '0', 'to follow', '跟随', null);
INSERT INTO `root` VALUES ('106', 'serv', '', '0', 'to be a slave', '当奴仆', null);
INSERT INTO `root` VALUES ('107', 'sid', 'sess', '0', 'to sit,settle', '坐,停留', null);
INSERT INTO `root` VALUES ('108', 'sign', '', '0', 'mark,to mark', '记号,标记', null);
INSERT INTO `root` VALUES ('109', 'sist', '', '0', 'to stand', '站立', null);
INSERT INTO `root` VALUES ('110', 'solv', 'solut', '0', 'to loosen', '松开', null);
INSERT INTO `root` VALUES ('111', 'spec', 'spect,spic', '0', 'to look', '看', null);
INSERT INTO `root` VALUES ('112', 'spir', '', '0', 'to breathe', '呼吸', null);
INSERT INTO `root` VALUES ('113', 'st(at)', '', '0', 'to stand', '站立', 'sist意思也是to stand');
INSERT INTO `root` VALUES ('114', 'string', 'strict,strain,stress', '0', 'to draw tight or bind', '拉紧,捆绑', null);
INSERT INTO `root` VALUES ('115', 'stru', 'struct', '0', 'to pile up or build', '堆砌,建造', null);
INSERT INTO `root` VALUES ('116', 'tang', 'tact', '0', 'to touch', '接触', null);
INSERT INTO `root` VALUES ('117', 'ten', 'tin,tent,tain', '0', 'to hold', '握，持', null);
INSERT INTO `root` VALUES ('118', 'tend', 'tens,tent', '0', 'to stretch', '伸,延伸', null);
INSERT INTO `root` VALUES ('119', 'tract', '', '0', 'to draw', '拉,抽', null);
INSERT INTO `root` VALUES ('120', 'un(i)', '', '0', 'one', '一', '与词根un区别发音不同如unify');
INSERT INTO `root` VALUES ('121', 'val(u)', 'vail', '0', 'to be strong,effective,worth', '有力,有效,有价值', null);
INSERT INTO `root` VALUES ('122', 'ven', 'vent', '0', 'to come', '来,发生', null);
INSERT INTO `root` VALUES ('123', 'vert', 'vers', '0', 'to turn', '转', null);
INSERT INTO `root` VALUES ('124', 'vid', 'vis', '0', 'to see', '看见', null);
INSERT INTO `root` VALUES ('125', 'viv', 'vit', '0', 'to live,life', '活,生命', null);
INSERT INTO `root` VALUES ('126', 'voc', 'vok', '0', 'to call,voice', '喊叫,声音', null);
INSERT INTO `root` VALUES ('127', 'volv', 'volut', '0', 'to roll,turn', '滚动,转动', null);
