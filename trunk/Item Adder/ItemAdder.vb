Option Explicit On
Imports System.Net
Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Xml
Imports System.Threading


Public Class ItemAdder
    Dim info As Integer
    Dim itemtype As Boolean = False
    Dim fileinfo As String
    Private arrRealmlist As New ArrayList()
    Dim thequery As String
    Private arcQuery As String
    Dim aspquery As String
    Dim trinquery As String
    Dim mangoquery As String
    Dim entry = 0
    Dim classs = 0
    Dim subclass = 0
    Dim field4 = 0
    Dim name1 As String = 0
    Dim name2 = 0
    Dim name3 = 0
    Dim name4 = 0
    Dim displayid = 0
    Dim quality = 0
    Dim buycount = 1
    Dim flags = 0
    Dim faction = 0
    Dim buyprice = 0
    Dim sellprice = 0
    Dim inventorytype = 0
    Dim allowableclass = 0
    Dim allowablerace = 0
    Dim itemlevel = 0
    Dim requiredlevel = 0
    Dim RequiredSkill = 0
    Dim RequiredSkillRank = 0
    Dim RequiredSpell = 0
    Dim RequiredPlayerRank1 = 0
    Dim RequiredPlayerRank2 = 0
    Dim RequiredFaction = 0
    Dim RequiredFactionStanding = 0
    Dim RequiredReputationRank = 0
    Dim Unique = 0
    Dim rangedmodrange = 0
    Dim maxcount = 0
    Dim ContainerSlots = 0
    Dim itemstatscount = 0
    Dim stat_type1 = 0
    Dim stat_value1 = 0
    Dim stat_type2 = 0
    Dim stat_value2 = 0
    Dim stat_type3 = 0
    Dim stat_value3 = 0
    Dim stat_type4 = 0
    Dim stat_value4 = 0
    Dim stat_type5 = 0
    Dim stat_value5 = 0
    Dim stat_type6 = 0
    Dim stat_value6 = 0
    Dim stat_type7 = 0
    Dim stat_value7 = 0
    Dim stat_type8 = 0
    Dim stat_value8 = 0
    Dim stat_type9 = 0
    Dim stat_value9 = 0
    Dim stat_type10 = 0
    Dim stat_value10 = 0
    Dim ScalingStatsEntry = 0
    Dim ScalingStatsFlags = 0
    Dim dmg_min1 = 0
    Dim dmg_max1 = 0
    Dim dmg_type1 = 0
    Dim dmg_min2 = 0
    Dim dmg_max2 = 0
    Dim dmg_type2 = 0
    Dim armor = 0
    Dim holy_res = 0
    Dim fire_res = 0
    Dim nature_res = 0
    Dim frost_res = 0
    Dim shadow_res = 0
    Dim arcane_resist = 0
    Dim delay = 0
    Dim ammo_type = 0
    Dim spellid_1 = 0
    Dim spelltrigger_1 = 0
    Dim spellcharges_1 = 0
    Dim spellcooldown_1 = 0
    Dim spellcategory_1 = 0
    Dim spellcategorycooldown_1 = 0
    Dim spellid_2 = 0
    Dim spelltrigger_2 = 0
    Dim spellcharges_2 = 0
    Dim spellcooldown_2 = 0
    Dim spellcategory_2 = 0
    Dim spellcategorycooldown_2 = 0
    Dim spellid_3 = 0
    Dim spelltrigger_3 = 0
    Dim spellcharges_3 = 0
    Dim spellcooldown_3 = 0
    Dim spellcategory_3 = 0
    Dim spellcategorycooldown_3 = 0
    Dim spellid_4 = 0
    Dim spelltrigger_4 = 0
    Dim spellcharges_4 = 0
    Dim spellcooldown_4 = 0
    Dim spellcategory_4 = 0
    Dim spellcategorycooldown_4 = 0
    Dim spellid_5 = 0
    Dim spelltrigger_5 = 0
    Dim spellcharges_5 = 0
    Dim spellcooldown_5 = 0
    Dim spellcategory_5 = 0
    Dim spellcategorycooldown_5 = 0
    Dim bonding = 0
    Dim description = 0
    Dim pageid = 0
    Dim page_language = 0
    Dim page_material = 0
    Dim quest_id = 0
    Dim lock_id = 0
    Dim lock_material = 0
    Dim sheathid = 0
    Dim randomprop = 0
    Dim randomsuffix = 0
    Dim block = 0
    Dim itemset = 0
    Dim MaxDurability = 0
    Dim ZoneNameID = 0
    Dim mapid = 0
    Dim bagfamily = 0
    Dim TotemCategory = 0
    Dim socket_color_1 = 0
    Dim unk201_3 = 0
    Dim socket_color_2 = 0
    Dim unk201_5 = 0
    Dim socket_color_3 = 0
    Dim unk201_7 = 0
    Dim socket_bonus = 0
    Dim GemProperties = 0
    Dim ReqDisenchantSkill = 0
    Dim ArmorDamageModifier = 0
    Dim duration
    Dim ItemLimitCategoryID
    Dim itemid As String
    Dim itemxml As String = ("http://wow.allakhazam.com/cluster/item-xml.pl?witem=" + itemid)
    Dim itemicon As String
    Dim x As Integer
    Dim y As Integer
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    Dim banstatus As Boolean = False
    Dim Connection As New MySqlConnection("server=" & My.Settings.host & ";user id=" & My.Settings.username & "; password=" & My.Settings.password & "; port=" & My.Settings.port & "; database=" & My.Settings.db & "; pooling=false")
    Dim Query As MySqlCommand
    Dim Execute As MySqlCommand
    Dim Reader As MySqlDataReader = Nothing
    Dim Reader2 As MySqlDataReader = Nothing
    Dim reloaditemid As Integer = Nothing
    Dim singleitemstatus As Integer
    Dim firstcheck As Boolean = True


    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Delegate Sub SetTextDel(ByVal Label As Label, ByVal Text As String)

    Private Sub SetText(ByVal Label As Label, ByVal Text As String)
        If Label.InvokeRequired Then
            Label.Invoke(New SetTextDel(AddressOf SetText), New Object() {Label, Text})
        Else
            Label.Text = Text
        End If
    End Sub

    Private Delegate Sub SetColorDel(ByVal Label As Label, ByVal Text As String)

    Private Sub SetColor(ByVal Label As Label, ByVal ForeColor As String)
        If Label.InvokeRequired Then
            Label.Invoke(New SetColorDel(AddressOf SetColor), New Object() {Label, ForeColor})
        Else
            Label.Text = Text
        End If
    End Sub

    Private Delegate Sub SetVisibleDel(ByVal Label As Label, ByVal Visible As Boolean)

    Private Sub SetVisible(ByVal Label As Label, ByVal Visible As Boolean)
        If Label.InvokeRequired Then
            Label.Invoke(New SetVisibleDel(AddressOf SetVisible), New Object() {Label, Visible})
        Else
            Label.Visible = Visible
        End If
    End Sub

    Public Sub nodelist()
        Try
            Dim m_xmld As XmlDocument
            Dim m_node As XmlNode
            Dim m_nodelist As XmlNodeList

            m_xmld = New XmlDocument()
            m_xmld.Load("http://wow.allakhazam.com/cluster/item-xml.pl?witem=" & itemid)
            m_nodelist = m_xmld.SelectNodes("/wowitem")

            For Each m_node In m_nodelist
                arcane_resist = m_node.ChildNodes.Item(0).InnerText
                armor = m_node.ChildNodes.Item(1).InnerText
                bonding = m_node.ChildNodes.Item(2).InnerText
                block = m_node.ChildNodes.Item(3).InnerText
                sellprice = m_node.ChildNodes.Item(4).InnerText
                spellcharges_1 = m_node.ChildNodes.Item(5).InnerText
                spellcharges_2 = m_node.ChildNodes.Item(6).InnerText
                spellcharges_3 = m_node.ChildNodes.Item(7).InnerText
                allowableclass = m_node.ChildNodes.Item(8).InnerText
                description = m_node.ChildNodes.Item(12).InnerText
                displayid = m_node.ChildNodes.Item(20).InnerText
                dmg_max1 = m_node.ChildNodes.Item(21).InnerText
                dmg_max2 = m_node.ChildNodes.Item(22).InnerText
                dmg_min1 = m_node.ChildNodes.Item(24).InnerText
                dmg_min2 = m_node.ChildNodes.Item(25).InnerText
                dmg_type1 = m_node.ChildNodes.Item(27).InnerText
                dmg_type2 = m_node.ChildNodes.Item(28).InnerText
                fire_res = m_node.ChildNodes.Item(31).InnerText
                flags = m_node.ChildNodes.Item(33).InnerText
                frost_res = m_node.ChildNodes.Item(34).InnerText
                GemProperties = m_node.ChildNodes.Item(35).InnerText
                holy_res = m_node.ChildNodes.Item(36).InnerText
                itemicon = m_node.ChildNodes.Item(37).InnerText
                entry = m_node.ChildNodes.Item(38).InnerText
                classs = m_node.ChildNodes.Item(48).InnerText
                subclass = m_node.ChildNodes.Item(50).InnerText
                itemlevel = m_node.ChildNodes.Item(51).InnerText
                requiredlevel = m_node.ChildNodes.Item(53).InnerText
                name1 = m_node.ChildNodes.Item(54).InnerText
                name2 = m_node.ChildNodes.Item(55).InnerText
                name3 = m_node.ChildNodes.Item(56).InnerText
                name4 = m_node.ChildNodes.Item(57).InnerText
                nature_res = m_node.ChildNodes.Item(58).InnerText
                quality = m_node.ChildNodes.Item(62).InnerText
                allowablerace = m_node.ChildNodes.Item(63).InnerText
                randomprop = m_node.ChildNodes.Item(65).InnerText
                randomsuffix = m_node.ChildNodes.Item(64).InnerText
                RequiredSkill = m_node.ChildNodes.Item(67).InnerText
                RequiredSkillRank = m_node.ChildNodes.Item(66).InnerText
                RequiredSpell = m_node.ChildNodes.Item(68).InnerText
                RequiredFaction = m_node.ChildNodes.Item(69).InnerText
                RequiredFactionStanding = m_node.ChildNodes.Item(70).InnerText
                RequiredPlayerRank1 = m_node.ChildNodes.Item(71).InnerText
                buyprice = m_node.ChildNodes.Item(72).InnerText
                itemset = m_node.ChildNodes.Item(73).InnerText
                shadow_res = m_node.ChildNodes.Item(74).InnerText
                inventorytype = m_node.ChildNodes.Item(75).InnerText
                ContainerSlots = m_node.ChildNodes.Item(76).InnerText
                socket_color_1 = m_node.ChildNodes.Item(77).InnerText
                unk201_3 = 0
                socket_color_2 = m_node.ChildNodes.Item(78).InnerText
                unk201_5 = 0
                socket_color_3 = m_node.ChildNodes.Item(79).InnerText
                unk201_7 = 0
                socket_bonus = m_node.ChildNodes.Item(80).InnerText
                field4 = -1
                RequiredPlayerRank2 = 0
                delay = m_node.ChildNodes.Item(82).InnerText
                spelltrigger_1 = m_node.ChildNodes.Item(83).InnerText
                spelltrigger_2 = m_node.ChildNodes.Item(84).InnerText
                spelltrigger_3 = m_node.ChildNodes.Item(85).InnerText
                spellcooldown_1 = m_node.ChildNodes.Item(86).InnerText
                spellcooldown_2 = m_node.ChildNodes.Item(87).InnerText
                spellcooldown_3 = m_node.ChildNodes.Item(88).InnerText
                spellcategory_1 = m_node.ChildNodes.Item(89).InnerText
                spellcategory_2 = m_node.ChildNodes.Item(90).InnerText
                spellcategory_3 = m_node.ChildNodes.Item(91).InnerText
                spellcategorycooldown_1 = m_node.ChildNodes.Item(92).InnerText
                spellcategorycooldown_2 = m_node.ChildNodes.Item(93).InnerText
                spellcategorycooldown_3 = m_node.ChildNodes.Item(94).InnerText
                spellid_4 = 0
                spelltrigger_4 = 0
                spellcharges_4 = 0
                spellcooldown_4 = 0
                spellcategory_4 = 0
                spellcategorycooldown_4 = 0
                spellid_5 = 0
                spelltrigger_5 = 0
                spellcharges_5 = 0
                spellcooldown_5 = 0
                spellcategory_5 = 0
                spellcategorycooldown_5 = 0
                spellid_1 = m_node.ChildNodes.Item(95).InnerText
                spellid_2 = m_node.ChildNodes.Item(96).InnerText
                spellid_3 = m_node.ChildNodes.Item(97).InnerText
                maxcount = m_node.ChildNodes.Item(98).InnerText
                quest_id = m_node.ChildNodes.Item(99).InnerText
                stat_type10 = m_node.ChildNodes.Item(100).InnerText
                stat_value10 = m_node.ChildNodes.Item(101).InnerText
                stat_type1 = m_node.ChildNodes.Item(102).InnerText
                stat_value1 = m_node.ChildNodes.Item(103).InnerText
                stat_type2 = m_node.ChildNodes.Item(104).InnerText
                stat_value2 = m_node.ChildNodes.Item(105).InnerText
                stat_type3 = m_node.ChildNodes.Item(106).InnerText
                stat_value3 = m_node.ChildNodes.Item(107).InnerText
                stat_type4 = m_node.ChildNodes.Item(108).InnerText
                stat_value4 = m_node.ChildNodes.Item(109).InnerText
                stat_type5 = m_node.ChildNodes.Item(110).InnerText
                stat_value5 = m_node.ChildNodes.Item(111).InnerText
                stat_type6 = m_node.ChildNodes.Item(112).InnerText
                stat_value6 = m_node.ChildNodes.Item(113).InnerText
                stat_type7 = m_node.ChildNodes.Item(114).InnerText
                stat_value7 = m_node.ChildNodes.Item(115).InnerText
                stat_type8 = m_node.ChildNodes.Item(116).InnerText
                stat_value8 = m_node.ChildNodes.Item(117).InnerText
                stat_type9 = m_node.ChildNodes.Item(118).InnerText
                stat_value9 = m_node.ChildNodes.Item(119).InnerText
                itemstatscount = m_node.ChildNodes.Item(120).InnerText
                TotemCategory = m_node.ChildNodes.Item(122).InnerText
                Unique = m_node.ChildNodes.Item(125).InnerText
                rangedmodrange = 100
                ScalingStatsEntry = 0
                ScalingStatsFlags = 0
                ammo_type = m_node.ChildNodes.Item(159).InnerText
                pageid = m_node.ChildNodes.Item(172).InnerText
                page_language = m_node.ChildNodes.Item(173).InnerText
                page_material = m_node.ChildNodes.Item(174).InnerText
                lock_id = m_node.ChildNodes.Item(126).InnerText
                lock_material = m_node.ChildNodes.Item(127).InnerText
                sheathid = m_node.ChildNodes.Item(128).InnerText
                MaxDurability = m_node.ChildNodes.Item(130).InnerText
                ZoneNameID = m_node.ChildNodes.Item(132).InnerText
                mapid = m_node.ChildNodes.Item(133).InnerText
                bagfamily = m_node.ChildNodes.Item(134).InnerText
                ReqDisenchantSkill = m_node.ChildNodes.Item(138).InnerText
                ArmorDamageModifier = m_node.ChildNodes.Item(139).InnerText
                duration = m_node.ChildNodes.Item(142).InnerText
                ItemLimitCategoryID = 0
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        ToolStripStatusLabel1.ForeColor = Color.Green
        ToolStripStatusLabel1.Text = "Web connect status: Connected."
    End Sub

    Public Sub writesql()
        If My.Settings.type = "Arcemu" Then
            arcQuery = "INSERT INTO `items` VALUES ('" & entry & "', '" & classs & "', '" & subclass & "', '" & field4 & "', '" & name1 & "', '" & displayid & "', '" & quality & "', '" & flags & "', '" & faction & "', '" & buyprice & "', '" & sellprice & "', '" & inventorytype & "', '" & allowableclass & "', '" & allowablerace & "', '" & itemlevel & "', '" & requiredlevel & "', '" & RequiredSkill & "', '" & RequiredSkillRank & "', '" & RequiredSpell & "', '" & RequiredPlayerRank1 & "', '" & RequiredPlayerRank2 & "', '" & RequiredFaction & "', '" & RequiredFactionStanding & "', '" & Unique & "', '" & maxcount & "', '" & ContainerSlots & "', '" & itemstatscount & "', '" & stat_type1 & "', '" & stat_value1 & "', '" & stat_type2 & "', '" & stat_value2 & "', '" & stat_type3 & "', '" & stat_value3 & "', '" & stat_type4 & "', '" & stat_value4 & "', '" & stat_type5 & "', '" & stat_value5 & "', '" & stat_type6 & "', '" & stat_value6 & "', '" & stat_type7 & "', '" & stat_value7 & "', '" & stat_type8 & "', '" & stat_value8 & "', '" & stat_type9 & "', '" & stat_value9 & "', '" & stat_type10 & "', '" & stat_value10 & "', '" & ScalingStatsEntry & "', '" & ScalingStatsFlags & "', '" & dmg_min1 & "', '" & dmg_max1 & "', '" & dmg_type1 & "', '" & dmg_min2 & "', '" & dmg_max2 & "', '" & dmg_type2 & "', '" & armor & "', '" & holy_res & "', '" & fire_res & "', '" & nature_res & "', '" & frost_res & "', '" & shadow_res & "', '" & arcane_resist & "', '" & delay & "', '" & ammo_type & "', '" & TotemCategory & "', '" & spellid_1 & "', '" & spelltrigger_1 & "', '" & spellcharges_1 & "', '" & spellcooldown_1 & "', '" & spellcategory_1 & "', '" & spellcategorycooldown_1 & "', '" & spellid_2 & "', '" & spelltrigger_2 & "', '" & spellcharges_2 & "', '" & spellcooldown_2 & "', '" & spellcategory_2 & "', '" & spellcategorycooldown_2 & "', '" & spellid_3 & "', '" & spelltrigger_3 & "', '" & spellcharges_3 & "', '" & spellcooldown_3 & "', '" & spellcategory_3 & "', '" & spellcategorycooldown_3 & "', '" & spellid_4 & "', '" & spelltrigger_4 & "', '" & spellcharges_4 & "', '" & spellcooldown_4 & "', '" & spellcategory_4 & "', '" & spellcategorycooldown_4 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & bonding & "', '" & description & "', '" & pageid & "', '" & page_language & "', '" & page_material & "', '" & quest_id & "', '" & lock_id & "', '" & lock_material & "', '" & sheathid & "', '" & randomprop & "', '" & randomsuffix & "', '" & block & "', '" & itemset & "', '" & MaxDurability & "', '" & ZoneNameID & "', '" & mapid & "', '" & bagfamily & "', '0', '" & socket_color_1 & "', '" & unk201_3 & "', '" & socket_color_2 & "', '" & unk201_5 & "', '" & socket_color_3 & "', '" & unk201_7 & "', '" & socket_bonus & "', '" & GemProperties & "', '" & ReqDisenchantSkill & "', '" & ArmorDamageModifier & "', '" & duration & "', '" & 0 & "', '" & 0 & "');"
            thequery = arcQuery
        End If
        If My.Settings.type = "Trinity" Then
            trinquery = "INSERT INTO `item_template` VALUES ('" & entry & "', '" & classs & "', '" & subclass & "', '" & -1 & "', '" & name1 & "', '" & displayid & "', '" & quality & "', '" & flags & "', '" & faction & "', '" & buycount & "', '" & buyprice & "', '" & sellprice & "', '" & inventorytype & "', '" & allowableclass & "', '" & allowablerace & "', '" & itemlevel & "', '" & requiredlevel & "', '" & RequiredSkill & "', '" & RequiredSkillRank & "', '" & RequiredSpell & "', '" & RequiredPlayerRank1 & "', '" & RequiredPlayerRank2 & "', '" & RequiredFaction & "', '" & RequiredFactionStanding & "', '" & maxcount & "', '" & 1 & "',  '" & ContainerSlots & "', '" & itemstatscount & "', '" & stat_type1 & "', '" & stat_value1 & "', '" & stat_type2 & "', '" & stat_value2 & "', '" & stat_type3 & "', '" & stat_value3 & "', '" & stat_type4 & "', '" & stat_value4 & "', '" & stat_type5 & "', '" & stat_value5 & "', '" & stat_type6 & "', '" & stat_value6 & "', '" & stat_type7 & "', '" & stat_value7 & "', '" & stat_type8 & "', '" & stat_value8 & "', '" & stat_type9 & "', '" & stat_value9 & "', '" & stat_type10 & "', '" & stat_value10 & "', '" & ScalingStatsEntry & "', '" & ScalingStatsFlags & "', '" & dmg_min1 & "', '" & dmg_max1 & "', '" & dmg_type1 & "', '" & dmg_min2 & "', '" & dmg_max2 & "', '" & dmg_type2 & "', '" & armor & "', '" & holy_res & "', '" & fire_res & "', '" & nature_res & "', '" & frost_res & "', '" & shadow_res & "', '" & arcane_resist & "', '" & delay & "', '" & ammo_type & "', '" & rangedmodrange & "', '" & spellid_1 & "', '" & spelltrigger_1 & "', '" & spellcharges_1 & "', '" & 0 & "', '" & spellcooldown_1 & "', '" & spellcategory_1 & "', '" & spellcategorycooldown_1 & "', '" & spellid_2 & "', '" & spelltrigger_2 & "', '" & spellcharges_2 & "', '" & 0 & "', '" & spellcooldown_2 & "', '" & spellcategory_2 & "', '" & spellcategorycooldown_2 & "', '" & spellid_3 & "', '" & spelltrigger_3 & "', '" & spellcharges_3 & "', '" & 0 & "', '" & spellcooldown_3 & "', '" & spellcategory_3 & "', '" & spellcategorycooldown_3 & "', '" & spellid_4 & "', '" & spelltrigger_4 & "', '" & spellcharges_4 & "', '" & 0 & "', '" & spellcooldown_4 & "', '" & spellcategory_4 & "', '" & spellcategorycooldown_4 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & bonding & "', '" & description & "', '" & pageid & "', '" & page_language & "', '" & page_material & "', '" & quest_id & "', '" & lock_id & "', '" & lock_material & "', '" & sheathid & "', '" & randomprop & "', '" & randomsuffix & "', '" & block & "', '" & itemset & "', '" & MaxDurability & "', '" & ZoneNameID & "', '" & mapid & "', '" & bagfamily & "', '" & TotemCategory & "', '" & socket_color_1 & "', '" & unk201_3 & "', '" & socket_color_2 & "', '" & unk201_5 & "', '" & socket_color_3 & "', '" & unk201_7 & "', '" & socket_bonus & "', '" & GemProperties & "', '" & ReqDisenchantSkill & "', '" & ArmorDamageModifier & "' , '" & duration & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "', '" & 0 & "');"
            thequery = trinquery
        End If
        If My.Settings.type = "Mangos" Then
            mangoquery = "INSERT INTO `item_template` VALUES ('" & entry & "', '" & classs & "', '" & subclass & "', '" & -1 & "', '" & name1 & "', '" & displayid & "', '" & quality & "', '" & flags & "', '" & faction & "', '" & buycount & "', '" & buyprice & "', '" & sellprice & "', '" & inventorytype & "', '" & allowableclass & "', '" & allowablerace & "', '" & itemlevel & "', '" & requiredlevel & "', '" & RequiredSkill & "', '" & RequiredSkillRank & "', '" & RequiredSpell & "', '" & RequiredPlayerRank1 & "', '" & RequiredFaction & "', '" & RequiredFactionStanding & "', '" & RequiredReputationRank & "', '" & maxcount & "', '" & Unique & "',  '" & ContainerSlots & "', '" & itemstatscount & "', '" & stat_type1 & "', '" & stat_value1 & "', '" & stat_type2 & "', '" & stat_value2 & "', '" & stat_type3 & "', '" & stat_value3 & "', '" & stat_type4 & "', '" & stat_value4 & "', '" & stat_type5 & "', '" & stat_value5 & "', '" & stat_type6 & "', '" & stat_value6 & "', '" & stat_type7 & "', '" & stat_value7 & "', '" & stat_type8 & "', '" & stat_value8 & "', '" & stat_type9 & "', '" & stat_value9 & "', '" & stat_type10 & "', '" & stat_value10 & "', '" & ScalingStatsEntry & "', '" & ScalingStatsFlags & "', '" & dmg_min1 & "', '" & dmg_max1 & "', '" & dmg_type1 & "', '" & dmg_min2 & "', '" & dmg_max2 & "', '" & dmg_type2 & "', '" & armor & "', '" & holy_res & "', '" & fire_res & "', '" & nature_res & "', '" & frost_res & "', '" & shadow_res & "', '" & arcane_resist & "', '" & delay & "', '" & ammo_type & "', " & rangedmodrange & ", '" & spellid_1 & "', '" & spelltrigger_1 & "', '" & spellcharges_1 & "', '" & 0 & "', '" & spellcooldown_1 & "', '" & spellcategory_1 & "', '" & spellcategorycooldown_1 & "', '" & spellid_2 & "', '" & spelltrigger_2 & "', '" & spellcharges_2 & "', '" & 0 & "', '" & spellcooldown_2 & "', '" & spellcategory_2 & "', '" & spellcategorycooldown_2 & "', '" & spellid_3 & "', '" & spelltrigger_3 & "', '" & spellcharges_3 & "', '" & 0 & "', '" & spellcooldown_3 & "', '" & spellcategory_3 & "', '" & spellcategorycooldown_3 & "', '" & spellid_4 & "', '" & spelltrigger_4 & "', '" & spellcharges_4 & "', '" & 0 & "', '" & spellcooldown_4 & "', '" & spellcategory_4 & "', '" & spellcategorycooldown_4 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & bonding & "', '" & description & "', '" & pageid & "', '" & page_language & "', '" & page_material & "', '" & quest_id & "', '" & lock_id & "', '" & lock_material & "', '" & sheathid & "', '" & randomprop & "', '" & randomsuffix & "', '" & block & "', '" & itemset & "', '" & MaxDurability & "', '" & ZoneNameID & "', '" & mapid & "', '" & bagfamily & "', '" & TotemCategory & "', '" & socket_color_1 & "', '" & unk201_3 & "', '" & socket_color_2 & "', '" & unk201_5 & "', '" & socket_color_3 & "', '" & unk201_7 & "', '" & socket_bonus & "', '" & GemProperties & "', '" & ReqDisenchantSkill & "', '" & ArmorDamageModifier & "' , '" & duration & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "');"
            thequery = mangoquery
        End If
    End Sub

    Public Sub fillitemedit()
        'Try
        mtbItemEntry.Text = entry
        txtItemName.Text = name1
        cmbItemBonding.SelectedIndex = bonding
        cmbItemClass.SelectedIndex = classs
        cmbItemSubclass.SelectedIndex = subclass
        mtbItemDisplay.Text = displayid
        cmbItemQuality.SelectedIndex = quality
        cmbItemInventory.SelectedIndex = inventorytype
        cmbItemSheath.SelectedIndex = sheathid
        ComboChoose(itemset, cmbItemSet)
        txtItemText.Text = description
        nudItemReqLevel.Value = requiredlevel
        nudItemLevel.Value = itemlevel
        nudItemMaxCount.Value = maxcount
        SetValueBuy(buyprice)
        SetValueSell(sellprice)
        mtbItemPage.Text = pageid
        mtbItemQuest.Text = quest_id
        nudItemStack.Value = maxcount
        nudItemSlots.Value = ContainerSlots
        mtbItemArmor.Text = armor
        mtbItemBlock.Text = block
        ComboChoose(stat_type1, cmbItemStats)
        nudItemStat.Value = stat_value1
        ComboChoose(stat_type2, cmbItemStats2)
        nudItemStat2.Value = stat_value2
        ComboChoose(stat_type3, cmbItemStats3)
        nudItemStat3.Value = stat_value3
        ComboChoose(stat_type4, cmbItemStats4)
        nudItemStat4.Value = stat_value4
        ComboChoose(stat_type5, cmbItemStats5)
        nudItemStat5.Value = stat_value5
        ComboChoose(stat_type6, cmbItemStats6)
        nudItemStat6.Value = stat_value6
        ComboChoose(stat_type7, cmbItemStats7)
        nudItemStat7.Value = stat_value7
        ComboChoose(stat_type8, cmbItemStats8)
        nudItemStat8.Value = stat_value8
        ComboChoose(stat_type9, cmbItemStats9)
        nudItemStat9.Value = stat_value9
        ComboChoose(stat_type10, cmbItemStats10)
        nudItemStat10.Value = stat_value10
        nudItemRange.Value = rangedmodrange
        mtbItemSpeed.Text = delay
        cmbItemDamageType.SelectedIndex = dmg_type1
        mtbItemDamageMin.Text = dmg_min1
        mtbItemDamageMax.Text = dmg_max1
        cmbItemDamageType2.SelectedIndex = dmg_type2
        mtbItemDamageMin2.Text = dmg_min2
        mtbItemDamageMax2.Text = dmg_max2
        nudItemArcane.Value = arcane_resist
        nudItemFire.Value = fire_res
        nudItemFrost.Value = frost_res
        nudItemHoly.Value = holy_res
        nudItemNature.Value = nature_res
        nudItemShadow.Value = shadow_res
        mtbItemSpellID.Text = spellid_1
        nudItemCharges.Value = spellcharges_1
        cmbItemTrigger.SelectedIndex = spelltrigger_1
        mtbItemCooldown.Text = spellcooldown_1
        mtbItemCategory.Text = spellcategory_1
        mtbItemCategoryCooldown.Text = spellcategorycooldown_1
        mtbItemSpellID2.Text = spellid_2
        nudItemCharges2.Value = spellcharges_2
        cmbItemTrigger2.SelectedIndex = spelltrigger_2
        mtbItemCooldown2.Text = spellcooldown_2
        mtbItemCategory2.Text = spellcategory_2
        mtbItemCategoryCooldown2.Text = spellcategorycooldown_2
        mtbItemSpellID3.Text = spellid_3
        nudItemCharges3.Value = spellcharges_3
        cmbItemTrigger3.SelectedIndex = spelltrigger_3
        mtbItemCooldown3.Text = spellcooldown_3
        mtbItemCategory3.Text = spellcategory_3
        mtbItemCategoryCooldown3.Text = spellcategorycooldown_3
        mtbItemSpellID4.Text = spellid_4
        nudItemCharges4.Value = spellcharges_4
        cmbItemTrigger4.SelectedIndex = spelltrigger_4
        mtbItemCooldown4.Text = spellcooldown_4
        mtbItemCategory4.Text = spellcategory_4
        mtbItemCategoryCooldown4.Text = spellcategorycooldown_4
        mtbItemSpellID5.Text = spellid_5
        nudItemCharges5.Value = spellcharges_5
        cmbItemTrigger5.SelectedIndex = spelltrigger_5
        mtbItemCooldown5.Text = spellcooldown_5
        mtbItemCategory5.Text = spellcategory_5
        mtbItemCategoryCooldown5.Text = spellcategorycooldown_5
        lblItemClasses.Text = allowableclass
        lblItemRaces.Text = allowablerace
        ComboChoose(RequiredFaction, cmbItemFactions)
        cmbItemFactionStanding.SelectedIndex = RequiredFactionStanding
        nudItemSkillRank.Value = RequiredSkillRank
        ComboChoose(RequiredSkill, cmbItemSkill)
        mtbItemBonus.Text = socket_bonus
        ComboChoose(socket_color_1, cmbItemSocket1)
        ComboChoose(socket_color_2, cmbItemSocket2)
        ComboChoose(socket_color_3, cmbItemSocket3)
        'Catch ex As Exception
        'txtItemEditStatus.Text = ex.Message
        'txtItemEditStatus.ForeColor = Color.Red
        'End Try
    End Sub

    Public Sub writeeditsql()
        If My.Settings.type = "Arcemu" Then
            arcQuery = "INSERT INTO `items` VALUES ('" & mtbItemEntry.Text & "', '" & cmbItemClass.SelectedIndex & "', '" & cmbItemSubclass.SelectedIndex & "', '" & -1 & "', '" & txtItemName.Text & "', '" & mtbItemDisplay.Text & "', '" & cmbItemQuality.SelectedIndex & "', '" & flags & "', '" & faction & "', '" & buyprice & "', '" & sellprice & "', '" & inventorytype & "', '" & allowableclass & "', '" & allowablerace & "', '" & itemlevel & "', '" & requiredlevel & "', '" & RequiredSkill & "', '" & RequiredSkillRank & "', '" & RequiredSpell & "', '" & RequiredPlayerRank1 & "', '" & RequiredPlayerRank2 & "', '" & RequiredFaction & "', '" & RequiredFactionStanding & "', '" & Unique & "', '" & maxcount & "', '" & ContainerSlots & "', '" & itemstatscount & "', '" & stat_type1 & "', '" & stat_value1 & "', '" & stat_type2 & "', '" & stat_value2 & "', '" & stat_type3 & "', '" & stat_value3 & "', '" & stat_type4 & "', '" & stat_value4 & "', '" & stat_type5 & "', '" & stat_value5 & "', '" & stat_type6 & "', '" & stat_value6 & "', '" & stat_type7 & "', '" & stat_value7 & "', '" & stat_type8 & "', '" & stat_value8 & "', '" & stat_type9 & "', '" & stat_value9 & "', '" & stat_type10 & "', '" & stat_value10 & "', '" & ScalingStatsEntry & "', '" & ScalingStatsFlags & "', '" & dmg_min1 & "', '" & dmg_max1 & "', '" & dmg_type1 & "', '" & dmg_min2 & "', '" & dmg_max2 & "', '" & dmg_type2 & "', '" & armor & "', '" & holy_res & "', '" & fire_res & "', '" & nature_res & "', '" & frost_res & "', '" & shadow_res & "', '" & arcane_resist & "', '" & delay & "', '" & ammo_type & "', '" & TotemCategory & "', '" & spellid_1 & "', '" & spelltrigger_1 & "', '" & spellcharges_1 & "', '" & spellcooldown_1 & "', '" & spellcategory_1 & "', '" & spellcategorycooldown_1 & "', '" & spellid_2 & "', '" & spelltrigger_2 & "', '" & spellcharges_2 & "', '" & spellcooldown_2 & "', '" & spellcategory_2 & "', '" & spellcategorycooldown_2 & "', '" & spellid_3 & "', '" & spelltrigger_3 & "', '" & spellcharges_3 & "', '" & spellcooldown_3 & "', '" & spellcategory_3 & "', '" & spellcategorycooldown_3 & "', '" & spellid_4 & "', '" & spelltrigger_4 & "', '" & spellcharges_4 & "', '" & spellcooldown_4 & "', '" & spellcategory_4 & "', '" & spellcategorycooldown_4 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & bonding & "', '" & description & "', '" & pageid & "', '" & page_language & "', '" & page_material & "', '" & quest_id & "', '" & lock_id & "', '" & lock_material & "', '" & sheathid & "', '" & randomprop & "', '" & randomsuffix & "', '" & block & "', '" & itemset & "', '" & MaxDurability & "', '" & ZoneNameID & "', '" & mapid & "', '" & bagfamily & "', '0', '" & socket_color_1 & "', '" & unk201_3 & "', '" & socket_color_2 & "', '" & unk201_5 & "', '" & socket_color_3 & "', '" & unk201_7 & "', '" & socket_bonus & "', '" & GemProperties & "', '" & ReqDisenchantSkill & "', '" & ArmorDamageModifier & "', '" & duration & "', '" & 0 & "', '" & 0 & "');"
            thequery = arcQuery
        End If
        If My.Settings.type = "Trinity" Then
            trinquery = "INSERT INTO `item_template` VALUES ('" & mtbItemEntry.Text & "', '" & cmbItemClass.SelectedIndex & "', '" & cmbItemSubclass.SelectedIndex & "', '" & -1 & "', '" & txtItemName.Text & "', '" & mtbItemDisplay.Text & "', '" & cmbItemQuality.SelectedIndex & "', '" & flags & "', '" & faction & "', '" & buycount & "', '" & buyprice & "', '" & sellprice & "', '" & inventorytype & "', '" & allowableclass & "', '" & allowablerace & "', '" & itemlevel & "', '" & requiredlevel & "', '" & RequiredSkill & "', '" & RequiredSkillRank & "', '" & RequiredSpell & "', '" & RequiredPlayerRank1 & "', '" & RequiredPlayerRank2 & "', '" & RequiredFaction & "', '" & RequiredFactionStanding & "', '" & maxcount & "', '" & 1 & "',  '" & ContainerSlots & "', '" & itemstatscount & "', '" & stat_type1 & "', '" & stat_value1 & "', '" & stat_type2 & "', '" & stat_value2 & "', '" & stat_type3 & "', '" & stat_value3 & "', '" & stat_type4 & "', '" & stat_value4 & "', '" & stat_type5 & "', '" & stat_value5 & "', '" & stat_type6 & "', '" & stat_value6 & "', '" & stat_type7 & "', '" & stat_value7 & "', '" & stat_type8 & "', '" & stat_value8 & "', '" & stat_type9 & "', '" & stat_value9 & "', '" & stat_type10 & "', '" & stat_value10 & "', '" & ScalingStatsEntry & "', '" & ScalingStatsFlags & "', '" & dmg_min1 & "', '" & dmg_max1 & "', '" & dmg_type1 & "', '" & dmg_min2 & "', '" & dmg_max2 & "', '" & dmg_type2 & "', '" & armor & "', '" & holy_res & "', '" & fire_res & "', '" & nature_res & "', '" & frost_res & "', '" & shadow_res & "', '" & arcane_resist & "', '" & delay & "', '" & ammo_type & "', '" & rangedmodrange & "', '" & spellid_1 & "', '" & spelltrigger_1 & "', '" & spellcharges_1 & "', '" & 0 & "', '" & spellcooldown_1 & "', '" & spellcategory_1 & "', '" & spellcategorycooldown_1 & "', '" & spellid_2 & "', '" & spelltrigger_2 & "', '" & spellcharges_2 & "', '" & 0 & "', '" & spellcooldown_2 & "', '" & spellcategory_2 & "', '" & spellcategorycooldown_2 & "', '" & spellid_3 & "', '" & spelltrigger_3 & "', '" & spellcharges_3 & "', '" & 0 & "', '" & spellcooldown_3 & "', '" & spellcategory_3 & "', '" & spellcategorycooldown_3 & "', '" & spellid_4 & "', '" & spelltrigger_4 & "', '" & spellcharges_4 & "', '" & 0 & "', '" & spellcooldown_4 & "', '" & spellcategory_4 & "', '" & spellcategorycooldown_4 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & bonding & "', '" & description & "', '" & pageid & "', '" & page_language & "', '" & page_material & "', '" & quest_id & "', '" & lock_id & "', '" & lock_material & "', '" & sheathid & "', '" & randomprop & "', '" & randomsuffix & "', '" & block & "', '" & itemset & "', '" & MaxDurability & "', '" & ZoneNameID & "', '" & mapid & "', '" & bagfamily & "', '" & TotemCategory & "', '" & socket_color_1 & "', '" & unk201_3 & "', '" & socket_color_2 & "', '" & unk201_5 & "', '" & socket_color_3 & "', '" & unk201_7 & "', '" & socket_bonus & "', '" & GemProperties & "', '" & ReqDisenchantSkill & "', '" & ArmorDamageModifier & "' , '" & duration & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "', '" & 0 & "');"
            thequery = trinquery
        End If
        If My.Settings.type = "Mangos" Then
            mangoquery = "INSERT INTO `item_template` VALUES ('" & mtbItemEntry.Text & "', '" & cmbItemClass.SelectedIndex & "', '" & cmbItemSubclass.SelectedIndex & "', '" & -1 & "', '" & txtItemName.Text & "', '" & mtbItemDisplay.Text & "', '" & cmbItemQuality.SelectedIndex & "', '" & flags & "', '" & faction & "', '" & buycount & "', '" & buyprice & "', '" & sellprice & "', '" & inventorytype & "', '" & allowableclass & "', '" & allowablerace & "', '" & itemlevel & "', '" & requiredlevel & "', '" & RequiredSkill & "', '" & RequiredSkillRank & "', '" & RequiredSpell & "', '" & RequiredPlayerRank1 & "', '" & RequiredFaction & "', '" & RequiredFactionStanding & "', '" & RequiredReputationRank & "', '" & maxcount & "', '" & Unique & "',  '" & ContainerSlots & "', '" & itemstatscount & "', '" & stat_type1 & "', '" & stat_value1 & "', '" & stat_type2 & "', '" & stat_value2 & "', '" & stat_type3 & "', '" & stat_value3 & "', '" & stat_type4 & "', '" & stat_value4 & "', '" & stat_type5 & "', '" & stat_value5 & "', '" & stat_type6 & "', '" & stat_value6 & "', '" & stat_type7 & "', '" & stat_value7 & "', '" & stat_type8 & "', '" & stat_value8 & "', '" & stat_type9 & "', '" & stat_value9 & "', '" & stat_type10 & "', '" & stat_value10 & "', '" & ScalingStatsEntry & "', '" & ScalingStatsFlags & "', '" & dmg_min1 & "', '" & dmg_max1 & "', '" & dmg_type1 & "', '" & dmg_min2 & "', '" & dmg_max2 & "', '" & dmg_type2 & "', '" & armor & "', '" & holy_res & "', '" & fire_res & "', '" & nature_res & "', '" & frost_res & "', '" & shadow_res & "', '" & arcane_resist & "', '" & delay & "', '" & ammo_type & "', " & rangedmodrange & ", '" & spellid_1 & "', '" & spelltrigger_1 & "', '" & spellcharges_1 & "', '" & 0 & "', '" & spellcooldown_1 & "', '" & spellcategory_1 & "', '" & spellcategorycooldown_1 & "', '" & spellid_2 & "', '" & spelltrigger_2 & "', '" & spellcharges_2 & "', '" & 0 & "', '" & spellcooldown_2 & "', '" & spellcategory_2 & "', '" & spellcategorycooldown_2 & "', '" & spellid_3 & "', '" & spelltrigger_3 & "', '" & spellcharges_3 & "', '" & 0 & "', '" & spellcooldown_3 & "', '" & spellcategory_3 & "', '" & spellcategorycooldown_3 & "', '" & spellid_4 & "', '" & spelltrigger_4 & "', '" & spellcharges_4 & "', '" & 0 & "', '" & spellcooldown_4 & "', '" & spellcategory_4 & "', '" & spellcategorycooldown_4 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & bonding & "', '" & description & "', '" & pageid & "', '" & page_language & "', '" & page_material & "', '" & quest_id & "', '" & lock_id & "', '" & lock_material & "', '" & sheathid & "', '" & randomprop & "', '" & randomsuffix & "', '" & block & "', '" & itemset & "', '" & MaxDurability & "', '" & ZoneNameID & "', '" & mapid & "', '" & bagfamily & "', '" & TotemCategory & "', '" & socket_color_1 & "', '" & unk201_3 & "', '" & socket_color_2 & "', '" & unk201_5 & "', '" & socket_color_3 & "', '" & unk201_7 & "', '" & socket_bonus & "', '" & GemProperties & "', '" & ReqDisenchantSkill & "', '" & ArmorDamageModifier & "' , '" & duration & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "' , '" & 0 & "');"
            thequery = mangoquery
        End If
    End Sub


    Private Sub btnItemPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnItemPage.Click
        Dim PageChooser As frmPageChooser

        Me.Enabled = False
        PageChooser = New frmPageChooser
        PageChooser.Field = mtbItemPage
        PageChooser.Show(Me)
    End Sub

    Private Sub btnItemChooseQuest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnItemChooseQuest.Click
        Dim QuestChooser As frmQuestChooser

        Me.Enabled = False
        QuestChooser = New frmQuestChooser
        QuestChooser.Field = mtbItemQuest
        QuestChooser.Show(Me)
    End Sub

    Private Sub cmbItemClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbItemClass.SelectedIndexChanged
        FillSubclasses(cmbItemClass.SelectedIndex)

        If cmbItemClass.SelectedIndex = 1 Then
            nudItemSlots.Enabled = True
        Else
            nudItemSlots.Enabled = False
        End If
    End Sub

    Public Sub ComboChoose(ByVal ID As Integer, ByVal Combo As ComboBox)
        Dim Temp As Integer

        Temp = GetIndexMinus(ID, Combo)
        If Temp = -1 Then
            Combo.Text = CStr(ID)
        Else
            Combo.SelectedIndex = Temp
        End If
    End Sub

    Public Function GetNumberFromIndex(ByVal Combo As ComboBox) As Integer
        Dim Temp As String
        Temp = Combo.Items(CInt(IIf(Combo.SelectedIndex = -1, 0, Combo.SelectedIndex))).ToString

        If Temp = "None" Then
            Return 0
        End If

        Return CInt(Temp.Substring(Temp.IndexOf("[") + 1, Temp.IndexOf("]") - Temp.IndexOf("[") - 1))
    End Function

    Public Function GetNumberFromIndex(ByVal CLB As CheckedListBox, ByVal Selected As Integer) As Integer
        Dim Temp As String
        Temp = CLB.Items(Selected).ToString

        If Temp.IndexOf("[") = -1 Then
            Return 0
        End If

        Return CInt(Temp.Substring(Temp.IndexOf("[") + 1, Temp.IndexOf("]") - Temp.IndexOf("[") - 1))
    End Function

    Public Function ComboGet(ByVal Combo As ComboBox) As String
        If IsNumeric(Combo.Text) Then
            Return Combo.Text
        Else
            Return CStr(GetNumberFromIndex(Combo))
        End If
    End Function

    Public Sub SetValueBuy(ByVal Copper As Long)
        nudGold.Value = CInt(Copper / 10000)
        nudSilver.Value = CInt((Copper Mod 10000) / 100)
        nudCopper.Value = CInt(Copper Mod 100)
    End Sub

    Public Sub SetValueSell(ByVal Copper As Long)
        nudGoldSell.Value = CInt(Copper / 10000)
        nudSilverSell.Value = CInt((Copper Mod 10000) / 100)
        nudCopperSell.Value = CInt(Copper Mod 100)
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSIFind.Click
        ToolStripStatusLabel1.ForeColor = Color.DarkOrange
        ToolStripStatusLabel1.Text = "Web connect status: Connecting to the web. Please wait for a while."
        itemid = MaskedTextBox1.Text
        btnSIFind.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        GroupBox6.Enabled = False
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Maximum = 5

        If My.Settings.type = "Trinity" Or My.Settings.type = "Mangos" Then
            Query = New MySqlCommand("SELECT `entry` FROM `item_template` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
        Else
            Query = New MySqlCommand("SELECT `entry` FROM `items` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
        End If
        ToolStripProgressBar1.Value = 1
        Try
            Reader = Query.ExecuteReader()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If Reader.HasRows And itemid <> "" Then
            txtSIS.ForeColor = Color.Red
            txtSIS.Text = "Item Status: " & itemid & " already in database."
            Button4.Enabled = True
        Else
            txtSIS.ForeColor = Color.Green
            txtSIS.Text = "Item Status: " & itemid & " ready to add to database."
            Button2.Enabled = True
        End If

        Button3.Enabled = True
        ToolStripProgressBar1.Value = 2

        If checkitem() = True Then
            ToolStripProgressBar1.Value = 3
            nodelist()
            txtItemEditStatus.ForeColor = Color.Green
            txtItemEditStatus.Text = "Item Status: " & itemid & " loaded succesfuly."
            If chkEditor.Checked = True Then
                fillitemedit()
                chkEditor.Checked = False
                reloaditemid = itemid
                firstcheck = True
            End If
            TextBox5.Text = name1
            WebBrowser4.Navigate("http://wow.allakhazam.com/" & itemicon)
            Label71.Text = "Current ID: " & itemid
            ToolStripProgressBar1.Value = 4
        Else
            txtSIS.ForeColor = Color.Red
            txtSIS.Text = "Item Status: " & itemid & " not found on web."
            WebBrowser4.Navigate("")
            TextBox5.Text = "Item Name"
            Button2.Enabled = False
            Button3.Enabled = False
        End If
        Reader.Close()
        WebBrowser1.Navigate("http://wow.allakhazam.com/ihtml?" & itemid)
        btnSIFind.Enabled = True
        GroupBox6.Enabled = True
        ToolStripProgressBar1.Value = 5
    End Sub

    Private Sub MaskedTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.TextChanged
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
    End Sub

    Public Function checkitem() As Boolean
        Dim url As String = ("http://wow.allakhazam.com/ihtml?" + itemid)
        Dim webResponse3 As HttpWebResponse = Nothing
        Dim webRequest3 As HttpWebRequest = HttpWebRequest.Create(url)

        Try
            webResponse3 = DirectCast(webRequest3.GetResponse(), System.Net.HttpWebResponse)
            Dim srResp As StreamReader
            srResp = New StreamReader(webResponse3.GetResponseStream())
            Dim strIn As String
            strIn = srResp.ReadToEnd
            If strIn.Length < 470 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(WebBrowser1.Url.ToString)
    End Sub

    Private Sub Form2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Logon.Close()
    End Sub

    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Connection.Open()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        itemid = MaskedTextBox1.Text
        nodelist()
        checktext()
        writesql()
        Execute = New MySqlCommand(thequery, Connection)
        Reader2 = Execute.ExecuteReader
        name1 = name1.Replace("\", "")
        txtSIS.ForeColor = Color.Green
        txtSIS.Text = "Item Status: " & name1 & " added successfuly."
        Reader2.Close()
        Button2.Enabled = False
        Button4.Enabled = True
    End Sub

    Public Sub checktext()
        name1 = name1.Replace("'", "\'")
        description = description.Replace("'", "\'")
    End Sub

    Public Sub checktext2()
        txtItemName.Text = txtItemName.Text.Replace("'", "\'")
        txtItemText.Text = txtItemText.Text.Replace("'", "\'")
    End Sub

    Public Sub reset()
        btnSIFind.Enabled = True
        itemid = ""
        WebBrowser1.Navigate("")
        MaskedTextBox1.Text = ""
    End Sub

    Public Sub checkstuff()
        x = ListBox5.Items.Count
        y = 0

        Do Until y = x
            If itemid = ListBox5.Items.Item(y) Then
                MsgBox(itemid & " already in list.")
                Exit Sub
            End If
            y = y + 1
        Loop

        x = ListBox3.Items.Count
        y = 0
        Do Until y = x
            If itemid = ListBox3.Items.Item(y) Then
                MsgBox(itemid & " already in database.")
                Exit Sub
            End If
            y = y + 1
        Loop

        If dbcheck() = True Then
            MsgBox(itemid & " already in database.")
            TextBox4.Text = TextBox4.Text & itemid & " | "
            ListBox3.Items.Add(itemid)
            Exit Sub
        End If

        x = ListBox4.Items.Count
        y = 0
        Do Until y = x
            If itemid = ListBox4.Items.Item(y) Then
                MsgBox(itemid & " not found on web.")
                Exit Sub
            End If
            y = y + 1
        Loop

        If checkitem() = True Then
            ListBox5.Items.Add(itemid)
            MsgBox(itemid & " added into list.")
        Else
            MsgBox(itemid & " not found on web.")
            TextBox7.Text = TextBox7.Text & itemid & " | "
            ListBox4.Items.Add(itemid)
        End If
    End Sub

    Public Function dbcheck() As Boolean
        If My.Settings.type = "Trinity" Or My.Settings.type = "Mangos" Then
            Query = New MySqlCommand("SELECT `entry` FROM `item_template` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
        Else
            Query = New MySqlCommand("SELECT `entry` FROM `items` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
        End If

        Try
            Reader = Query.ExecuteReader()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If Reader.HasRows And itemid <> "" Then
            Reader.Close()
            Return True
        Else
            Reader.Close()
            Return False
        End If

    End Function

    Private Sub removeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles removeToolStripMenuItem.Click
        ListBox1.Items.Remove(ListBox1.SelectedItem)
        clearview()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        x = ListBox1.Items.Count
        y = 0
        ProgressBar1.Maximum = x
        ProgressBar1.Value = y

        Do Until y = x
            Try
                itemid = ListBox1.Items.Item(y)
                Label11.Text = itemid & " adding to database. " & ListBox2.Items.Count & " item(s) added."
                Label11.Refresh()
                nodelist()
                checktext()
                writesql()
                Execute = New MySqlCommand(thequery, Connection)
                Reader2 = Execute.ExecuteReader
                Reader2.Close()
                ListBox2.Items.Add(itemid)
                ListBox1.Items.RemoveAt(y)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            x = ListBox1.Items.Count
            ProgressBar1.Value = ProgressBar1.Value + 1
        Loop
        Label11.Text = ListBox2.Items.Count & " new item(s) added."
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If mtbRange1.Text = "" And mtbRange2.Text = "" Then
            MsgBox("You didn't fill in any information")
            Exit Sub
        End If
        If mtbRange1.Text = "" Then
            MsgBox("You need to fill in a starting value")
        End If
        If mtbRange2.Text = "" Then
            MsgBox("You need to fill in an ending value")
        End If
        x = mtbRange1.Text
        y = mtbRange2.Text
        If x > y Then
            MsgBox("Starting value can't be more then ending value.")
            Exit Sub
        End If

        Do Until x = y
            itemid = x
            If Listbox1Check() = True Then
            Else
                ListBox5.Items.Add(x)
            End If
            x = x + 1
        Loop
        checkdb()
    End Sub

    Public Function Listbox1Check() As Boolean
        Dim q As Integer
        Dim z As Integer
        q = 0
        z = ListBox1.Items.Count

        Do Until q = z
            If itemid = ListBox1.Items.Item(q) Then
                Return True
            End If
            q = q + 1
        Loop
    End Function

    Public Function Listbox3Check() As Boolean
        Dim q As Integer
        Dim z As Integer
        q = 0
        z = ListBox3.Items.Count

        Do Until q = z
            If itemid = ListBox3.Items.Item(q) Then
                Return True
            End If
            q = q + 1
        Loop
    End Function

    Public Function Listbox4Check() As Boolean
        Dim q As Integer
        Dim z As Integer
        q = 0
        z = ListBox4.Items.Count

        Do Until q = z
            If itemid = ListBox4.Items.Item(q) Then
                Return True
            End If
            q = q + 1
        Loop
    End Function

    Public Sub checkdb()
        y = 0
        x = ListBox5.Items.Count
        ProgressBar1.Maximum = x
        ProgressBar1.Value = 0

        Do Until y = x
            itemid = ListBox5.Items.Item(y)
            Label11.Text = "Check database and web: " & itemid
            Label11.Refresh()

            If Listbox3Check() = True Then
                ListBox5.Items.RemoveAt(y)
                y = y - 1
            Else
                If My.Settings.type = "Trinity" Or My.Settings.type = "Mangos" Then
                    Query = New MySqlCommand("SELECT `entry` FROM `item_template` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
                Else
                    Query = New MySqlCommand("SELECT `entry` FROM `items` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
                End If

                Try
                    Reader = Query.ExecuteReader()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Exit Sub
                End Try

                If Reader.HasRows And itemid <> "" Then
                    Reader.Close()
                    TextBox4.Text = TextBox4.Text & itemid & " | "
                    ListBox3.Items.Add(itemid)
                    ListBox5.Items.RemoveAt(y)
                    y = y - 1
                Else
                    Reader.Close()
                    If Listbox4Check() = True Then
                        ListBox5.Items.RemoveAt(y)
                        y = y - 1
                    Else
                        Dim url As String = ("http://wow.allakhazam.com/ihtml?" & itemid)
                        Dim webResponse3 As HttpWebResponse = Nothing
                        Dim webRequest3 As HttpWebRequest = HttpWebRequest.Create(url)
                        Dim srResp As StreamReader
                        Dim strIn As String
                        webResponse3 = DirectCast(webRequest3.GetResponse(), System.Net.HttpWebResponse)
                        srResp = New StreamReader(webResponse3.GetResponseStream())
                        strIn = srResp.ReadToEnd

                        If strIn.Length < 470 Then
                            TextBox7.Text = TextBox7.Text & itemid & " | "
                            ListBox4.Items.Add(itemid)
                            ListBox5.Items.RemoveAt(y)
                            y = y - 1
                        Else
                            ListBox1.Items.Add(itemid)
                            If CheckBox1.Checked = True Then
                                Try
                                    Label11.Text = itemid & " adding to database. " & ListBox2.Items.Count & " item(s) added."
                                    Label11.Refresh()
                                    nodelist()
                                    Sleep(NumericUpDown1.Value)
                                    checktext()
                                    writesql()
                                    Execute = New MySqlCommand(thequery, Connection)
                                    Reader2 = Execute.ExecuteReader
                                    Reader2.Close()
                                    ListBox2.Items.Add(itemid)
                                    ListBox1.Items.RemoveAt(y)
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                    Exit Sub
                                End Try
                                ListBox5.Items.RemoveAt(y)
                                y = y - 1
                            End If
                        End If
                    End If
                End If
            End If
            x = ListBox5.Items.Count
            y = y + 1
            ProgressBar1.Value = ProgressBar1.Value + 1
        Loop
        If CheckBox1.Checked = True Then
            Label11.Text = ListBox2.Items.Count & " new item(s) added."
        Else
            Label11.Text = ListBox1.Items.Count & " new item(s) found."
        End If

        If ListBox1.Items.Count > 0 Then
            CheckBox1.Checked = False
            CheckBox1.Enabled = False
        End If

    End Sub

    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        clearrange()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        itemid = MaskedTextBox1.Text
        itemdelete()
        txtSIS.ForeColor = Color.Green
        txtSIS.Text = "Item Status: " & itemid & " deleted successfuly."
        Button2.Enabled = True
        Button4.Enabled = False
    End Sub

    Public Sub itemdelete()
        If My.Settings.type = "Trinity" Or My.Settings.type = "Mangos" Then
            Query = New MySqlCommand("DELETE FROM `item_template` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
        Else
            Query = New MySqlCommand("DELETE FROM `items` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
        End If
        Try
            Reader = Query.ExecuteReader()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Reader.Close()
    End Sub

    Public Sub additems()
        x = ListBox5.Items.Item(0)
        y = ListBox5.Items.Count

        Do While x = y
            writesql()
            x = x + 1
        Loop

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ListBox5.Items.Clear()
    End Sub

    Private Sub ListBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim pt As Point
            pt.X = e.X
            pt.Y = e.Y
            Try
                ListBox1.SelectedIndex = ListBox1.IndexFromPoint(pt)
            Catch
            End Try
            If ListBox1.SelectedIndex >= 0 Then
                ContextMenuStrip1.Show(MousePosition)
            End If
        End If
    End Sub

    Private Sub ListBox2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox2.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim pt As Point
            pt.X = e.X
            pt.Y = e.Y
            Try
                ListBox2.SelectedIndex = ListBox2.IndexFromPoint(pt)
            Catch
            End Try
            If ListBox2.SelectedIndex >= 0 Then
                ContextMenuStrip2.Show(MousePosition)
            End If
        End If
    End Sub

    Private Sub ListBox3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox3.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim pt As Point
            pt.X = e.X
            pt.Y = e.Y
            Try
                ListBox3.SelectedIndex = ListBox3.IndexFromPoint(pt)
            Catch
            End Try
            If ListBox3.SelectedIndex >= 0 Then
                ContextMenuStrip3.Show(MousePosition)
            End If
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        itemid = ListBox1.SelectedItem
        If itemid <> "" Then nodelist()
        If entry <> "" Then
            TextBox6.Text = name1
            TextBox8.Text = entry
            WebBrowser5.Navigate("http://wow.allakhazam.com/" & itemicon)
        End If
        WebBrowser2.Navigate("http://wow.allakhazam.com/ihtml?" & itemid)
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        itemid = ListBox2.SelectedItem
        If itemid <> "" Then nodelist()
        If entry <> "" Then
            TextBox6.Text = name1
            TextBox8.Text = entry
            WebBrowser5.Navigate("http://wow.allakhazam.com/" & itemicon)
        End If
        WebBrowser2.Navigate("http://wow.allakhazam.com/ihtml?" & itemid)
    End Sub
    Private Sub ListBox3_SelectedIndex(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox3.SelectedIndexChanged
        itemid = ListBox3.SelectedItem
        If itemid <> "" Then nodelist()
        If entry <> "" Then
            TextBox6.Text = name1
            TextBox8.Text = entry
            WebBrowser5.Navigate("http://wow.allakhazam.com/" & itemicon)
        End If
        WebBrowser2.Navigate("http://wow.allakhazam.com/ihtml?" & itemid)
    End Sub

    Public Sub clearrange()
        mtbRange1.Text = ""
        mtbRange2.Text = ""
        Label11.Text = "Progress Info:"
        CheckBox1.Checked = False
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()
        TextBox4.Clear()
        TextBox7.Clear()
        ProgressBar1.Value = 0
        CheckBox1.Enabled = True
        NumericUpDown1.Value = 2000
        TextBox6.Text = "Item Name"
        TextBox8.Text = "Item Number"
        WebBrowser2.Navigate("")
        WebBrowser5.Navigate("")
    End Sub

    Public Sub clearview()
        WebBrowser2.Navigate("")
        WebBrowser5.Navigate("")
        TextBox6.Text = "Item Name"
        TextBox8.Text = "Item Number"
    End Sub

    Private Sub RemoveAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveAllToolStripMenuItem.Click
        ListBox1.Items.Clear()
        clearview()
    End Sub

    Private Sub AddToDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToDatabaseToolStripMenuItem.Click
        itemid = ListBox1.SelectedItem
        nodelist()
        checktext()
        writesql()

        If My.Settings.type = "Trinity" Or My.Settings.type = "Mangos" Then
            Query = New MySqlCommand("SELECT `entry` FROM `item_template` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
        Else
            Query = New MySqlCommand("SELECT `entry` FROM `items` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
        End If

        Execute = New MySqlCommand(thequery, Connection)
        Reader = Execute.ExecuteReader
        Reader.Close()
        name1 = name1.Replace("\", "")
        MsgBox(itemid & " " & name1 & " added successfuly.")
        ListBox2.Items.Add(itemid)
        ListBox1.Items.Remove(ListBox1.SelectedItem)
        clearview()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://www.phanonic.smfnew.com")
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        System.Diagnostics.Process.Start("mailto:ctnyvz@gmail.com")
    End Sub

    Private Sub RemoveAllToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveAllToolStripMenuItem2.Click
        ListBox2.Items.Remove(ListBox2.SelectedItem)
        clearview()
    End Sub

    Private Sub RemoveAllToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveAllToolStripMenuItem1.Click
        ListBox3.Items.Remove(ListBox3.SelectedItem)
        clearview()
    End Sub

    Private Sub RemoveAllToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveAllToolStripMenuItem3.Click
        ListBox2.Items.Clear()
        clearview()
    End Sub

    Private Sub RemoveAllToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveAllToolStripMenuItem4.Click
        ListBox3.Items.Clear()
        clearview()
    End Sub

    Private Sub Listbox2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Listbox2ToolStripMenuItem.Click
        itemid = ListBox2.SelectedItem
        itemdelete()
        MsgBox(itemid & " deleted successfuly.")
        ListBox1.Items.Add(ListBox2.SelectedItem)
        ListBox2.Items.Remove(ListBox2.SelectedItem)
        clearview()
    End Sub

    Private Sub Lİstbox3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lİstbox3ToolStripMenuItem.Click
        itemid = ListBox3.SelectedItem
        itemdelete()
        MsgBox(itemid & " deleted successfuly.")
        ListBox3.Items.Remove(ListBox3.SelectedItem)
        clearview()
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mtbRange2.Text = mtbRange1.Text
    End Sub

    Private Sub MaskedTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MaskedTextBox1.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Button1_Click(Nothing, Nothing)
        End If
    End Sub

    'Private Sub lblItemClasses_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblItemClasses.MouseEnter
    '   clbItemClasses.Visible = True
    'End Sub

    'Private Sub lblItemRaces_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblItemRaces.MouseEnter
    '    clbItemRaces.Visible = True
    'End Sub

    Private Sub tabItemReq_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabItemReq.MouseEnter
        clbItemClasses.Visible = False
        clbItemRaces.Visible = False
    End Sub

    Private Sub clbItemClasses_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles clbItemClasses.ItemCheck
        Dim Flags As Integer
        Dim Number As Integer
        Static Working As Boolean = False

        If Not Working Then
            Working = True
            If e.Index = 0 Then
                For I As Integer = 1 To (clbItemClasses.Items.Count - 1)
                    clbItemClasses.SetItemChecked(I, e.NewValue = CheckState.Checked)
                Next
            ElseIf e.Index <> 0 And e.NewValue = CheckState.Unchecked Then
                clbItemClasses.SetItemChecked(0, False)
            End If

            Flags = GetFlags(clbItemClasses)
            Number = GetNumberFromIndex(clbItemClasses, e.Index)

            If e.NewValue = CheckState.Checked Then
                Flags += Number
            Else
                Flags -= Number
            End If

            If Flags = 1503 Then Flags = -1

            lblItemClasses.Text = CStr(Flags)
            Working = False
        End If
    End Sub

    Private Sub clbItemRaces_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles clbItemRaces.ItemCheck
        Dim Flags As Integer
        Dim Number As Integer
        Static Working As Boolean = False

        If Not Working Then
            Working = True
            If e.Index = 0 Then
                For I As Integer = 1 To (clbItemRaces.Items.Count - 1)
                    clbItemRaces.SetItemChecked(I, e.NewValue = CheckState.Checked)
                Next
            ElseIf e.Index = 1 Then
                If e.NewValue = CheckState.Unchecked Then clbItemRaces.SetItemChecked(0, False)

                For I As Integer = 2 To 6
                    clbItemRaces.SetItemChecked(I, e.NewValue = CheckState.Checked)
                Next
            ElseIf e.Index = 7 Then
                If e.NewValue = CheckState.Unchecked Then clbItemRaces.SetItemChecked(0, False)

                For I As Integer = 8 To 12
                    clbItemRaces.SetItemChecked(I, e.NewValue = CheckState.Checked)
                Next
            ElseIf e.NewValue = CheckState.Unchecked Then
                clbItemRaces.SetItemChecked(0, False)

                If e.Index > 7 Then
                    clbItemRaces.SetItemChecked(7, False)
                Else
                    clbItemRaces.SetItemChecked(1, False)
                End If
            End If

            Flags = GetFlags(clbItemRaces)
            Number = GetNumberFromIndex(clbItemRaces, e.Index)

            If e.NewValue = CheckState.Checked Then
                Flags += Number
            Else
                Flags -= Number
            End If

            If Flags = 1791 Then Flags = -1

            lblItemRaces.Text = CStr(Flags)
            Working = False
        End If
    End Sub

    Private Sub mtbItemDamageSpeed_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtbItemDamageMin.TextChanged, mtbItemDamageMax.TextChanged, mtbItemSpeed.TextChanged
        UpdateDPS(mtbItemDamageMin, mtbItemDamageMax, mtbItemSpeed, lblItemDPS, "DPS")
    End Sub

    Private Sub UpdateDPS(ByVal MinField As Control, ByVal MaxField As Control, ByVal SpeedField As MaskedTextBox, ByVal DPSLabel As Label, ByVal Text As String)
        Try
            Dim Min As Integer = CInt(IIf(MinField.Text = "", 0, MinField.Text))
            Dim Max As Integer = CInt(IIf(MaxField.Text = "", 0, MaxField.Text))
            Dim Speed As Integer = CInt(IIf(SpeedField.Text = "", 0, SpeedField.Text))

            DPSLabel.Text = Text & ": " & Math.Round(((Min + Max) / 2) * (1000 / Speed))
        Catch e As Exception
            DPSLabel.Text = Text & ": NaN"
        End Try
    End Sub

    Private Sub mtbItemDamageMin2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtbItemDamageMin2.TextChanged, mtbItemDamageMax2.TextChanged
        UpdateDPS2(mtbItemDamageMin2, mtbItemDamageMax2, mtbItemSpeed, lblItemDPS2, "DPS")
    End Sub

    Private Sub UpdateDPS2(ByVal MinField As Control, ByVal MaxField As Control, ByVal SpeedField As MaskedTextBox, ByVal DPSLabel As Label, ByVal Text As String)
        Try
            Dim Min As Integer = CInt(IIf(MinField.Text = "", 0, MinField.Text))
            Dim Max As Integer = CInt(IIf(MaxField.Text = "", 0, MaxField.Text))
            Dim Speed As Integer = CInt(IIf(SpeedField.Text = "", 0, SpeedField.Text))

            DPSLabel.Text = Text & ": " & Math.Round(((Min + Max) / 2) * (1000 / Speed))
        Catch e As Exception
            DPSLabel.Text = Text & ": NaN"
        End Try
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIEViewSQL.Click
        itemid = mtbItemEntry.Text
        checktext2()
        writeeditsql()
        ViewSQL.Show()
        ViewSQL.rtxtViewSQL.Text = thequery
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        itemid = mtbItemEntry.Text
        nodelist()
        checktext()
        writesql()
        ViewSQL.Show()
        ViewSQL.rtxtViewSQL.Text = thequery
    End Sub

    Private Sub btnItemEditReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIEReload.Click
        itemid = reloaditemid
        If reloaditemid <> Nothing Then
            nodelist()
            Try
                fillitemedit()
            Catch ex As Exception
                txtItemEditStatus.Text = ex.Message
                Exit Sub
            End Try
            txtItemEditStatus.ForeColor = Color.Green
            txtItemEditStatus.Text = "Item Status: Item reloaded succesfuly."
        End If
    End Sub

    Private Sub mtbItemEntry_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtbItemEntry.TextChanged
        btnIEUpdate.Enabled = False
        btnIEAdd.Enabled = False
        If Not bwEditorDBCheck.IsBusy Then
            bwEditorDBCheck.RunWorkerAsync()
        End If
    End Sub

    Private Sub bwEditorDBCheck_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwEditorDBCheck.DoWork
        If firstcheck = True Then
            Sleep(150)
            firstcheck = False
        End If
        itemid = mtbItemEntry.Text

        If My.Settings.type = "Trinity" Or My.Settings.type = "Mangos" Then
            Query = New MySqlCommand("SELECT `entry` FROM `item_template` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
        Else
            Query = New MySqlCommand("SELECT `entry` FROM `items` WHERE `entry` = '" & itemid & "' LIMIT 1;", Connection)
        End If

        Try
            Reader = Query.ExecuteReader()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub bwEditorDBCheck_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwEditorDBCheck.RunWorkerCompleted
        If Reader.HasRows And itemid <> "" Then
            btnIEUpdate.Enabled = True
            btnIEAdd.Enabled = False
        Else
            btnIEUpdate.Enabled = False
            btnIEAdd.Enabled = True
        End If
        Reader.Close()
    End Sub

    Private Sub mtbRange2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mtbRange2.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Button7_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnIEUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIEUpdate.Click
        MsgBox("That section is under developing.")
    End Sub

    Private Sub btnIEAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIEAdd.Click
        MsgBox("That section is under developing.")
    End Sub
End Class