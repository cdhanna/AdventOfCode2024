namespace AdventOfCode2024;

public class Day3
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(Sample, 161)]
    [TestCase(Input, 191183308)]
    public void Part1(string inputStr, int expected)
    {
        var input = inputStr.AsSpan();
        var prefix = "mul(".AsSpan();
        var total = 0;
        for (var i = 0; i < input.Length; i++)
        {
            var section = input.Slice(i);
            var hasPrefix = section.StartsWith(prefix);
            if (!hasPrefix)
            {
                continue;
            }

            i += prefix.Length;
            // read until not a number 
            var j = i;
            var d = input[j];
            while (char.IsDigit(d) && j < input.Length)
            {
                j++;
                d = input[j];
            }
            
            // must be a comma
            if (j >= input.Length || ',' != d) continue;
            
            var numSpan = input.Slice(i, j - i);
            var numA = int.Parse(numSpan);

           
            
            i = j + 1;
            j = i;
            d = input[j];
            while (char.IsDigit(d) && j < input.Length)
            {
                j++;
                d = input[j];
            }
            
            // must be a close paren
            if (j >= input.Length || ')' != d) continue;
            
            numSpan = input.Slice(i, j - i);
            var numB = int.Parse(numSpan);

            var product = numA * numB;
            total += product;
        }
        
        Assert.That(expected, Is.EqualTo(total));
    }
    
    [TestCase(Sample2, 48)]
    [TestCase(Input, 92082041)]
    public void Part2(string inputStr, int expected)
    {
        var input = inputStr.AsSpan();
        var prefix = "mul(".AsSpan();
        var enablePrefix = "do()".AsSpan();
        var disablePrefix = "don't()".AsSpan();
        var total = 0;
        var enabled = true;
        for (var i = 0; i < input.Length; i++)
        {
            var section = input.Slice(i);
            var hasPrefix = section.StartsWith(prefix);
            if (section.StartsWith(enablePrefix))
            {
                enabled = true;
            }
            if (section.StartsWith(disablePrefix))
            {
                enabled = false;
            }
            if (!hasPrefix)
            {
                continue;
            }

            i += prefix.Length;
            // read until not a number 
            var j = i;
            var d = input[j];
            while (char.IsDigit(d) && j < input.Length)
            {
                j++;
                d = input[j];
            }
            
            // must be a comma
            if (j >= input.Length || ',' != d) continue;
            
            var numSpan = input.Slice(i, j - i);
            var numA = int.Parse(numSpan);

           
            
            i = j + 1;
            j = i;
            d = input[j];
            while (char.IsDigit(d) && j < input.Length)
            {
                j++;
                d = input[j];
            }
            
            // must be a close paren
            if (j >= input.Length || ')' != d) continue;
            
            numSpan = input.Slice(i, j - i);
            var numB = int.Parse(numSpan);

            var product = numA * numB;
            if (enabled)
                total += product;
        }
        
        Assert.That(expected, Is.EqualTo(total));
    }

    private const string Sample = @"xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
    private const string Sample2 = @"xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
    private const string Input =
        @"[why()what()]:!*<)~mul(929,350)({)when()@mul(878,389)}$!? mul(786,950)~when();[(#mul(808,160)mul(659,500)&+?*mul(659,863)~~&:;,>do()(%@from()^!how()how()'@mul(281,23)-^~mul(473,263)}&!?when()~mul(208,697)?^)from()}who()]-where()mul(975,727)?where()'who()&&]how()don't()]',{how())mul(862,420),mul(505,346)mul(150,525)@'~[-,]^who()mul(842,702)# where()who()/*/@-select()don't()what():when()when()how()[what()%(mul(669,360)>@!+&what() ^%mul(285,288)mul(778,743)why()!+?((^;mul(725,987)*where(491,873)+don't():how()what()'(mul(757,125)what()}/where()why()]@don't()select()}(/select()$$when()']mul(494,390)}-who()+mul(182,852)when()#*^mul(144,423))mul(250,580){what()%%where()* mul(870,438)from(431,933)' when()mul(965,381)why()how()@where()<what()what()$@&mul(124,500)(<mul(307,602)!mul(294,55)when()*mul(466,143)$when()+@why()-'what(60,159)@{mul(594,617)/%who()'why()!]who()+mul(590,187)$,,why()<>?from()mul(817,13)$;what(648,988)mul(25,13)[(do()why()when(916,672){?what()*'what())mul(469,12)&!([[how()where()mul(619,597)+]where()&{%)[+mul(734,721)^:&%how()[where()who();mul(725,524))mul(389,895)mul(166,39) )select():mul(655,784)where()]),]who()what()]:who()mul(353,573)>~%^< #what()}mul(522,78)*where()when()^$+&&mul(236,646)!-who()$>from()?%mul(376,189) $''@$ who()mul(300,957)[mul(83,888)mul(107,58)'*<mul(220,142)mul(526,112)$$*who()-{,' )mul(23,943)$who()^mul(338,718)(/'-mul(371,364)from()&)<}why()^ mul(856,727)from()#/mul(360,371)*;/$?#mul(664,647)@)how()[,+%)mul(607,641) *how()@mul(395,603)who()+-~^what()mul(909,984)from())select()what()why()^: #,mul(271,246)from()$$why()^!why()]~^mul(627,532)^(when()mul(229,147)select()+when()what()&from()$do()how()who()#who()mul(516,484)mul(897,791) ,]mul(975,824)from()mul(861,612);where()$why()%&from()%why()when()mul(467,971)*^what()%&$-%?mul(351,45)/mul(404,604)from(78,564)~:mul(821,895)@*<(mul(108,809)why(){^?how()where()who()%^mul(107,714)';who()'+:(*$mul(651,179)%&;mul(421,625)!select(67,621)$-: +mul(190,973) )+'what()how()mul(90what()mul(532,234)~**#?/:mul(178,924)<how():#where(),mul(258,345)(when())!select()}^,mul(590,995)mul(563,305)#)$?<['^what())mul(539,574)'#<&'$who()#mul(493,590)$who()what()mul(574,298)who()who()@:![mul(213,273),how()$from()who()select()why(){;&mulfrom()do() &$%how()[+mul(539,428);mul(289,634)mul(178,932),why()when()what() ^+select()>#mul(535,222)'mul(370,487)>{:::+);select()mul(228,11)mul(961,125)^select()mul(489,332)+/!^#where()select()mul(757,495)*don't();]who()how()mul(814,931)?)how()^^?$when()mul(669,252),]mul(69,754)when(),@select()when()^mul(316,878)how()']mul(772,418)!}why()(,who()mul(186,499){^[where()%$what() select()from()mul(711,645/^mul(517,805)&[why()&~mul(970,867)where()>mul[% select()who()/what() select()?select()mul(739,456)**mul(620,935)-%,where();,what()how() mul(715,502)+when()where()#>mul(635,908)why()what();:mul(30,139)<from()/%mul(832,717)where()!}mul(518,190)mul(760,645),what()<how()+mul(835,464)!'}mul(929,827)select():,'mul(838,387)when()~why()what()(from()#select()mul(147,945)how()+'[^]{&mul(325,147where()why();+^from(173,815)who(): mul(689,161)},$&#{mul(214,950)select()}why()^*mul(165,90)@where()?mul(996,995)'<#&don't()</why()]how()~ '%;mul(347,352)
[from()mul(564,902)mul(515,489)!when()mul*?*where()mul(676,277)mul(243,328)what():/+'mul(845,930)<{^&@why()from(378,555)>{/mul(696,341)$mul(178,75)$,&/]>:why()mul(531,586);;mul(639,746)~select();/$mul(501,62);]mul(796,439)>*<%where():~,*?mulfrom()+}*do()mul(766,409){mul(418,953)where();#from()select()$&what(178,382)mul(435,11)}[mul(398,68!&-<@:<why()where()*'mul(756,293)^where()!&mul(598,25)do()~mul(483,67)mul(116,813))}*@don't()mul(807,2);[-{<!!~@)mul(982,63)how()/*;?[!mul(292,746)where()'!&*mul(20,251)mul(258,348)*mul(570,47)what(720,953){}who())#^:)mul(932,524)how()-mul(939,325)!$mul(174,638)~why(588,329);mul(180,359)mul(627,164)mul(445,389)</why()[where()mul(115,522)mul(516,970)+mul(750,179)mul(393,378)'/][[-mul(400,355)[-}+[mul}*%!:~'^mul(606,611)-why()--<(  mul(637,439>$mul(628,277)mul(570,862)>]what()?<'$mul(624,957)^]mul(946,45)[~why()[from()) ?do()>how(),{+}from()mul(687,919)]why()who()who()how()<%mul(839,726)#*-'@>(~>mul(588,167)@%@when()why()when() #mul(503,12)select() %!;[don't()when(){-]%why()!%+:mul(55,105)@what())mul(349,994)}who()where(424,307)}from()what()mul(991,980)mul(313,17)where()*[+%from()&how()-;mul(118,53)~<!why()from():mul(914,345'[~}mul(276,699)how()who()):how()mul(238,673)$:{}(~mul(840,690why()from()who(){>why()^@from()-mul(40,718)'&why()mul(393,507)why()[-:,mul(715,497)- @<;#)?mul(450,459)select()~$&mul(570,625)what()mul(944,195)select()what()+%where()where() /-,mul(203,571)(+why()[(#^who()~mul*where(),why()~~why()'@mul(469,314)mul(839,867)mul(607,678)'do()*when()<?{mul~~{/$^{#^how()$mul(733,382){/select()~%mul(450,74)what()%'}where()from()select()%mul(139,672)/,%*)*mul}{*how()[mul(466,481)]'@/}+%how()-mul(474,988),mul(431,193),mul(587,948)when()~/'mul(871,567)!?from()select(177,40)}how()when()mul(974,456)]<)select()]><mul(292,269)why()-),mul(507,563)!how()&'from():mul(875$[+select();~+mul(243,139)#when()$when()[:mul(212,698)}where()#^)'when()what();mul(40,183)what();{]where()how()+where()mul(362,950)#select()mul(618,187)(mul(504,988)?'/ who()+select()where()mul(236,898)<~>:>?mul(285,955)what()/}when(){-why()mul(358,393)>@[where()(who()mul(676,462)&]why()&how())mul(872,847@+#:mul(274,134){/how(53,761)>mul(895,912)why()!*>^-]why()what()don't()/)mul(219,961)where()how()[^~'-<mul(481,864)why()who(598,406))where()~][~mul(392,606)why(122,687)'(when()@^mul(920,948)@what()where()select()%,??select()]mul(629,795)mul(645,709)'-from()where()why()>^{when()mul(177>&,,'}from(),what()mul(314,86) ]{mul(74,407)<mul(593,327)[select()mul(411,974)>how()]!;(}don't()how())mul(395,998)]select(415,991){<mul(491)<!'[~/;'what()mul(989,530)mul~$who()/'+% mul(15,199))'where()when()mul(816,920)$why(317,997){ , /&mul(551,278)?;,'$@who()where()[}don't()@select()):who()how()mul(863,732)~];^]who()%}from()where()mul(223,748)from()when()where()'+/where()what()]~mul(474,54)what(){}(~[-mul(284,25)[&>do()'who(),];},mul(374,334),!)who()(;}^{}mul(343,209)/what()[+ [{mul(952,521) [?[}:mul(264,303)where()*~where()*'mul(984,690):@@]mul(979,762)from()!(/why(976,660)who() mul(387,945)mul(885,520)$when()%who()&mul(950,716)[)when(84,652)who()/&~^-don't()?$from()mul(712,945)# why()&<}<why()]>mul(83,500)?]:/mul(567,822)how()<mul(877,379)-when()where()mul(396>?why(515,831)&[<[^mul(503,349)
!*<,){$?'select()don't()what()%,(!~mul(961,381)select()*%why() when()#$)mul(380,949)~$what(428,872)how()?&'+mul(261,613)what()what()!'<what()how(),&mul(967,970),$-/*<~mul(587,914)]mul(753,127)}~^/;()>]'mul(292,235) select()from()@who()?^what()mul(383,544):[mul(272,707)>(what()mul(735,912)}>when()select()select() {mul(62,107)/]select()mul(713,534)); #+/@?&/mul(572,504))&)>who(951,467),{*^&mul(31,687){mul(313,607)><,what(496,388) ]why(521,85)(mul(690,876))::'@<where()mul(273,373)%/mul(843why()%*)&/@[,?why()mul(531,235)mul(111,213)where()~who()/+mul(189,15)-%~why()@'mul(964,850)[why()who()who():$&-where()do()why(){when()mul(434,480);from())mul(579,808)+[ ~ $ when()mul(856,871):[^,when()what()how()mul(191[;(mul(900,159)how()-,from()()do();who()');-!>why()who()mul(596,341)<,mul(455,990)<{mul(497,180)when()select()@ -mul(613,543)don't(){what()~[where()] ,^mul(333,124){where()where()>!:mul(545,512)why()(mul(561,668)what()%^/(mul(478,75)@where()mul(329,992)$from(): ,*mul(866(}*)why(),mul(241,743);@select()+>?how()}mul(844,735)how()>select(){^{from(){do()mul(966,882)how(){!<*'select()'!!mul(987,455)#~mul(515,519)&when(896,529)how()mul(631,876from()+what())do()what(){who()+(;'from()!mul(426,523)[why()-<&!,mul(460,572)&what()&/~/mul@what()&select()+who()$mul(243,403)mul(632,748)@#%@why() when()[))mul(17,783)}mul(713,921)+<>@how()~&who()why(274,888) mul(271,938)^]'!why()mul(511,239)$+when()^@>>mul(97,300)!who()when(841,168)$#!:don't()select(){how()>where()+who()*mul(237,42)how()how()mul(241,881)why()^^select()&when()#[;&mul(907,680)mul(984,346)^!}don't()[*>mul(210,168):[]~?/;~mul(936,602)do()}!(,!^*what(){*mul(818,741)^/]$}#when() don't()what()mul(675,247+{+:from(596,382)what()&#mul(545,450){how(536,664)({@,-/+mul(844,400)^%when()#~from()how()%+mul(178,299)mul(47,387)];}-,mul(73,974)#+;~['mul(722,711)why()when()<*&select()mul(662,195)%mul(928,541)why()}^select()select()mul/mul(875,585)when()when(999,528)<why(),;mul(699,625))^!mul(207,213)how() {#>[mul(604,342);[@<,:when()who()mul(620,728) :}what()mul(135,593)}when())):*;'who()%mul(453,733)#^'- '}[])mul(645,243)who()@^?when()>mul(625,242&>(/@*?${{~mul(407,983)#% ^* mul(932,718);who()~$mulwhen()how() mul(88,59)?where()@}~-mul(123,691):>^[/what()mul(744,809)+){!?- '*mul(213,965)'when()-why()how()mul(477,506)@who()mul(701,848)when()%~where()>^mul(165,63))*}$,#mul(399,533)from()when(){$ do()from()^,,}[when()mul(704,3)]mul(694,548)what()mul(900,108)mul(774,475)[where()<%why()what()~$^mul(883,579)~when()&%/mul(923,647)where()$^where()</where(464,139)/who(){mul(17,805)select(),mul(326,383)select()$mul(987,354)mul(639,894)}who()#mul(960,252)@%^:#mul(445 when()/who()why();mul(609,294)*,'why()why()who()where()<)when()don't()-<?{%where()where()[^mul(950,349){mul(290,391){(mul(109,772)when()/do()*mul(335,149)'~~<]'-}who()?mul(171,887)%-why()$from()?>?*mul(807,659)when()]*@(+mul}when(76,45)//'when()%mul(222,35)}:%:mul(671,994)how()who()do()}from()mul(172,811)>{ ?how();?why()*don't()?what()what(771,976)^why()}mul(76,532)@%(>}mul(256,283)(/$,]from()]^[!mul-)%%%,@&mul(882,66)^where()&[when()do()when()/why()&^~mul(727,37)'%how()why();,';;-mul(535%~&select()mul(753,604)mul(442,703)#from()#mul(451,658)mul(690,961)[^+<}%^mul(409,762)!'mul(785,505)/$who()&:;%$;%mul(181,733)*+when()$#+select()mul(295,726)*@,do()?#*<,where(650,5):why()<mul/'&{!who()why()from(136,768)select()&mul(261,933)mul(265,684)@:-what(552,176)(:]#!/usr/bin/perl{-$mul(912,21)
^^<from()~mul(453,52)<when()'mul(566,994)why()mul(300,902)]'{what(587,168)who()mul(136,86))% %# what()}mul(491,28)%mul(267,97)mul(901,797)what())<)what()why()mul(194,422who()select()]}%%';%who()who()mul(11,309)what()>  what():^where()mul(869,48)&?<*mul(342,192)from()@who()why()who()*mul(230,176)'mul(587,59)[~'/when()](mul(979,301)+:,mul(651,625)mul(325,740?'#&??when()@*;^do()when(),~}who()%$^mul(564,586)where()$mul(686,200)};{%mul(666,187)>'?)/$$mul(337,903when(),why(){*@)-select()*/mul(788,793)];how()!({where()@*who()mul(787,265)?(^/[#-)where()[mul(111,927)*mul(27,304)+{)when()%+-#mul(176,110)who(588,615)mulwhen(506,316)@]?(&@}' ,mul(358,826)~who()mul(501,531)mul(365,143)<^[who(677,182)mul(759,671)from()why()[*what()+mul(679,332){?*mul(817,808)?({how()when(556,48),from()}{mul(90,989)-mul(503,769);:#(]'how()'$:mul(859,40)how(597,760)-]~what()why(),;mul(638,143)}what()],!]]mul(428,646)mul(353,573when();<from()from(952,541)mul(320,540)<*;do()mul(687,955)when(629,249)when()mul(602,820)%^}select()[mul(662,858)from()how(923,259)( mul(743,736%}>,mul(691,924)[from(),~ mul(875,629)(~%;+#]select()mul(338,859)?{where()}+what()/what()when()$mul(375,365)<+^}where()&mul(336,223)?:~who()/:(<mul(178,250)>what(501,622)?@how()*why()select()mul(984,814)?who()mul(808,237)mul(194,593)(^/~!mul(795,480)/!mul(749,71)mul(934,601)'mul(807,763)?]from()when();mul(515,591))who()where()what()$+from()[><mul(499,662),~select()<where()^mul(817,451)'mul(306,889)?~@':@}mul(467why()who()}^what()%{>mul(911,440)$&>($when(52,661))]from();mul(886,109)from()%don't()how() &from()mul(915,528)!;]who()mul(144,716)*%where()what()[mul(376,205) ?who()mul(274,491)mul(671,696))mulhow()]mul(375,359){*:~(mul(956,842)do()!?select() &(]}where()mul(618,693)how(105,340)when()*:+<^>&mul(761,859)]from()}>why()'mul(542,515)mul(462,546)^mul(660,240)what()]/:how()mul(609,298)**%when()(,mul(279,293)when()+%(;(%^^mul(392,795)?@-%])don't();how()-+when()<+mul(128,643)}!*}^}'}]-don't() mul(930,403)<!%'^'~{?[mul(933,726)}>when()when(){<^*why()mul(11,788)>]-how()',?who()mul(442,615)from()(from()(#{?$(]mul(654,462),,#~);'/mul(960,246)select()mul(111,461)mulfrom()(~,where()mul(641,83):#{'*(from()mul(759,794)what()//+:*mul:;mul(543,856)mul(602,732)^mul(124,738)%),[~$mul(378,18)]/when()&~mul(723,701):-{why()+where()*what()$&mul(633,998)select()+when(562,500)mul(833,630)why()how()where()from(799,941)mul-<@-!^mul(945,843)}}-*^#mul(705,202)%]'how()&]what()~who()/mul(616,696)*mul(163,194)what()&mul(941,303)'}what()^ #'&mul(924,715)from()<from()<&do()]$?(@+mul(267,485)%,~>>@^{mul(526,75)&what()!@!{what()mul(248,994)$select(253,838)~)~mulselect()&^;^]where()mul(985,752)mul(275,971)@where()[mul(592,347)mul(209);:!when()who()$/mul(17,702)&{#!who()mul(800,427)-$&mul(939,888)~#when()where()']<}]<mul(143,267)]~what()}} +mul(681,583)/mul(656,683)[where(492,186)where()from()'how()}&-mul(320,914)~select(459,90)who()mul(345,44)why()%mul(720,338)})+(,#/mul(265,100)&*;mul(677,183)how(){when()what()from()mul(238,545 +/mul(525,84)select()*+mul^why())#:;#%,)mul(876,21)~)(from()what()/$* mul(344,65)select()-^what()<how()}don't()mul(548,676)/>?who()mul[,mul(833,540)~-^#when()@{^(>mul(946,450)
who()mul(242when(101,870))>@mul(753,627) @:select()who(406,895)'%do();who()%mul(361,888)why()!%how()mul(700,949)$mul(180,872)(*#(mulhow()mul(882,985)(+?mul(351,704)[)how()#how()mul(764,860)!who(404,988)from()mul(993,557){,why()>who()mul(56,860)what()[/mul(347,909)}{mul(699,230)?~%why()-:why()>?mul(445,473)mul(267,398)'~mul(650,363)*what(){*?{where(){}>mul(601,997)> where() mul(497,753)select(){when(868,294)mul(141,967)how()who()$mul!what()!~who()}who():mul(36,947)where()mul(681,450)mul(240,143)mul(444,949)?don't()>*^ where():mul(497,86)mul(430,567)]}%!mul(193,883)?mul(910,491&mul(689,168)what()<;~mul(29,977)~^?~&select()<~]mul(205,284)mul-**&,!{mul(737,674)}, ;mul(12,767)<[when(422,261)where(),})'$mul(532,879)who()mul(397what(941,622)/mul(765,185)who() mul(798,105)'&(/who()mul(332,180);when(757,619)how()<when()?what()don't()^#]why()]:/mul(392,698)what()when()/]+(:how(61,243)&<mul(436,468)^$]')*>mul(505,995)>*[({;^}#mul(890,215)%]%{-mul(908,576)when()[;mul(714,969)>+&]~? {@mul(60,591)>$mul(792,423)where()@what(114,480){^ -$mul(354,440)(-mul(713,525)where(784,906)#^}^[}mul(305,922)how(){: ~}<>}}mul(448,877)'!mul(751,305)!%don't()mul(179,695)? ?}how()mul(841,995)~when()from()&>[mul(353,537)}]+;mul(501,394)^{/^^ />mul(999,635)!$;,how()?$%~mul(605,217);[?how()#from()mul(936,501)select()from()'{~from() />don't():how()/>:select()mul(246,594)from(358,782),[)~mul(256,918)$(}where()}how()mul(370,832)&why()mul(925,451)<mul(743,528) -select()-!)mul(917,739]^{who()&<who()from()+mul(815,611)-}{mul(893,272)~who()don't()@{?%{+)@?from(566,346)mul(322when()(what()mul(687,268)[what()mul(463,899)from()#:%^mul(56,377)([%mul(260,934)mul(945,828)+]where()-(mul(609,15)&mul(287,981)--who()-mul(452,70)),mul(836,664)$>mul(47,536)%$]@mul(694,750)#who()mul(604,542):%(how(){<why()mul(632,9)who()what()@mul(879,873)(,from()};mul(632,382){mul(747,827)'';why()[from()*]!mul(697,54),#-<when()why(461,16)]{&?mul(248,435)mul(258,340)}mul(499,391)who()@^mul(409,16)'<why()%'select(154,997)mul(787,500))why(){when()#$mul(643,861)]!] :#mul(562,129)mul(577,258)- when()(when()/}how()from()'mul(15,451)}what()what()?,select()mul(981,70)-'{mul(722,521)'what();*mul(123,277)]+'%^why()mul(213,164{why()select()do()mul(900,548)('mul(148,194)who()mul(62,852)<:mul(61,450) *:{/@'&:@mul(131,406)) '(do()how():/,^$}?mul(909,412)>mul(972,130)@}what()$mul(222,940)));(*!)(%}mul(455,452)@&mul(8,457)how(){from()?how()'from(),]^mul(965,893)why()/-!+&^what()-mul(787,423)what(){where(959,674):who()]?mul(963,475)}~where():mul(81,905)$select()how()(@mul(465,909)-$select(849,483)?mul(534,596)why()->mul(196,18)select()+%mul(27,285)where()?why(){mul(664,943)$(who()%*mul(813,372)*~+&@('{how()mul(834,380)$/how(),why()}:#@*mul(813,509)^)from();*mul(545,292)%select()when(353,207)<mul(708,344)*when()mul(342,781)[select()from(950,341)what()]how()~;$mul(117,146)select()+~who()what()@%>where()mul(767,38)]mul(24,562)
how()[[)&?&:mul(218,640)]who()^{mul(108,530)*+}}~<;-mul(179,490)}'+how()~%$mul(33,386)~when(694,12)(&where()}}~'mul(459&why()do()*:@+<<}mul(19,511)do()(mul(541,350)&!,mul(387,141)< <what()from()*mul(238,338)~ ^^what()'#~%mul(772,919)when()#:do()from()>{how(921,168) $}mul(429,335))do()mul(806,883):from(853,895)from()do()[select()+*mul(175,190)+mul(682,133){+'[mul(846,821)]%}@)&mul(116,347)who()/'<~mul(924,51)$,when()>(from()!mul(209,245)(@'where()select()?]/mul(460,178)-/why(825,431)!do()what()<how()mul(517,419):{~,-;!&mul(631,707who()/&)]+;where():)mul(68,998)when(){~how()where()from(622,385)!)!mul(587,990)-[ ^>{!mul(765,879)&&mul(798,713)where()who()from()~mul(739,10)%] :>-when()]mul(131,912)?{ {$>?why()$+mul(825,581)what()mul(905,252)&when()>,%}'%-what()don't()~$where())?when()?from(968,779)mul(863,782)^$<mul(631,509)$mul(930,251)?~!+'what()+(<select()mul(204,65)mul(231,133)$why()^%mul(332,786)why()!~;who()[from()mul(726,913)/from()mul(484,642):(!when()/what():#(?mul(590,989),{what()&who()~mul(879,143)!{{-;why() ]:where()don't()-~>;:[!~what()mul(498,143)what()!*why()mul(347,195)#/mul(930,586)-/select()*:{mul(439,475>^from() )^>>^)why()mul(453,205)when()?[mul(75,857)[when()~how())who(){when()^+mul(201,137)>why():!+who(645,81)[why()mul(861,373):!when()*how()?'?;mul(410,947)what()%^[>mul(106,316)> ^(where()~select()where()what()mul(296,671)%select()&+{]*-when()mul(481,274) '$mul(929,179)&'&+ +~/%mul(29,898){^+{^/mul(580,352)when()from()]mul(585,530)*'mul(638,910)&/:^don't()->&!mul(894,636)when()*when()mul(577,671)}/~ <],$mul(999,788)/how()!;mul(574,638)-where()!^mul(66,674)/}mul(937,514)do()([*,+@(who()*;mul(750,907)^why()what()[*>mul(303,172)*why();how()+@}:;]mul(15,812)where()-:where()~mul(673,466)+{$'%mul(623,971)[select()don't()mul(7,739)!&,)'who()%'mul(509,601))select() do()select()mul(36,79)mul(199,611)mul(983,700)@;?@how()why()mul(136,594)[+%}how()mul(34,407)[where()^!when()don't()~how()(@mul(71,117){#?mul(857,810),>[when()mul(993,232)what()why() when()~+${mul(103,182)>-from()<select(762,467)how() *<mul(607,926)mul(606,36)$>from(),mul(756,418)):what()'~from()select()mul(833,12)<#why()~$ ,mul(74,614):from()% @{]from()+:mul(120,343)mul(714,187)why():mul(379,724)^select()-$-?$who()~who()mul(5,213))(,?]mul(151,375))^$:;@:mul(34,537)${&!-#,[mul(289,643)what()why()>select()select()mul(938,238)+mul(32,613)mul(415,379)[,<~$$don't()mul(272,584)?-]&mul(164,981),>+how(623,296)<select()who()%(where(396,349)mul(37,177)[)mul(527,858)~*<?select()&&#+:mul(411,460)*%<@>!{+mul(628,434)why()how()(who()~-($how()mul(912,947)}mul(279,831)where()(++select()+]#mul(916,868)}+>^-from()@mul(834,585)!]@what()select()+#)/mul(722,165)from()what()mul(220,639)^[[{$mul(738,370)$who()who()<</ > >mul(650,822)),/<,?when()mul(387,845)#from()&where()what(){mul(921,764)?from()from()do()>(;%~'mul(323,507)&}&#why()when()who()mul(998,500)select()[mul(543,802)from(){&?*/mul(809,888)+',%[&when()$mul(909,660)do(),:;)&>mul(303,499)when()!where(){%what()#mul(176,667)&*mul(789,667)}*when()/;how()*when()mul(181,142)how()what()";
}