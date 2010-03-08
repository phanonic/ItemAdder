﻿
'    ///////////////////////////////////////////////////////////////////////////
'    // ADE - Ascent Database Editor                                          //
'    // Copyright (C) 2007  vbCrLf                                            //
'    //                                                                       //
'    // Now under the name, FDE - Flexible DB Editor                          //
'    // Programmed by FleX, 2008                                              //
'    //                                                                       //
'    // This program is free software: you can redistribute it and/or modify  //
'    // it under the terms of the GNU General Public License as published by  //
'    // the Free Software Foundation, either version 3 of the License, or     //
'    // (at your option) any later version.                                   //
'    //                                                                       //
'    // This program is distributed in the hope that it will be useful,       //
'    // but WITHOUT ANY WARRANTY; without even the implied warranty of        //
'    // MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         //
'    // GNU General Public License for more details.                          //
'    //                                                                       //
'    // You should have received a copy of the GNU General Public License     //
'    // along with this program.  If not, see <http://www.gnu.org/licenses/>. //
'    ///////////////////////////////////////////////////////////////////////////

Option Explicit On
Option Strict On

Module mdlLists
    Public Updating As Boolean = False

    Public Function FamilyToIndex(ByVal Family As Integer) As Integer
        Dim NewIndex As Integer = Family

        If NewIndex > 9 Then NewIndex -= 1
        If NewIndex > 12 Then NewIndex -= 2
        If NewIndex > 17 Then NewIndex -= 1
        If NewIndex > 21 Then NewIndex -= 1

        Return NewIndex
    End Function

    Public Function IndexToFamily(ByVal Index As Integer) As Integer
        If (Index > 15) Then
            Return Index + 3
        ElseIf (Index > 12) Then
            Return Index + 2
        Else
            Return Index
        End If
    End Function

    Public Sub ChooseFlags(ByVal Flags As Integer, ByVal CLB As CheckedListBox, ByVal All As Boolean, Optional ByVal Quests As Boolean = False)
        Dim I As Integer
        Dim CurrentFlag As Integer
        Dim Temp As String

        Updating = True

        For I = 0 To CLB.Items.Count - 1
            CLB.SetItemChecked(I, False)
        Next

        For I = 1 To CLB.Items.Count - 1
            Temp = CLB.Items(I).ToString

            If Temp.IndexOf("[") > -1 Then
                CurrentFlag = CInt(Temp.Substring(Temp.IndexOf("[") + 1, Temp.IndexOf("]") - Temp.IndexOf("[") - 1))
                If ((Flags And CurrentFlag) > 0) Or ((Quests = True) And (Flags = 0)) Then
                    CLB.SetItemCheckState(I, CheckState.Checked)
                Else
                    CLB.SetItemCheckState(I, CheckState.Unchecked)
                End If
            End If
        Next

        If (Flags = 0) And (All = False) Then
            CLB.SetItemChecked(0, True)
        End If

        Updating = False
    End Sub

    Public Function GetFlags(ByVal CLB As CheckedListBox) As Integer
        Dim I As Integer
        Dim Flags As Integer = 0
        Dim Temp As String

        For I = 1 To CLB.Items.Count - 1
            If CLB.GetItemChecked(I) Then
                Temp = CLB.Items(I).ToString

                If Temp.IndexOf("[") > -1 Then
                    Flags += CInt(Temp.Substring(Temp.IndexOf("[") + 1, Temp.IndexOf("]") - Temp.IndexOf("[") - 1))
                End If
            End If
        Next

        Return Flags
    End Function

    Public Function GetZoneName(ByVal ID As Integer) As String
        Dim Splitted() As String = My.Computer.FileSystem.ReadAllText("data\zones.dat").Split(vbCrLf.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
        Dim I As Integer

        For I = 0 To (Splitted.Length - 1)
            If Splitted(I).Substring(Splitted(I).Length - 1 - CStr(ID).Length) = (ID & "]") Then Return Splitted(I)
        Next

        Return "No Zone Found [" & ID & "]"
    End Function

    Public Sub FillSubclasses(ByVal ChosenClass As Integer)
        Dim Subclasses(16, 21) As String
        Dim I As Integer
        Dim C As Integer
        Dim SubclassID As Integer

        Subclasses(0, 0) = "Consumable"
        Subclasses(0, 1) = "Potion"
        Subclasses(0, 2) = "Elixir"
        Subclasses(0, 3) = "Flask"
        Subclasses(0, 4) = "Scroll"
        Subclasses(0, 5) = "Food & Drink"
        Subclasses(0, 6) = "Item Enhancement"
        Subclasses(0, 7) = "Bandage"
        Subclasses(0, 8) = "Other"

        Subclasses(1, 0) = "Bag"
        Subclasses(1, 1) = "Soul Bag"
        Subclasses(1, 2) = "Herb Bag"
        Subclasses(1, 3) = "Enchanting Bag"
        Subclasses(1, 4) = "Engineering Bag"
        Subclasses(1, 5) = "Gem Bag"
        Subclasses(1, 6) = "Mining Bag"
        Subclasses(1, 7) = "Leatherworking Bag"
        Subclasses(1, 8) = "Inscription Bag"

        Subclasses(2, 0) = "Axe One handed"
        Subclasses(2, 1) = "Axe Two handed"
        Subclasses(2, 2) = "Bow"
        Subclasses(2, 3) = "Gun"
        Subclasses(2, 4) = "Mace One handed"
        Subclasses(2, 5) = "Mace Two handed"
        Subclasses(2, 6) = "Polearm"
        Subclasses(2, 7) = "Sword One handed"
        Subclasses(2, 8) = "Sword Two handed"
        Subclasses(2, 9) = "Obsolete"
        Subclasses(2, 10) = "Staff"
        Subclasses(2, 11) = "Exotic"
        Subclasses(2, 12) = "Exotic"
        Subclasses(2, 13) = "Fist Weapon"
        Subclasses(2, 14) = "Miscellaneous"
        Subclasses(2, 15) = "Dagger"
        Subclasses(2, 16) = "Thrown"
        Subclasses(2, 17) = "Spear"
        Subclasses(2, 18) = "Crossbow"
        Subclasses(2, 19) = "Wand"
        Subclasses(2, 20) = "Fishing Pole"

        Subclasses(3, 0) = "Red"
        Subclasses(3, 1) = "Blue"
        Subclasses(3, 2) = "Yellow"
        Subclasses(3, 3) = "Purple"
        Subclasses(3, 4) = "Green"
        Subclasses(3, 5) = "Orange"
        Subclasses(3, 6) = "Meta"
        Subclasses(3, 7) = "Simple"
        Subclasses(3, 8) = "Prismatic"

        Subclasses(4, 0) = "Miscellaneous"
        Subclasses(4, 1) = "Cloth"
        Subclasses(4, 2) = "Leather"
        Subclasses(4, 3) = "Mail"
        Subclasses(4, 4) = "Plate"
        Subclasses(4, 5) = "Buckler"
        Subclasses(4, 6) = "Shield"
        Subclasses(4, 7) = "Libram"
        Subclasses(4, 8) = "Idol"
        Subclasses(4, 9) = "Totem"
        Subclasses(4, 10) = "Sigil"

        Subclasses(5, 0) = "Reagent"

        Subclasses(6, 0) = "Wand"
        Subclasses(6, 1) = "Bolt"
        Subclasses(6, 2) = "Arrow"
        Subclasses(6, 3) = "Bullet"
        Subclasses(6, 4) = "Thrown"

        Subclasses(7, 0) = "Trade Goods"
        Subclasses(7, 1) = "Parts"
        Subclasses(7, 2) = "Explosives"
        Subclasses(7, 3) = "Devices"
        Subclasses(7, 4) = "Jewelcrafting"
        Subclasses(7, 5) = "Cloth"
        Subclasses(7, 6) = "Leather"
        Subclasses(7, 7) = "Metal & Stone"
        Subclasses(7, 8) = "Meat"
        Subclasses(7, 9) = "Herb"
        Subclasses(7, 10) = "Elemental"
        Subclasses(7, 11) = "Other"
        Subclasses(7, 12) = "Enchanting"
        Subclasses(7, 13) = "Materials"
        Subclasses(7, 14) = "Armor Enchantment"
        Subclasses(7, 15) = "Weapon Enchantment"

        Subclasses(8, 0) = "Generic"

        Subclasses(9, 0) = "Book"
        Subclasses(9, 1) = "Leatherworking"
        Subclasses(9, 2) = "Tailoring"
        Subclasses(9, 3) = "Engineering"
        Subclasses(9, 4) = "Blacksmithing"
        Subclasses(9, 5) = "Cooking"
        Subclasses(9, 6) = "Alchemy"
        Subclasses(9, 7) = "First Aid"
        Subclasses(9, 8) = "Enchanting"
        Subclasses(9, 9) = "Fishing"
        Subclasses(9, 10) = "Jewelcrafting"

        Subclasses(10, 0) = "Money"

        Subclasses(11, 0) = "Quiver"
        Subclasses(11, 1) = "Quiver"
        Subclasses(11, 2) = "Quiver"
        Subclasses(11, 3) = "Ammo Pouch"

        Subclasses(12, 0) = "Quest"

        Subclasses(13, 0) = "Key"
        Subclasses(13, 1) = "Lockpick"

        Subclasses(14, 0) = "Permanent"

        Subclasses(15, 0) = "Junk"
        Subclasses(15, 1) = "Reagent"
        Subclasses(15, 2) = "Pet"
        Subclasses(15, 3) = "Holiday"
        Subclasses(15, 4) = "Other"
        Subclasses(15, 5) = "Mount"

        Subclasses(16, 1) = "Warrior"
        Subclasses(16, 2) = "Paladin"
        Subclasses(16, 3) = "Hunter"
        Subclasses(16, 4) = "Rogue"
        Subclasses(16, 5) = "Priest"
        Subclasses(16, 6) = "Death Knight"
        Subclasses(16, 7) = "Shaman"
        Subclasses(16, 8) = "Mage"
        Subclasses(16, 9) = "Warlock"
        Subclasses(16, 11) = "Druid"

        ItemAdder.cmbItemSubclass.Items.Clear()

        Select Case ChosenClass
            Case 0
                SubclassID = 0
            Case 1
                SubclassID = 1
            Case 2
                SubclassID = 2
            Case 3
                SubclassID = 3
            Case 4
                SubclassID = 4
            Case 5
                SubclassID = 5
            Case 6
                SubclassID = 6
            Case 7
                SubclassID = 7
            Case 8
                SubclassID = 8
            Case 9
                SubclassID = 9
            Case 10
                SubclassID = 10
            Case 11
                SubclassID = 11
            Case 12
                SubclassID = 12
            Case 13
                SubclassID = 13
            Case 14
                SubclassID = 14
            Case 15
                SubclassID = 15
            Case 16
                SubclassID = 16
        End Select

        If SubclassID = 0 Then C = 8
        If SubclassID = 1 Then C = 8
        If SubclassID = 2 Then C = 20
        If SubclassID = 3 Then C = 8
        If SubclassID = 4 Then C = 10
        If SubclassID = 5 Then C = 0
        If SubclassID = 6 Then C = 4
        If SubclassID = 7 Then C = 15
        If SubclassID = 8 Then C = 0
        If SubclassID = 9 Then C = 10
        If SubclassID = 10 Then C = 0
        If SubclassID = 11 Then C = 3
        If SubclassID = 12 Then C = 0
        If SubclassID = 13 Then C = 1
        If SubclassID = 14 Then C = 0
        If SubclassID = 15 Then C = 5
        If SubclassID = 16 Then C = 11


        For I = 0 To C
            If Subclasses(SubclassID, I) <> "" Then
                ItemAdder.cmbItemSubclass.Items.Add(Subclasses(SubclassID, I))
            Else
                ItemAdder.cmbItemSubclass.Items.Add("None")
            End If
        Next

        ItemAdder.cmbItemSubclass.SelectedIndex = 0
    End Sub

    Public Function GetIndexMinus(ByVal Number As Integer, ByVal Combo As ComboBox) As Integer
        Dim I As Integer
        Dim Temp As String

        For I = 0 To (Combo.Items.Count - 1)
            Temp = Combo.Items(I).ToString
            If Number = CInt(Temp.Substring(Temp.IndexOf("[") + 1, Temp.IndexOf("]") - Temp.IndexOf("[") - 1)) Then
                Return I
            End If
        Next

        Return -1
    End Function

    Public Function GetIndex(ByVal Number As Integer, ByVal Combo As ComboBox) As Integer
        Dim I As Integer
        Dim Temp As String

        For I = 0 To (Combo.Items.Count - 1)
            Temp = Combo.Items(I).ToString
            If Number = CInt(Temp.Substring(Temp.IndexOf("[") + 1, Temp.IndexOf("]") - Temp.IndexOf("[") - 1)) Then
                Return I
            End If
        Next
    End Function

    Public Function GetIndexNon(ByVal Number As Integer, ByVal Combo As ComboBox) As Integer
        Dim I As Integer
        Dim Temp As String

        For I = 1 To (Combo.Items.Count - 1)
            Temp = Combo.Items(I).ToString
            If Number = CInt(Temp.Substring(Temp.IndexOf("[") + 1, Temp.IndexOf("]") - Temp.IndexOf("[") - 1)) Then
                Return I
            End If
        Next
    End Function

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

    Public Sub ChooseClasses(ByVal Classes As Integer)
        Dim I As Integer
        Dim CurrentFlag As Integer
        Dim Temp As String

        If (Classes = -1) Then
            ItemAdder.clbItemClasses.SetItemCheckState(0, CheckState.Checked)
            Exit Sub
        Else
            ItemAdder.clbItemClasses.SetItemCheckState(0, CheckState.Unchecked)
        End If

        For I = 1 To ItemAdder.clbItemClasses.Items.Count - 1
            Temp = ItemAdder.clbItemClasses.Items(I).ToString
            CurrentFlag = CInt(Temp.Substring(Temp.IndexOf("[") + 1, Temp.IndexOf("]") - Temp.IndexOf("[") - 1))
            If ((Classes And CurrentFlag) > 0) And (Classes > 0) Then
                ItemAdder.clbItemClasses.SetItemCheckState(I, CheckState.Checked)
            Else
                ItemAdder.clbItemClasses.SetItemCheckState(I, CheckState.Unchecked)
            End If
        Next
    End Sub

    Public Sub ChooseRaces(ByVal Races As Integer)
        Dim I As Integer
        Dim CurrentFlag As Integer
        Dim Temp As String

        If (Races = -1) Then
            ItemAdder.clbItemRaces.SetItemCheckState(0, CheckState.Checked)
            Exit Sub
        Else
            ItemAdder.clbItemRaces.SetItemCheckState(0, CheckState.Unchecked)
        End If

        For I = 1 To ItemAdder.clbItemRaces.Items.Count - 1
            Temp = ItemAdder.clbItemRaces.Items(I).ToString
            If Temp.IndexOf("[") > -1 Then
                CurrentFlag = CInt(Temp.Substring(Temp.IndexOf("[") + 1, Temp.IndexOf("]") - Temp.IndexOf("[") - 1))
                If ((Races And CurrentFlag) > 0) And (Races > 0) Then
                    ItemAdder.clbItemRaces.SetItemCheckState(I, CheckState.Checked)
                Else
                    ItemAdder.clbItemRaces.SetItemCheckState(I, CheckState.Unchecked)
                End If
            End If
        Next
    End Sub

    Public Function GetClasses() As Double
        Dim I As Integer
        Dim Classes As Integer = 0
        Dim Temp As String

        If ItemAdder.clbItemClasses.GetItemChecked(0) Then
            Return -1
        End If

        For I = 1 To ItemAdder.clbItemClasses.Items.Count - 1
            If ItemAdder.clbItemClasses.GetItemChecked(I) Then
                Temp = ItemAdder.clbItemClasses.Items(I).ToString
                Classes += CInt(Temp.Substring(Temp.IndexOf("[") + 1, Temp.IndexOf("]") - Temp.IndexOf("[") - 1))
            End If
        Next

        Return Classes
    End Function

    Public Function GetRaces() As Double
        Dim I As Integer
        Dim Races As Integer = 0
        Dim Temp As String

        If ItemAdder.clbItemRaces.GetItemChecked(0) Then
            Return -1
        End If

        For I = 1 To ItemAdder.clbItemRaces.Items.Count - 1
            If ItemAdder.clbItemRaces.GetItemChecked(I) Then
                Temp = ItemAdder.clbItemRaces.Items(I).ToString
                Races += CInt(Temp.Substring(Temp.IndexOf("[") + 1, Temp.IndexOf("]") - Temp.IndexOf("[") - 1))
            End If
        Next

        Return Races
    End Function

    Public Sub ListBonuses(ByVal List As ListBox, ByVal Search As String, ByVal Limit As Boolean)
        Dim Splitted() As String = My.Computer.FileSystem.ReadAllText("data\bonuses.dat").Split(vbCrLf.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
        Dim I As Integer

        List.Items.Clear()
        AddBonus(List, "", "", True, True)

        For I = 0 To (Splitted.Length - 1)
            AddBonus(List, Splitted(I), Search, Limit)
        Next
    End Sub

    Public Sub AddBonus(ByVal List As ListBox, ByVal Bonus As String, ByVal Search As String, ByVal Limit As Boolean, Optional ByVal Reset As Boolean = False)
        Static Number As Integer = 0

        If Not Reset Then
            Number += 1
            If (Bonus.ToLower Like ("*" & Search.ToLower & "*")) And (Number > 100) Then List.Items.Add(Bonus)
        Else
            Number = 0
        End If
    End Sub

    Public Function ComboGet(ByVal Combo As ComboBox) As String
        If IsNumeric(Combo.Text) Then
            Return Combo.Text
        Else
            Return CStr(GetNumberFromIndex(Combo))
        End If
    End Function

End Module
