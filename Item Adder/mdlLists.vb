
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

    Public Sub FillWithZones(ByVal Combo As ComboBox)
        Dim Splitted() As String = My.Computer.FileSystem.ReadAllText("data\zones.dat").Split(vbCrLf.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
        Dim I As Integer

        Combo.Items.Clear()
        For I = 0 To (Splitted.Length - 1)
            Combo.Items.Add(Splitted(I))
        Next
        Combo.SelectedIndex = 0
    End Sub

    Public Function GetZoneName(ByVal ID As Integer) As String
        Dim Splitted() As String = My.Computer.FileSystem.ReadAllText("data\zones.dat").Split(vbCrLf.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
        Dim I As Integer

        For I = 0 To (Splitted.Length - 1)
            If Splitted(I).Substring(Splitted(I).Length - 1 - CStr(ID).Length) = (ID & "]") Then Return Splitted(I)
        Next

        Return "No Zone Found [" & ID & "]"
    End Function

    Public Sub FillSubclasses(ByVal ChosenClass As Integer)
        Dim Subclasses(7, 20) As String
        Dim I As Integer
        Dim SubclassID As Integer

        Subclasses(0, 0) = "Bag"
        Subclasses(0, 1) = "Soul Bag"
        Subclasses(0, 2) = "Herb Bag"
        Subclasses(0, 3) = "Enchanting Bag"
        Subclasses(0, 4) = "Engineering Bag"
        Subclasses(0, 5) = "Gem Bag"
        Subclasses(0, 6) = "Mining Bag"

        Subclasses(1, 0) = "Axe"
        Subclasses(1, 1) = "Two-Hand Axe"
        Subclasses(1, 2) = "Bow"
        Subclasses(1, 3) = "Gun"
        Subclasses(1, 4) = "Mace"
        Subclasses(1, 5) = "Two-Hand Mace"
        Subclasses(1, 6) = "Polearm"
        Subclasses(1, 7) = "Sword"
        Subclasses(1, 8) = "Two-Hand Sword"
        Subclasses(1, 10) = "Staff"
        Subclasses(1, 13) = "Fist Weapon"
        Subclasses(1, 14) = "Misc Weapon"
        Subclasses(1, 15) = "Dagger"
        Subclasses(1, 16) = "Thrown"
        Subclasses(1, 18) = "Crossbow"
        Subclasses(1, 19) = "Wand"
        Subclasses(1, 20) = "Fishing Pole"

        ' Armor
        Subclasses(2, 0) = "Misc"
        Subclasses(2, 1) = "Cloth"
        Subclasses(2, 2) = "Leather"
        Subclasses(2, 3) = "Mail"
        Subclasses(2, 4) = "Plate Mail"
        Subclasses(2, 5) = "Unknown"
        Subclasses(2, 6) = "Shield"

        ' Projectile
        Subclasses(3, 0) = "Unknown"
        Subclasses(3, 1) = "Unknown"
        Subclasses(3, 2) = "Arrow"
        Subclasses(3, 3) = "Bullet"

        ' Tradegoods
        Subclasses(4, 0) = "Trade Goods"
        Subclasses(4, 1) = "Parts"
        Subclasses(4, 2) = "Explosives"
        Subclasses(4, 3) = "Devices"

        ' Recipe
        Subclasses(5, 0) = "Book"
        Subclasses(5, 1) = "Leatherworking"
        Subclasses(5, 2) = "Tailoring"
        Subclasses(5, 3) = "Engineering"
        Subclasses(5, 4) = "Blacksmithing"
        Subclasses(5, 5) = "Cooking"
        Subclasses(5, 6) = "Alchemy"
        Subclasses(5, 7) = "First Aid"
        Subclasses(5, 8) = "Enchanting"
        Subclasses(5, 9) = "Fishing"

        ' Quiver
        Subclasses(6, 3) = "Ammo Pouch"
        Subclasses(6, 2) = "Quiver"

        ' Misc
        Subclasses(7, 0) = "Junk"

        ItemAdder.cmbItemSubclass.Items.Clear()

        Select Case ChosenClass
            Case 0, 3, 5, 8, 10, 12, 13, 14
                Exit Sub
            Case 1
                SubclassID = 0
            Case 2
                SubclassID = 1
            Case 4
                SubclassID = 2
            Case 6
                SubclassID = 3
            Case 7
                SubclassID = 4
            Case 9
                SubclassID = 5
            Case 11
                SubclassID = 6
            Case 15
                SubclassID = 7
        End Select

        For I = 0 To 20
            If Subclasses(SubclassID, I) <> "" Then
                ItemAdder.cmbItemSubclass.Items.Add(Subclasses(SubclassID, I))
            Else
                ItemAdder.cmbItemSubclass.Items.Add("Unknown")
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
End Module
