Imports System.IO

Imports System.Reflection
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports Microsoft.VisualBasic

Public Class Form1
    Public objList As ListViewItem
    Dim tokee(20000) As String '3
    Dim linee(20000) As String '1
    Dim setokee(20000) As String '3
    Dim selinee(20000) As String '1
    Dim isbody As Boolean = False
    Dim ismajor As Boolean = False
    Dim errorCtr As Integer = 0

    Dim brccount As Integer
    Dim paracount As Integer


    Private Sub lexi()
        dGridLexi.Items.Clear()
        dGridError.Items.Clear()
        dGridIden.Items.Clear()
        'semant_table.Items.Clear()
        dGridBoard.Items.Clear()

        Dim sourcecode As String = rTBCode.Text + " "
        Dim sc() As Char = sourcecode.ToCharArray()
        Dim i As Integer = 0
        Dim line As Integer = 1

        Dim errorCtr As Integer = 0
        Dim symbolCtr As Integer = 0
        Dim idCtr As Integer = 0

        Dim delimStr As String = "Invalid lexeme "
        Dim id As String = ""
        Dim identifier As String = ""
        Dim str As String = ""
        Dim cmnt As String = ""
        Dim num As String = ""

        Dim allsym(95) As String
        allsym(0) = "`"
        allsym(1) = "~"
        allsym(2) = "1"
        allsym(3) = "!"
        allsym(4) = "2"
        allsym(5) = "@"
        allsym(6) = "3"
        allsym(7) = "#"
        allsym(8) = "4"
        allsym(9) = "$"
        allsym(10) = "5"
        allsym(11) = "%"
        allsym(12) = "6"
        allsym(13) = "^"
        allsym(14) = "7"
        allsym(15) = "&"
        allsym(16) = "8"
        allsym(17) = "*"
        allsym(18) = "9"
        allsym(19) = "("
        allsym(20) = "0"
        allsym(21) = ")"
        allsym(22) = "-"
        allsym(23) = "_"
        allsym(24) = "="
        allsym(25) = "+"
        allsym(26) = "\"
        allsym(27) = "|"
        allsym(28) = "]"
        allsym(29) = "}"
        allsym(30) = "["
        allsym(31) = "{"
        allsym(32) = "'"
        allsym(33) = """"
        allsym(34) = ";"
        allsym(35) = ":"
        allsym(36) = "/"
        allsym(37) = "?"
        allsym(38) = "."
        allsym(39) = ">"
        allsym(40) = ","
        allsym(41) = "<"
        allsym(42) = " "
        allsym(43) = "q"
        allsym(44) = "w"
        allsym(45) = "e"
        allsym(46) = "r"
        allsym(47) = "t"
        allsym(48) = "y"
        allsym(49) = "u"
        allsym(50) = "i"
        allsym(51) = "o"
        allsym(52) = "p"
        allsym(53) = "a"
        allsym(54) = "s"
        allsym(55) = "d"
        allsym(56) = "f"
        allsym(57) = "g"
        allsym(58) = "h"
        allsym(59) = "j"
        allsym(60) = "k"
        allsym(61) = "l"
        allsym(62) = "z"
        allsym(63) = "x"
        allsym(64) = "c"
        allsym(65) = "v"
        allsym(66) = "b"
        allsym(67) = "n"
        allsym(68) = "m"
        allsym(69) = "Q"
        allsym(70) = "W"
        allsym(71) = "E"
        allsym(72) = "R"
        allsym(73) = "T"
        allsym(74) = "Y"
        allsym(75) = "U"
        allsym(76) = "I"
        allsym(77) = "O"
        allsym(78) = "P"
        allsym(79) = "A"
        allsym(80) = "S"
        allsym(81) = "D"
        allsym(82) = "F"
        allsym(83) = "G"
        allsym(84) = "H"
        allsym(85) = "J"
        allsym(86) = "K"
        allsym(87) = "L"
        allsym(88) = "Z"
        allsym(89) = "X"
        allsym(90) = "C"
        allsym(91) = "V"
        allsym(92) = "B"
        allsym(93) = "N"
        allsym(94) = "M"


        Dim neg As Boolean = False
        While i < sourcecode.Length
            Dim read As Boolean = False
            If sc(i) = "b" Then
                If sc(i + 1) = "u" Then
                    If sc(i + 1) = "u" And sc(i + 2) = "l" Then
                        If sc(i + 1) = "u" And sc(i + 2) = "l" And sc(i + 3) = "l" Then
                            If sc(i + 4) = " " Or sc(i + 4) = "newline" Or Not inArray(sc(i + 4), allsym, 95) Then
                                symbolCtr += 1
                                objList = dGridLexi.Items.Add(symbolCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add("bull")
                                objList.SubItems.Add("bull")
                                objList.SubItems.Add(" ")
                                read = True
                                i += 4
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'bull'")
                                read = True
                                i += 4
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'bul'")
                            read = True
                            i += 3
                        End If
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'bu'")
                        read = True
                        i += 2
                    End If
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'b'")
                    read = True
                End If

            ElseIf sc(i) = "c" Then
                If sc(i + 1) = "h" Then
                    If sc(i + 1) = "h" And sc(i + 2) = "a" Then
                        If sc(i + 1) = "h" And sc(i + 2) = "a" And sc(i + 3) = "m" Then
                            If sc(i + 1) = "h" And sc(i + 2) = "a" And sc(i + 3) = "m" And sc(i + 4) = "o" Then
                                If sc(i + 1) = "h" And sc(i + 2) = "a" And sc(i + 3) = "m" And sc(i + 4) = "o" And sc(i + 5) = "i" Then
                                    If sc(i + 1) = "h" And sc(i + 2) = "a" And sc(i + 3) = "m" And sc(i + 4) = "o" And sc(i + 5) = "i" And sc(i + 6) = "s" Then
                                        If sc(i + 7) = " " Or Not inArray(sc(i + 8), allsym, 95) Then
                                            symbolCtr += 1
                                            objList = dGridLexi.Items.Add(symbolCtr)
                                            objList.SubItems.Add(line)
                                            objList.SubItems.Add("chamois")
                                            objList.SubItems.Add("chamois")
                                            objList.SubItems.Add(" ")
                                            read = True
                                            i += 7
                                        Else
                                            errorCtr += 1
                                            objList = dGridError.Items.Add(errorCtr)
                                            objList.SubItems.Add(line)
                                            objList.SubItems.Add(delimStr & "'chamois'")
                                            read = True
                                            i += 6
                                        End If
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'chamoi'")
                                        read = True
                                        i += 5
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'chamo'")
                                    read = True
                                    i += 4
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'cham'")
                                read = True
                                i += 3
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'cha'")
                            read = True
                            i += 2
                        End If
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'ch'")
                        read = True
                        i += 1
                    End If
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'c'")
                    read = True
                End If
            ElseIf sc(i) = "d" Then
                If sc(i + 1) = "o" Then
                    If sc(i + 2) = " " Or sc(i + 2) = "(" Or sc(i + 2) = "{" Or Not inArray(sc(i + 8), allsym, 95) Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add("entrance")
                        objList.SubItems.Add("entrance")
                        objList.SubItems.Add(" ")
                        read = True
                        i += 3
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'do'")
                        read = True
                        i += 2
                    End If
                ElseIf sc(i + 1) = "u" Then
                    If sc(i + 1) = "u" And sc(i + 2) = "c" Then
                        If sc(i + 1) = "u" And sc(i + 2) = "c" And sc(i + 3) = "k" Then
                            If sc(i + 4) = " " Or Not inArray(sc(i + 4), allsym, 95) Then
                                symbolCtr += 1
                                objList = dGridLexi.Items.Add(symbolCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add("duck")
                                objList.SubItems.Add("duck")
                                objList.SubItems.Add(" ")
                                read = True
                                i += 4
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'duck'")
                                read = True
                                i += 3
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'duc'")
                            read = True
                            i += 2
                        End If
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'du'")
                        read = True
                        i += 1
                    End If
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'d'")
                    read = True
                End If
            ElseIf sc(i) = "e" Then
                If sc(i + 1) = "e" Then
                    If sc(i + 1) = "e" And sc(i + 2) = "l" Then
                        If sc(i + 1) = "e" And sc(i + 2) = "l" And sc(i + 3) = "s" Then
                            If sc(i + 4) = " " And sc(i + 4) = "[" Or Not inArray(sc(i + 4), allsym, 95) Then
                                symbolCtr += 1
                                objList = dGridLexi.Items.Add(symbolCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add("eels")
                                objList.SubItems.Add("eels")
                                objList.SubItems.Add(" ")
                                read = True
                                i += 4
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'eels'")
                                read = True
                                i += 3
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'eel'")
                            read = True
                            i += 2
                        End If
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'el'")
                        read = True
                        i += 1
                    End If
                ElseIf sc(i + 1) = "n" Then
                    If sc(i + 1) = "n" And sc(i + 2) = "t" Then
                        If sc(i + 1) = "n" And sc(i + 2) = "t" And sc(i + 3) = "r" Then
                            If sc(i + 1) = "n" And sc(i + 2) = "t" And sc(i + 3) = "r" And sc(i + 4) = "a" Then
                                If sc(i + 1) = "n" And sc(i + 2) = "t" And sc(i + 3) = "r" And sc(i + 4) = "a" And sc(i + 5) = "n" Then
                                    If sc(i + 1) = "n" And sc(i + 2) = "t" And sc(i + 3) = "r" And sc(i + 4) = "a" And sc(i + 5) = "n" And sc(i + 6) = "c" Then
                                        If sc(i + 1) = "n" And sc(i + 2) = "t" And sc(i + 3) = "r" And sc(i + 4) = "a" And sc(i + 5) = "n" And sc(i + 6) = "c" And sc(i + 7) = "e" Then
                                            If sc(i + 8) = " " Or sc(i + 8) = "(" Or sc(i + 8) = "newline" Or Not inArray(sc(i + 8), allsym, 95) Then
                                                symbolCtr += 1
                                                objList = dGridLexi.Items.Add(symbolCtr)
                                                objList.SubItems.Add(line)
                                                objList.SubItems.Add("entrance")
                                                objList.SubItems.Add("entrance")
                                                objList.SubItems.Add(" ")
                                                read = True
                                                i += 8
                                            Else
                                                errorCtr += 1
                                                objList = dGridError.Items.Add(errorCtr)
                                                objList.SubItems.Add(line)
                                                objList.SubItems.Add(delimStr & "'entrance'")
                                                read = True
                                                i += 7
                                            End If
                                        Else
                                            errorCtr += 1
                                            objList = dGridError.Items.Add(errorCtr)
                                            objList.SubItems.Add(line)
                                            objList.SubItems.Add(delimStr & "'entranc'")
                                            read = True
                                            i += 6
                                        End If
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'entran'")
                                        read = True
                                        i += 5
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'entra'")
                                    read = True
                                    i += 4
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'entr'")
                                read = True
                                i += 3
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'ent'")
                            read = True
                            i += 2
                        End If
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'en'")
                        read = True
                        i += 1
                    End If
                Else
                    errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'e'")
                            read = True
                        End If


                    ElseIf sc(i) = "b" Then
                        If sc(i + 1) = "o" Then
                            If sc(i + 1) = "o" And sc(i + 2) = "a" Then
                                If sc(i + 1) = "o" And sc(i + 2) = "a" And sc(i + 3) = "r" Then
                                    If sc(i + 1) = "o" And sc(i + 2) = "a" And sc(i + 3) = "r" And sc(i + 4) = "d" Then
                                        If sc(i + 5) = " " Then
                                            symbolCtr += 1
                                            objList = dGridLexi.Items.Add(symbolCtr)
                                            objList.SubItems.Add(line)
                                            objList.SubItems.Add("board")
                                            objList.SubItems.Add("board")
                                            objList.SubItems.Add(" ")
                                            read = True
                                            i += 4
                                        Else
                                            errorCtr += 1
                                            objList = dGridError.Items.Add(errorCtr)
                                            objList.SubItems.Add(line)
                                            objList.SubItems.Add(delimStr & "'board'")
                                            read = True
                                            i += 4
                                        End If
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'boar'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'boa'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'bo'")
                                read = True
                                i += 1
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'b'")
                            read = True
                        End If
                    ElseIf sc(i) = "c" Then
                        If sc(i + 1) = "l" Then
                            If sc(i + 1) = "l" And sc(i + 2) = "e" Then
                                If sc(i + 1) = "l" And sc(i + 2) = "e" And sc(i + 3) = "a" Then
                                    If sc(i + 1) = "l" And sc(i + 2) = "e" And sc(i + 3) = "a" And sc(i + 4) = "r" Then
                                        If sc(i + 1) = "l" And sc(i + 2) = "e" And sc(i + 3) = "a" And sc(i + 4) = "r" And sc(i + 5) = "f" Then
                                            If sc(i + 1) = "l" And sc(i + 2) = "e" And sc(i + 3) = "a" And sc(i + 4) = "r" And sc(i + 5) = "f" _
                                            And sc(i + 6) = "i" Then
                                                If sc(i + 1) = "l" And sc(i + 2) = "e" And sc(i + 3) = "a" And sc(i + 4) = "r" And sc(i + 5) = "f" _
                                                And sc(i + 6) = "i" And sc(i + 7) = "e" Then
                                                    If sc(i + 1) = "l" And sc(i + 2) = "e" And sc(i + 3) = "a" And sc(i + 4) = "r" And sc(i + 5) = "f" _
                                                    And sc(i + 6) = "i" And sc(i + 7) = "e" And sc(i + 8) = "l" Then
                                                        If sc(i + 1) = "l" And sc(i + 2) = "e" And sc(i + 3) = "a" And sc(i + 4) = "r" And sc(i + 5) = "f" _
                                                        And sc(i + 6) = "i" And sc(i + 7) = "e" And sc(i + 8) = "l" And sc(i + 9) = "d" Then
                                                            If sc(i + 10) = " " Or sc(i + 10) = "\" Then
                                                                symbolCtr += 1
                                                                objList = dGridLexi.Items.Add(symbolCtr)
                                                                objList.SubItems.Add(line)
                                                                objList.SubItems.Add("clearfield")
                                                                objList.SubItems.Add("clearfield")
                                                                objList.SubItems.Add(" ")
                                                                read = True
                                                                i += 9
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(line)
                                                                objList.SubItems.Add(delimStr & "'clearfield'")
                                                                read = True
                                                                i += 9
                                                            End If
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(line)
                                                            objList.SubItems.Add(delimStr & "'clearfiel'")
                                                            read = True
                                                            i += 8
                                                        End If
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(line)
                                                        objList.SubItems.Add(delimStr & "'clearfie'")
                                                        read = True
                                                        i += 7
                                                    End If
                                                Else
                                                    errorCtr += 1
                                                    objList = dGridError.Items.Add(errorCtr)
                                                    objList.SubItems.Add(line)
                                                    objList.SubItems.Add(delimStr & "'clearfi'")
                                                    read = True
                                                    i += 6
                                                End If
                                            Else
                                                errorCtr += 1
                                                objList = dGridError.Items.Add(errorCtr)
                                                objList.SubItems.Add(line)
                                                objList.SubItems.Add(delimStr & "'clearf'")
                                                read = True
                                                i += 5
                                            End If
                                        Else
                                            errorCtr += 1
                                            objList = dGridError.Items.Add(errorCtr)
                                            objList.SubItems.Add(line)
                                            objList.SubItems.Add(delimStr & "'clear'")
                                            read = True
                                            i += 4
                                        End If
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'clea'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'cle'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'cl'")
                                read = True
                                i += 1
                            End If
                        ElseIf sc(i + 1) = "h" Then
                            If sc(i + 1) = "h" And sc(i + 2) = "e" Then
                                If sc(i + 1) = "h" And sc(i + 2) = "e" And sc(i + 3) = "c" Then
                                    If sc(i + 1) = "h" And sc(i + 2) = "e" And sc(i + 3) = "c" And sc(i + 4) = "k" Then
                                        If sc(i + 1) = "h" And sc(i + 2) = "e" And sc(i + 3) = "c" And sc(i + 4) = "k" And sc(i + 5) = "o" Then
                                            If sc(i + 1) = "h" And sc(i + 2) = "e" And sc(i + 3) = "c" And sc(i + 4) = "k" And sc(i + 5) = "o" And sc(i + 6) = "u" Then
                                                If sc(i + 1) = "h" And sc(i + 2) = "e" And sc(i + 3) = "c" And sc(i + 4) = "k" And sc(i + 5) = "o" And sc(i + 6) = "u" And sc(i + 7) = "t" Then
                                                    If sc(i + 8) = ":" Then
                                                        symbolCtr += 1
                                                        objList = dGridLexi.Items.Add(symbolCtr)
                                                        objList.SubItems.Add(line)
                                                        objList.SubItems.Add("checkout")
                                                        objList.SubItems.Add("checkout")
                                                        objList.SubItems.Add(" ")
                                                        read = True
                                                        i += 7
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(line)
                                                        objList.SubItems.Add(delimStr & "'checkout'")
                                                        read = True
                                                        i += 7
                                                    End If
                                                Else
                                                    errorCtr += 1
                                                    objList = dGridError.Items.Add(errorCtr)
                                                    objList.SubItems.Add(line)
                                                    objList.SubItems.Add(delimStr & "'checkou'")
                                                    read = True
                                                    i += 6
                                                End If
                                            Else
                                                errorCtr += 1
                                                objList = dGridError.Items.Add(errorCtr)
                                                objList.SubItems.Add(line)
                                                objList.SubItems.Add(delimStr & "'checko'")
                                                read = True
                                                i += 5
                                            End If
                                        ElseIf sc(i + 1) = "h" And sc(i + 2) = "e" And sc(i + 3) = "c" And sc(i + 4) = "k" And sc(i + 5) = "i" Then
                                            If sc(i + 1) = "h" And sc(i + 2) = "e" And sc(i + 3) = "c" And sc(i + 4) = "k" And sc(i + 5) = "i" And sc(i + 6) = "n" Then
                                                If sc(i + 7) = ":" Or sc(i + 7) = "!" Then
                                                    symbolCtr += 1
                                                    objList = dGridLexi.Items.Add(symbolCtr)
                                                    objList.SubItems.Add(line)
                                                    objList.SubItems.Add("checkin")
                                                    objList.SubItems.Add("checkin")
                                                    objList.SubItems.Add(" ")
                                                    read = True
                                                    i += 6
                                                Else
                                                    errorCtr += 1
                                                    objList = dGridError.Items.Add(errorCtr)
                                                    objList.SubItems.Add(line)
                                                    objList.SubItems.Add(delimStr & "'checkin'")
                                                    read = True
                                                    i += 6
                                                End If
                                            Else
                                                errorCtr += 1
                                                objList = dGridError.Items.Add(errorCtr)
                                                objList.SubItems.Add(line)
                                                objList.SubItems.Add(delimStr & "'checki'")
                                                read = True
                                                i += 5
                                            End If
                                        Else
                                            errorCtr += 1
                                            objList = dGridError.Items.Add(errorCtr)
                                            objList.SubItems.Add(line)
                                            objList.SubItems.Add(delimStr & "'check'")
                                            read = True
                                            i += 4
                                        End If
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'chec'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'che'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'ch'")
                                read = True
                                i += 1
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'c'")
                            read = True
                        End If
                    ElseIf sc(i) = "d" Then
                        If sc(i + 1) = "e" Then
                            If sc(i + 1) = "e" And sc(i + 2) = "p" Then
                                If sc(i + 1) = "e" And sc(i + 2) = "p" And sc(i + 3) = "a" Then
                                    If sc(i + 1) = "e" And sc(i + 2) = "p" And sc(i + 3) = "a" And sc(i + 4) = "r" Then
                                        If sc(i + 1) = "e" And sc(i + 2) = "p" And sc(i + 3) = "a" And sc(i + 4) = "r" And sc(i + 5) = "t" Then
                                            If sc(i + 6) = " " Or sc(i + 6) = "#" Or sc(i + 6) = "newline" Or Not inArray(sc(i + 6), allsym, 95) Then
                                                symbolCtr += 1
                                                objList = dGridLexi.Items.Add(symbolCtr)
                                                objList.SubItems.Add(line)
                                                objList.SubItems.Add("depart")
                                                objList.SubItems.Add("depart")
                                                objList.SubItems.Add(" ")
                                                read = True
                                                i += 5
                                            Else
                                                errorCtr += 1
                                                objList = dGridError.Items.Add(errorCtr)
                                                objList.SubItems.Add(line)
                                                objList.SubItems.Add(delimStr & "'depart'")
                                                read = True
                                                i += 5
                                            End If
                                        Else
                                            errorCtr += 1
                                            objList = dGridError.Items.Add(errorCtr)
                                            objList.SubItems.Add(line)
                                            objList.SubItems.Add(delimStr & "'depar'")
                                            read = True
                                            i += 4
                                        End If
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'depa'")
                                        read = True
                                        i += 3
                                    End If
                                ElseIf sc(i + 1) = "e" And sc(i + 2) = "p" And sc(i + 3) = "o" Then
                                    If sc(i + 1) = "e" And sc(i + 2) = "p" And sc(i + 3) = "o" And sc(i + 4) = "r" Then
                                        If sc(i + 1) = "e" And sc(i + 2) = "p" And sc(i + 3) = "o" And sc(i + 4) = "r" And sc(i + 5) = "t" Then
                                            If sc(i + 6) = " " Then
                                                symbolCtr += 1
                                                objList = dGridLexi.Items.Add(symbolCtr)
                                                objList.SubItems.Add(line)
                                                objList.SubItems.Add("deport")
                                                objList.SubItems.Add("deport")
                                                objList.SubItems.Add(" ")
                                                read = True
                                                i += 5
                                            Else
                                                errorCtr += 1
                                                objList = dGridError.Items.Add(errorCtr)
                                                objList.SubItems.Add(line)
                                                objList.SubItems.Add(delimStr & "'deport'")
                                                read = True
                                                i += 5
                                            End If
                                        Else
                                            errorCtr += 1
                                            objList = dGridError.Items.Add(errorCtr)
                                            objList.SubItems.Add(line)
                                            objList.SubItems.Add(delimStr & "'depor'")
                                            read = True
                                            i += 4
                                        End If
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'depo'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'dep'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'de'")
                                read = True
                                i += 1
                            End If
                        ElseIf sc(i + 1) = "u" Then
                            If sc(i + 1) = "u" And sc(i + 2) = "r" Then
                                If sc(i + 1) = "u" And sc(i + 2) = "r" And sc(i + 3) = "i" Then
                                    If sc(i + 1) = "u" And sc(i + 2) = "r" And sc(i + 3) = "i" And sc(i + 4) = "n" Then
                                        If sc(i + 1) = "u" And sc(i + 2) = "r" And sc(i + 3) = "i" And sc(i + 4) = "n" And sc(i + 5) = "g" Then
                                            If sc(i + 6) = "(" Or sc(i + 6) = " " Then
                                                symbolCtr += 1
                                                objList = dGridLexi.Items.Add(symbolCtr)
                                                objList.SubItems.Add(line)
                                                objList.SubItems.Add("during")
                                                objList.SubItems.Add("during")
                                                objList.SubItems.Add(" ")
                                                read = True
                                                i += 5
                                            Else
                                                errorCtr += 1
                                                objList = dGridError.Items.Add(errorCtr)
                                                objList.SubItems.Add(line)
                                                objList.SubItems.Add(delimStr & "'during'")
                                                read = True
                                                i += 5
                                            End If
                                        Else
                                            errorCtr += 1
                                            objList = dGridError.Items.Add(errorCtr)
                                            objList.SubItems.Add(line)
                                            objList.SubItems.Add(delimStr & "'durin'")
                                            read = True
                                            i += 4
                                        End If
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'duri'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'dur'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'du'")
                                read = True
                                i += 1
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'d'")
                            read = True
                        End If
                    ElseIf sc(i) = "f" Then
                        If sc(i + 1) = "a" Then
                            If sc(i + 1) = "a" And sc(i + 2) = "l" Then
                                If sc(i + 1) = "a" And sc(i + 2) = "l" And sc(i + 3) = "s" Then
                                    If sc(i + 1) = "a" And sc(i + 2) = "l" And sc(i + 3) = "s" And sc(i + 4) = "e" Then
                                        If sc(i + 5) = " " Or sc(i + 5) = "\" Or sc(i + 5) = ")" Or sc(i + 5) = "," Or sc(i + 5) = "}" Or Not inArray(sc(i + 5), allsym, 95) Then
                                            symbolCtr += 1
                                            objList = dGridLexi.Items.Add(symbolCtr)
                                            objList.SubItems.Add(line)
                                            objList.SubItems.Add("false")
                                            objList.SubItems.Add("flaglit")
                                            objList.SubItems.Add(" ")
                                            read = True
                                            i += 4
                                        Else
                                            errorCtr += 1
                                            objList = dGridError.Items.Add(errorCtr)
                                            objList.SubItems.Add(line)
                                            objList.SubItems.Add(delimStr & "'false'")
                                            read = True
                                            i += 4
                                        End If
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'fals'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'fal'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'fa'")
                                read = True
                                i += 1
                            End If
                        ElseIf sc(i + 1) = "l" Then
                            If sc(i + 1) = "l" And sc(i + 2) = "a" Then
                                If sc(i + 1) = "l" And sc(i + 2) = "a" And sc(i + 3) = "g" Then
                                    If sc(i + 4) = " " Or sc(i + 4) = "," Or sc(i + 4) = ")" Then
                                        symbolCtr += 1
                                        objList = dGridLexi.Items.Add(symbolCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add("flag")
                                        objList.SubItems.Add("flag")
                                        objList.SubItems.Add("data type")
                                        read = True
                                        i += 3
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'flag'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'fla'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'fl'")
                                read = True
                                i += 1
                            End If
                        ElseIf sc(i + 1) = "r" Then
                            If sc(i + 1) = "r" And sc(i + 2) = "a" Then
                                If sc(i + 1) = "r" And sc(i + 2) = "a" And sc(i + 3) = "c" Then
                                    If sc(i + 4) = " " Or sc(i + 4) = "," Or sc(i + 4) = ")" Then
                                        symbolCtr += 1
                                        objList = dGridLexi.Items.Add(symbolCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add("frac")
                                        objList.SubItems.Add("frac")
                                        objList.SubItems.Add("data type")
                                        read = True
                                        i += 3
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'frac'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'fra'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'fr'")
                                read = True
                                i += 1
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'f'")
                            read = True
                        End If
                    ElseIf sc(i) = "g" Then
                        If sc(i + 1) = "a" Then
                            If sc(i + 1) = "a" And sc(i + 2) = "t" Then
                                If sc(i + 1) = "a" And sc(i + 2) = "t" And sc(i + 3) = "e" Then
                                    If sc(i + 4) = " " Or sc(i + 4) = ";" Then
                                        symbolCtr += 1
                                        objList = dGridLexi.Items.Add(symbolCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add("gate")
                                        objList.SubItems.Add("gate")
                                        objList.SubItems.Add(" ")
                                        read = True
                                        i += 3
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'gate'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'gat'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'ga'")
                                read = True
                                i += 1
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'g'")
                            read = True
                        End If
                    ElseIf sc(i) = "h" Then
                        If sc(i + 1) = "a" Then
                            If sc(i + 1) = "a" And sc(i + 2) = "l" Then
                                If sc(i + 1) = "a" And sc(i + 2) = "l" And sc(i + 3) = "t" Then
                                    If sc(i + 4) = " " Or sc(i + 4) = "\" Then
                                        symbolCtr += 1
                                        objList = dGridLexi.Items.Add(symbolCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add("halt")
                                        objList.SubItems.Add("halt")
                                        objList.SubItems.Add(" ")
                                        read = True
                                        i += 3
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'halt'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'hal'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'ha'")
                                read = True
                                i += 1
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'h'")
                            read = True
                        End If
                    ElseIf sc(i) = "i" Then
                        If sc(i + 1) = "n" Then
                            If sc(i + 1) = "n" And sc(i + 2) = "d" Then
                                If sc(i + 3) = " " Or sc(i + 3) = "(" Then
                                    symbolCtr += 1
                                    objList = dGridLexi.Items.Add(symbolCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add("ind")
                                    objList.SubItems.Add("ind")
                                    objList.SubItems.Add(" ")
                                    read = True
                                    i += 2
                                ElseIf sc(i + 1) = "n" And sc(i + 2) = "d" And sc(i + 3) = "i" Then
                                    If sc(i + 4) = " " Then
                                        symbolCtr += 1
                                        objList = dGridLexi.Items.Add(symbolCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add("indi")
                                        objList.SubItems.Add("indi")
                                        objList.SubItems.Add(" ")
                                        read = True
                                        i += 3
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'indi'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'ind'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'in'")
                                read = True
                                i += 1
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'i'")
                            read = True
                        End If
                    ElseIf sc(i) = "l" Then
                        If sc(i + 1) = "e" Then
                            If sc(i + 1) = "e" And sc(i + 2) = "n" Then
                                If sc(i + 3) = " " Then
                                    symbolCtr += 1
                                    objList = dGridLexi.Items.Add(symbolCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add("len")
                                    objList.SubItems.Add("len")
                                    objList.SubItems.Add(" ")
                                    read = True
                                    i += 2
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'len'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'le'")
                                read = True
                                i += 1
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'l'")
                            read = True
                        End If
                    ElseIf sc(i) = "m" Then
                        If sc(i + 1) = "a" Then
                            If sc(i + 1) = "a" And sc(i + 2) = "j" Then
                                If sc(i + 1) = "a" And sc(i + 2) = "j" And sc(i + 3) = "o" Then
                                    If sc(i + 1) = "a" And sc(i + 2) = "j" And sc(i + 3) = "o" And sc(i + 4) = "r" Then
                                        If sc(i + 5) = "(" Then
                                            symbolCtr += 1
                                            objList = dGridLexi.Items.Add(symbolCtr)
                                            objList.SubItems.Add(line)
                                            objList.SubItems.Add("major")
                                            objList.SubItems.Add("major")
                                            objList.SubItems.Add(" ")
                                            read = True
                                            i += 4
                                        Else
                                            errorCtr += 1
                                            objList = dGridError.Items.Add(errorCtr)
                                            objList.SubItems.Add(line)
                                            objList.SubItems.Add(delimStr & "'major'")
                                            read = True
                                            i += 4
                                        End If
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'majo'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'maj'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'ma'")
                                read = True
                                i += 1
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'m'")
                            read = True
                        End If
                    ElseIf sc(i) = "n" Then
                        If sc(i + 1) = "u" Then
                            If sc(i + 1) = "u" And sc(i + 2) = "l" Then
                                If sc(i + 1) = "u" And sc(i + 2) = "l" And sc(i + 3) = "l" Then
                                    If sc(i + 4) = ")" Or sc(i + 4) = " " Then
                                        symbolCtr += 1
                                        objList = dGridLexi.Items.Add(symbolCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add("null")
                                        objList.SubItems.Add("null")
                                        objList.SubItems.Add(" ")
                                        read = True
                                        i += 3
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'null'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'nul'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'nu'")
                                read = True
                                i += 1
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'n'")
                            read = True
                        End If
                    ElseIf sc(i) = "o" Then
                        If sc(i + 1) = "t" Then
                            If sc(i + 1) = "t" And sc(i + 2) = "h" Then
                                If sc(i + 1) = "t" And sc(i + 2) = "h" And sc(i + 3) = "e" Then
                                    If sc(i + 1) = "t" And sc(i + 2) = "h" And sc(i + 3) = "e" And sc(i + 4) = "r" Then
                                        If sc(i + 1) = "t" And sc(i + 2) = "h" And sc(i + 3) = "e" And sc(i + 4) = "r" And sc(i + 5) = "w" Then
                                            If sc(i + 1) = "t" And sc(i + 2) = "h" And sc(i + 3) = "e" And sc(i + 4) = "r" And sc(i + 5) = "w" And sc(i + 6) = "i" Then
                                                If sc(i + 1) = "t" And sc(i + 2) = "h" And sc(i + 3) = "e" And sc(i + 4) = "r" And sc(i + 5) = "w" And sc(i + 6) = "i" _
                                                And sc(i + 7) = "s" Then
                                                    If sc(i + 1) = "t" And sc(i + 2) = "h" And sc(i + 3) = "e" And sc(i + 4) = "r" And sc(i + 5) = "w" And sc(i + 6) = "i" _
                                                    And sc(i + 7) = "s" And sc(i + 8) = "e" Then
                                                        If sc(i + 1) = "t" And sc(i + 2) = "h" And sc(i + 3) = "e" And sc(i + 4) = "r" And sc(i + 5) = "w" And sc(i + 6) = "i" _
                                                        And sc(i + 7) = "s" And sc(i + 8) = "e" And sc(i + 9) = "w" Then
                                                            If sc(i + 1) = "t" And sc(i + 2) = "h" And sc(i + 3) = "e" And sc(i + 4) = "r" And sc(i + 5) = "w" And sc(i + 6) = "i" _
                                                            And sc(i + 7) = "s" And sc(i + 8) = "e" And sc(i + 9) = "w" And sc(i + 10) = "h" Then
                                                                If sc(i + 1) = "t" And sc(i + 2) = "h" And sc(i + 3) = "e" And sc(i + 4) = "r" And sc(i + 5) = "w" And sc(i + 6) = "i" _
                                                                And sc(i + 7) = "s" And sc(i + 8) = "e" And sc(i + 9) = "w" And sc(i + 10) = "h" And sc(i + 11) = "e" Then
                                                                    If sc(i + 1) = "t" And sc(i + 2) = "h" And sc(i + 3) = "e" And sc(i + 4) = "r" And sc(i + 5) = "w" And sc(i + 6) = "i" _
                                                                    And sc(i + 7) = "s" And sc(i + 8) = "e" And sc(i + 9) = "w" And sc(i + 10) = "h" And sc(i + 11) = "e" And sc(i + 12) = "n" Then
                                                                        If sc(i + 13) = "(" Then
                                                                            symbolCtr += 1
                                                                            objList = dGridLexi.Items.Add(symbolCtr)
                                                                            objList.SubItems.Add(line)
                                                                            objList.SubItems.Add("otherwisewhen")
                                                                            objList.SubItems.Add("otherwisewhen")
                                                                            objList.SubItems.Add(" ")
                                                                            read = True
                                                                            i += 12
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(line)
                                                                            objList.SubItems.Add(delimStr & "'otherwisewhen'")
                                                                            read = True
                                                                            i += 12
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(line)
                                                                        objList.SubItems.Add(delimStr & "'otherwisewhe'")
                                                                        read = True
                                                                        i += 11
                                                                    End If
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(line)
                                                                    objList.SubItems.Add(delimStr & "'otherwisewh'")
                                                                    read = True
                                                                    i += 10
                                                                End If
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(line)
                                                                objList.SubItems.Add(delimStr & "'otherwisew'")
                                                                read = True
                                                                i += 9
                                                            End If
                                                        ElseIf sc(i + 1) = "t" And sc(i + 2) = "h" And sc(i + 3) = "e" And sc(i + 4) = "r" And sc(i + 5) = "w" And sc(i + 6) = "i" _
                                                        And sc(i + 7) = "s" And sc(i + 8) = "e" And (sc(i + 9) = " " Or sc(i + 9) = "#" Or sc(i + 9) = "<" Or sc(i + 9) = "newline" Or Not inArray(sc(i + 9), allsym, 95)) Then
                                                            symbolCtr += 1
                                                            objList = dGridLexi.Items.Add(symbolCtr)
                                                            objList.SubItems.Add(line)
                                                            objList.SubItems.Add("otherwise")
                                                            objList.SubItems.Add("otherwise")
                                                            objList.SubItems.Add(" ")
                                                            read = True
                                                            i += 8
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(line)
                                                            objList.SubItems.Add(delimStr & "'otherwise'")
                                                            read = True
                                                            i += 8
                                                        End If
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(line)
                                                        objList.SubItems.Add(delimStr & "'otherwis'")
                                                        read = True
                                                        i += 7
                                                    End If
                                                Else
                                                    errorCtr += 1
                                                    objList = dGridError.Items.Add(errorCtr)
                                                    objList.SubItems.Add(line)
                                                    objList.SubItems.Add(delimStr & "'otherwi'")
                                                    read = True
                                                    i += 6
                                                End If
                                            Else
                                                errorCtr += 1
                                                objList = dGridError.Items.Add(errorCtr)
                                                objList.SubItems.Add(line)
                                                objList.SubItems.Add(delimStr & "'otherw'")
                                                read = True
                                                i += 5
                                            End If
                                        Else
                                            errorCtr += 1
                                            objList = dGridError.Items.Add(errorCtr)
                                            objList.SubItems.Add(line)
                                            objList.SubItems.Add(delimStr & "'other'")
                                            read = True
                                            i += 4
                                        End If
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'othe'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'oth'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'ot'")
                                read = True
                                i += 1
                            End If
                        ElseIf sc(i + 1) = "n" Then
                            If sc(i + 2) = " " Or sc(i + 2) = "\" Then
                                symbolCtr += 1
                                objList = dGridLexi.Items.Add(symbolCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add("on")
                                objList.SubItems.Add("on")
                                objList.SubItems.Add(" ")
                                read = True
                                i += 1
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'on'")
                                read = True
                                i += 1
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'o'")
                            read = True
                        End If
                    ElseIf sc(i) = "r" Then
                        If sc(i + 1) = "u" Then
                            If sc(i + 1) = "u" And sc(i + 2) = "n" Then
                                If sc(i + 3) = " " Or sc(i + 3) = "<" Or sc(i + 3) = "#" Or sc(i + 3) = "newline" Or Not inArray(sc(i + 3), allsym, 95) Then
                                    symbolCtr += 1
                                    objList = dGridLexi.Items.Add(symbolCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add("run")
                                    objList.SubItems.Add("run")
                                    objList.SubItems.Add(" ")
                                    read = True
                                    i += 2
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'run'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'ru'")
                                read = True
                                i += 1
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'r'")
                            read = True
                        End If
                    ElseIf sc(i) = "s" Then
                        If sc(i + 1) = "e" Then
                            If sc(i + 1) = "e" And sc(i + 2) = "t" Then
                                If sc(i + 3) = " " Then
                                    symbolCtr += 1
                                    objList = dGridLexi.Items.Add(symbolCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add("set")
                                    objList.SubItems.Add("set")
                                    objList.SubItems.Add(" ")
                                    read = True
                                    i += 2
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'set'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'se'")
                                read = True
                                i += 1
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'s'")
                            read = True
                        End If
                    ElseIf sc(i) = "t" Then
                        If sc(i + 1) = "e" Then
                            If sc(i + 1) = "e" And sc(i + 2) = "r" Then
                                If sc(i + 1) = "e" And sc(i + 2) = "r" And sc(i + 3) = "m" Then
                                    If sc(i + 1) = "e" And sc(i + 2) = "r" And sc(i + 3) = "m" And sc(i + 4) = "i" Then
                                        If sc(i + 1) = "e" And sc(i + 2) = "r" And sc(i + 3) = "m" And sc(i + 4) = "i" And sc(i + 5) = "n" Then
                                            If sc(i + 1) = "e" And sc(i + 2) = "r" And sc(i + 3) = "m" And sc(i + 4) = "i" And sc(i + 5) = "n" And sc(i + 6) = "a" Then
                                                If sc(i + 1) = "e" And sc(i + 2) = "r" And sc(i + 3) = "m" And sc(i + 4) = "i" And sc(i + 5) = "n" And sc(i + 6) = "a" And sc(i + 7) = "l" Then
                                                    If sc(i + 8) = " " Then
                                                        symbolCtr += 1
                                                        objList = dGridLexi.Items.Add(symbolCtr)
                                                        objList.SubItems.Add(line)
                                                        objList.SubItems.Add("terminal")
                                                        objList.SubItems.Add("terminal")
                                                        objList.SubItems.Add(" ")
                                                        read = True
                                                        i += 7
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(line)
                                                        objList.SubItems.Add(delimStr & "'terminal'")
                                                        read = True
                                                        i += 7
                                                    End If
                                                Else
                                                    errorCtr += 1
                                                    objList = dGridError.Items.Add(errorCtr)
                                                    objList.SubItems.Add(line)
                                                    objList.SubItems.Add(delimStr & "'termina'")
                                                    read = True
                                                    i += 6
                                                End If
                                            Else
                                                errorCtr += 1
                                                objList = dGridError.Items.Add(errorCtr)
                                                objList.SubItems.Add(line)
                                                objList.SubItems.Add(delimStr & "'termin'")
                                                read = True
                                                i += 5
                                            End If
                                        Else
                                            errorCtr += 1
                                            objList = dGridError.Items.Add(errorCtr)
                                            objList.SubItems.Add(line)
                                            objList.SubItems.Add(delimStr & "'termi'")
                                            read = True
                                            i += 4
                                        End If
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'term'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'ter'")
                                    read = True
                                    i += 2
                                End If
                            ElseIf sc(i + 1) = "e" And sc(i + 2) = "x" Then
                                If sc(i + 1) = "e" And sc(i + 2) = "x" And sc(i + 3) = "t" Then
                                    If sc(i + 4) = " " Or sc(i + 4) = "," Or sc(i + 4) = ")" Then
                                        symbolCtr += 1
                                        objList = dGridLexi.Items.Add(symbolCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add("text")
                                        objList.SubItems.Add("text")
                                        objList.SubItems.Add("data type")
                                        read = True
                                        i += 3
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'text'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'tex'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'te'")
                                read = True
                                i += 1
                            End If
                        ElseIf sc(i + 1) = "a" Then
                            If sc(i + 1) = "a" And sc(i + 2) = "k" Then
                                If sc(i + 1) = "a" And sc(i + 2) = "k" And sc(i + 3) = "e" Then
                                    If sc(i + 4) = "(" Then
                                        symbolCtr += 1
                                        objList = dGridLexi.Items.Add(symbolCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add("take")
                                        objList.SubItems.Add("take")
                                        objList.SubItems.Add(" ")
                                        read = True
                                        i += 3
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'take'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'tak'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'ta'")
                                read = True
                                i += 1
                            End If
                        ElseIf sc(i + 1) = "i" Then
                            If sc(i + 1) = "i" And sc(i + 2) = "l" Then
                                If sc(i + 1) = "i" And sc(i + 2) = "l" And sc(i + 3) = "l" Then
                                    If sc(i + 4) = "(" Then
                                        symbolCtr += 1
                                        objList = dGridLexi.Items.Add(symbolCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add("till")
                                        objList.SubItems.Add("till")
                                        objList.SubItems.Add(" ")
                                        read = True
                                        i += 3
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'till'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'til'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'ti'")
                                read = True
                                i += 1
                            End If
                        ElseIf sc(i + 1) = "r" Then
                            If sc(i + 1) = "r" And sc(i + 2) = "u" Then
                                If sc(i + 1) = "r" And sc(i + 2) = "u" And sc(i + 3) = "e" Then
                                    If sc(i + 4) = " " Or sc(i + 4) = "\" Or sc(i + 4) = ")" Or sc(i + 4) = "," Or sc(i + 4) = "}" Or Not inArray(sc(i + 4), allsym, 95) Then
                                        symbolCtr += 1
                                        objList = dGridLexi.Items.Add(symbolCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add("true")
                                        objList.SubItems.Add("flaglit")
                                        objList.SubItems.Add(" ")
                                        read = True
                                        i += 3
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'true'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'tru'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'tr'")
                                read = True
                                i += 1
                            End If
                        ElseIf sc(i + 1) = "o" Then
                            If sc(i + 2) = " " Then
                                symbolCtr += 1
                                objList = dGridLexi.Items.Add(symbolCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add("to")
                                objList.SubItems.Add("to")
                                objList.SubItems.Add(" ")
                                read = True
                                i += 1
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'to'")
                                read = True
                                i += 1
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'t'")
                            read = True
                        End If
                    ElseIf sc(i) = "v" Then
                        If sc(i + 1) = "a" Then
                            If sc(i + 1) = "a" And sc(i + 2) = "c" Then
                                If sc(i + 1) = "a" And sc(i + 2) = "c" And sc(i + 3) = "a" Then
                                    If sc(i + 1) = "a" And sc(i + 2) = "c" And sc(i + 3) = "a" And sc(i + 4) = "n" Then
                                        If sc(i + 1) = "a" And sc(i + 2) = "c" And sc(i + 3) = "a" And sc(i + 4) = "n" And sc(i + 5) = "t" Then
                                            If sc(i + 6) = " " Then
                                                symbolCtr += 1
                                                objList = dGridLexi.Items.Add(symbolCtr)
                                                objList.SubItems.Add(line)
                                                objList.SubItems.Add("vacant")
                                                objList.SubItems.Add("vacant")
                                                objList.SubItems.Add("data type")
                                                read = True
                                                i += 5
                                            Else
                                                errorCtr += 1
                                                objList = dGridError.Items.Add(errorCtr)
                                                objList.SubItems.Add(line)
                                                objList.SubItems.Add(delimStr & "'vacant'")
                                                read = True
                                                i += 5
                                            End If
                                        Else
                                            errorCtr += 1
                                            objList = dGridError.Items.Add(errorCtr)
                                            objList.SubItems.Add(line)
                                            objList.SubItems.Add(delimStr & "'vacan'")
                                            read = True
                                            i += 4
                                        End If
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'vaca'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'vac'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'va'")
                                read = True
                                i += 1
                            End If
                        ElseIf sc(i + 1) = "r" Then
                            If sc(i + 2) = "\" Then
                                symbolCtr += 1
                                objList = dGridLexi.Items.Add(symbolCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add("vr")
                                objList.SubItems.Add("vr")
                                objList.SubItems.Add("  ")
                                read = True
                                i += 1
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'vr'")
                                read = True
                                i += 1
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'v'")
                            read = True
                        End If
                    ElseIf sc(i) = "w" Then
                        If sc(i + 1) = "h" Then
                            If sc(i + 1) = "h" And sc(i + 2) = "o" Then
                                If sc(i + 1) = "h" And sc(i + 2) = "o" And sc(i + 3) = "l" Then
                                    If sc(i + 1) = "h" And sc(i + 2) = "o" And sc(i + 3) = "l" And sc(i + 4) = "e" Then
                                        If sc(i + 5) = " " Or sc(i + 5) = "," Or sc(i + 5) = ")" Then
                                            symbolCtr += 1
                                            objList = dGridLexi.Items.Add(symbolCtr)
                                            objList.SubItems.Add(line)
                                            objList.SubItems.Add("whole")
                                            objList.SubItems.Add("whole")
                                            objList.SubItems.Add("data type")
                                            read = True
                                            i += 4
                                        Else
                                            errorCtr += 1
                                            objList = dGridError.Items.Add(errorCtr)
                                            objList.SubItems.Add(line)
                                            objList.SubItems.Add(delimStr & "'whole'")
                                            read = True
                                            i += 4
                                        End If
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'whol'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'who'")
                                    read = True
                                    i += 2
                                End If
                            ElseIf sc(i + 1) = "h" And sc(i + 2) = "e" Then
                                If sc(i + 1) = "h" And sc(i + 2) = "e" And sc(i + 3) = "n" Then
                                    If sc(i + 4) = "(" Then
                                        symbolCtr += 1
                                        objList = dGridLexi.Items.Add(symbolCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add("when")
                                        objList.SubItems.Add("when")
                                        objList.SubItems.Add(" ")
                                        read = True
                                        i += 3
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(line)
                                        objList.SubItems.Add(delimStr & "'when'")
                                        read = True
                                        i += 3
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'whe'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'wh'")
                                read = True
                                i += 1
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'w'")
                            read = True
                        End If
                    ElseIf sc(i) = "z" Then
                        If sc(i + 1) = "t" Then
                            If sc(i + 1) = "t" And sc(i + 2) = "r" Then
                                If sc(i + 3) = " " Or sc(i + 3) = "(" Then
                                    symbolCtr += 1
                                    objList = dGridLexi.Items.Add(symbolCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add("ztr")
                                    objList.SubItems.Add("ztr")
                                    objList.SubItems.Add(" ")
                                    read = True
                                    i += 2
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(line)
                                    objList.SubItems.Add(delimStr & "'ztr'")
                                    read = True
                                    i += 2
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'zt'")
                                read = True
                                i += 1
                            End If
                        ElseIf sc(i + 1) = "r" And sc(i + 2) = "e" And sc(i + 3) = "v" Then
                            If sc(i + 4) = " " Or sc(i + 4) = "(" Then
                                symbolCtr += 1
                                objList = dGridLexi.Items.Add(symbolCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add("zrev")
                                objList.SubItems.Add("zrev")
                                objList.SubItems.Add(" ")
                                read = True
                                i += 3
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'zrev'")
                                read = True
                                i += 3
                            End If
                        ElseIf sc(i + 1) = "c" And sc(i + 2) = "a" And sc(i + 3) = "t" Then
                            If sc(i + 4) = " " Or sc(i + 4) = "(" Then
                                symbolCtr += 1
                                objList = dGridLexi.Items.Add(symbolCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add("zcat")
                                objList.SubItems.Add("zcat")
                                objList.SubItems.Add(" ")
                                read = True
                                i += 3
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'zcat'")
                                read = True
                                i += 3
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'z'")
                            read = True
                        End If
                    ElseIf sc(i) = "x" Then
                        If sc(i + 1) = "l" Then
                    If sc(i + 1) = "l" And sc(i + 2) = "e" And sc(i + 3) = "a" And sc(i + 4) = "r" Then
                        If sc(i + 5) = "(" Or sc(i + 5) = " " Then
                            symbolCtr += 1
                            objList = dGridLexi.Items.Add(symbolCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add("xlear")
                            objList.SubItems.Add("xlear")
                            objList.SubItems.Add(" ")
                            read = True
                            i += 4
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'xlear'")
                            read = True
                            i += 4
                        End If
                    End If
                ElseIf sc(i + 1) = "n" Then
                    If sc(i + 1) = "n" And sc(i + 2) = "o" And sc(i + 3) = "r" And sc(i + 4) = "e" Then
                        If sc(i + 5) = "(" Or sc(i + 5) = " " Then
                            symbolCtr += 1
                            objList = dGridLexi.Items.Add(symbolCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add("xnore")
                            objList.SubItems.Add("xnore")
                            objList.SubItems.Add(" ")
                            read = True
                            i += 4
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'xnore'")
                            read = True
                            i += 4
                        End If
                    End If
                ElseIf sc(i + 1) = "f" Then
                    If sc(i + 1) = "f" And sc(i + 2) = "a" And sc(i + 3) = "i" And sc(i + 4) = "l" Then
                        If sc(i + 5) = "(" Or sc(i + 5) = " " Then
                            symbolCtr += 1
                            objList = dGridLexi.Items.Add(symbolCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add("xfail")
                            objList.SubItems.Add("xfail")
                            objList.SubItems.Add(" ")
                            read = True
                            i += 4
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'xfail'")
                            read = True
                            i += 4
                        End If
                    End If
                End If
            End If
            'END NG w

            '------------------------OPERATORS
            If sc(i) = "=" Then
                If sc(i + 1) = "=" Then
                    If sc(i + 2) = " " Or sc(i + 2) = "@" Or sc(i + 2) = "(" Or sc(i + 2) = "~" Or sc(i + 2) = """" Or Char.IsDigit(sc(i + 2)) Or sc(i + 2) = "t" Or sc(i + 2) = "f" Or sc(i + 2) = "n" Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add("==")
                        objList.SubItems.Add("relOp2")
                        objList.SubItems.Add("relOp, ==")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'=='")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = " " Or sc(i + 1) = "@" Or sc(i + 1) = "(" Or sc(i + 1) = "~" Or sc(i + 1) = "{" Or sc(i + 1) = """" Or Char.IsDigit(sc(i + 1)) Or sc(i + 1) = "t" Or sc(i + 1) = "f" Then
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add("=")
                    objList.SubItems.Add("assgnOp")
                    objList.SubItems.Add("assgnOp, =")
                    read = True
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'='")
                    read = True
                End If
            End If
            'END NG =

            If sc(i) = "+" Then
                If sc(i + 1) = "+" Then
                    If sc(i + 2) = " " Or sc(i + 2) = "@" Or sc(i + 2) = "~" Or sc(i + 2) = "\" Or sc(i + 2) = ")" Or Char.IsDigit(sc(i + 2)) Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add("++")
                        objList.SubItems.Add("increOp")
                        objList.SubItems.Add("increOp, ++")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'++'")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = "=" Then
                    If sc(i + 2) = " " Or sc(i + 2) = "@" Or sc(i + 2) = "(" Or sc(i + 2) = "~" Or Char.IsDigit(sc(i + 2)) Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add("+=")
                        objList.SubItems.Add("assgnOp2")
                        objList.SubItems.Add("assgnOp, +=")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'+='")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = " " Or sc(i + 1) = "@" Or sc(i + 1) = "(" Or sc(i + 1) = "~" Or Char.IsDigit(sc(i + 1)) Then
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add("+")
                    objList.SubItems.Add("mathOp")
                    objList.SubItems.Add("addOp, +")
                    read = True
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'+'")
                    read = True
                End If
            End If
            'END NG +

            If sc(i) = "-" Then
                If sc(i + 1) = "-" Then
                    If sc(i + 2) = " " Or sc(i + 2) = "@" Or sc(i + 2) = "~" Or sc(i + 2) = "\" Or sc(i + 2) = ")" Or Char.IsDigit(sc(i + 2)) Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add("--")
                        objList.SubItems.Add("decreOp")
                        objList.SubItems.Add("decreOp, --")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'--'")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = "=" Then
                    If sc(i + 2) = " " Or sc(i + 2) = "@" Or sc(i + 2) = "(" Or sc(i + 2) = "~" Or Char.IsDigit(sc(i + 2)) Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add("-=")
                        objList.SubItems.Add("assgnOp2")
                        objList.SubItems.Add("assgnOp, -=")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'-='")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = " " Or sc(i + 1) = "@" Or sc(i + 1) = "(" Or sc(i + 1) = "~" Or Char.IsDigit(sc(i + 1)) Then
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add("-")
                    objList.SubItems.Add("mathOp")
                    objList.SubItems.Add("subOp, -")
                    read = True
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'-'")
                    read = True
                End If
            End If
            'END NG -

            If sc(i) = "*" Then
                If sc(i + 1) = "=" Then
                    If sc(i + 2) = " " Or sc(i + 2) = "@" Or sc(i + 2) = "(" Or sc(i + 2) = "~" Or Char.IsDigit(sc(i + 2)) Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add("*=")
                        objList.SubItems.Add("assgnOp2")
                        objList.SubItems.Add("assgnOp, *=")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'*='")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = " " Or sc(i + 1) = "@" Or sc(i + 1) = "(" Or sc(i + 1) = "~" Or Char.IsDigit(sc(i + 1)) Then
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add("*")
                    objList.SubItems.Add("mathOp")
                    objList.SubItems.Add("mulOp, *")
                    read = True
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'*'")
                    read = True
                End If
            End If
            'END NG *

            If sc(i) = "/" Then
                If sc(i + 1) = "=" Then
                    If sc(i + 2) = " " Or sc(i + 2) = "@" Or sc(i + 2) = "(" Or sc(i + 2) = "~" Or Char.IsDigit(sc(i + 2)) Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add("/=")
                        objList.SubItems.Add("assgnOp2")
                        objList.SubItems.Add("assgnOp, /=")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'/='")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = " " Or sc(i + 1) = "@" Or sc(i + 1) = "(" Or sc(i + 1) = "~" Or Char.IsDigit(sc(i + 1)) Then
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add("/")
                    objList.SubItems.Add("mathOp")
                    objList.SubItems.Add("mulOp, /")
                    read = True
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'/'")
                    read = True
                End If
            End If
            'END NG /

            If sc(i) = "%" Then
                If sc(i + 1) = "=" Then
                    If sc(i + 2) = " " Or sc(i + 2) = "@" Or sc(i + 2) = "(" Or sc(i + 2) = "~" Or Char.IsDigit(sc(i + 2)) Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add("%=")
                        objList.SubItems.Add("assgnOp2")
                        objList.SubItems.Add("assgnOp, %=")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'%='")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = " " Or sc(i + 1) = "@" Or sc(i + 1) = "(" Or sc(i + 1) = "~" Or Char.IsDigit(sc(i + 1)) Then
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add("%")
                    objList.SubItems.Add("mathOp")
                    objList.SubItems.Add("mulOp, %")
                    read = True
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'%'")
                    read = True
                End If
            End If
            'END NG %

            If sc(i) = "!" Then
                If sc(i + 1) = "=" Then
                    If sc(i + 2) = " " Or sc(i + 2) = "@" Or sc(i + 2) = "(" Or sc(i + 2) = "~" Or sc(i + 2) = """" Or sc(i + 2) = "f" Or sc(i + 2) = "t" Or sc(i + 2) = "n" Or Char.IsDigit(sc(i + 2)) Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add("!=")
                        objList.SubItems.Add("relOp2")
                        objList.SubItems.Add("relOp, !=")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'!='")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = "+" Then
                    If sc(i + 2) = " " Or sc(i + 2) = "@" Or Char.IsLetter(sc(1 + 2)) Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add("!+")
                        objList.SubItems.Add("!+")
                        objList.SubItems.Add("structOp, !+")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'!+'")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = " " Or sc(i + 1) = "(" Or sc(i + 1) = "@" Or sc(i + 1) = "t" Or sc(i + 1) = "f" Then
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add("!")
                    objList.SubItems.Add("!")
                    objList.SubItems.Add("logOp, !")
                    read = True
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'!'")
                    read = True
                End If
            End If
            'END NG !

            If sc(i) = "<" Then
                If sc(i + 1) = "<" Then
                    If sc(i + 2) = " " Or sc(i + 2) = "#" Or sc(i + 2) = "@" Or sc(i + 2) = "~" Or sc(i + 2) = "(" Or sc(i + 2) = "w" Or sc(i + 2) = "t" Or sc(i + 2) = "f" Or sc(i + 2) = "c" Or sc(i + 2) = "r" Or sc(i + 2) = "d" Or sc(i + 2) = "newline" Or Not inArray(sc(i + 2), allsym, 95) Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add("<<")
                        objList.SubItems.Add("opsymbol")
                        objList.SubItems.Add("opsymbol")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'<<'")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = "=" Then
                    If sc(i + 2) = " " Or sc(i + 2) = "@" Or sc(i + 2) = "(" Or sc(i + 2) = "~" Or Char.IsDigit(sc(i + 2)) Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add("<=")
                        objList.SubItems.Add("relOp1")
                        objList.SubItems.Add("relOp, <=")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'<='")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = " " Or sc(i + 1) = "@" Or sc(i + 1) = "(" Or sc(i + 1) = "~" Or Char.IsDigit(sc(i + 1)) Then
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add("<")
                    objList.SubItems.Add("relOp1")
                    objList.SubItems.Add("relOp, <")
                    read = True
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'<'")
                    read = True
                End If
            End If
            'END NG <

            If sc(i) = ">" Then
                If sc(i + 1) = ">" Then
                    If sc(i + 2) = " " Or sc(i + 2) = "#" Or sc(i + 2) = "@" Or sc(i + 2) = "\" Or sc(i + 2) = "d" Or sc(i + 2) = "newline" Or Not inArray(sc(i + 2), allsym, 95) Then 'pending nl
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(">>")
                        objList.SubItems.Add("clsymbol")
                        objList.SubItems.Add("clsymbol")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'>>'")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = "=" Then
                    If sc(i + 2) = " " Or sc(i + 2) = "@" Or sc(i + 2) = "(" Or sc(i + 2) = "~" Or Char.IsDigit(sc(i + 2)) Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(">=")
                        objList.SubItems.Add("relOp1")
                        objList.SubItems.Add("relOp, >=")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'>='")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = " " Or sc(i + 1) = "@" Or sc(i + 1) = "(" Or sc(i + 1) = "~" Or Char.IsDigit(sc(i + 1)) Then
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(">")
                    objList.SubItems.Add("relOp1")
                    objList.SubItems.Add("relOp, <")
                    read = True
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'>'")
                    read = True
                End If
            End If
            'END NG >

            If sc(i) = ":" Then
                If sc(i + 1) = ">" Then
                    If sc(i + 2) = " " Or sc(i + 2) = "@" Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(":>")
                        objList.SubItems.Add(":>")
                        objList.SubItems.Add("input symbol")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "':>'")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = "<" Then
                    If sc(i + 2) = " " Or sc(i + 2) = "@" Or sc(i + 2) = ":" _
                        Or sc(i + 2) = "(" Or sc(i + 2) = """" Or Char.IsDigit(sc(i + 2)) Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(":<")
                        objList.SubItems.Add(":<")
                        objList.SubItems.Add("output symbol")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "':<'")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = "n" Then
                    If sc(i + 2) = " " Or sc(i + 2) = ":" Or sc(i + 2) = "\" Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(":n")
                        objList.SubItems.Add(":n")
                        objList.SubItems.Add("newline symbol")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "':n'")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = "t" Then
                    If sc(i + 2) = " " Or sc(i + 2) = ":" Or sc(i + 2) = "\" Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(":t")
                        objList.SubItems.Add(":t")
                        objList.SubItems.Add("tab symbol")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "':t'")
                        i += 1
                        read = True
                    End If
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "':'")
                    read = True
                End If
            End If
            'END NG :

            If sc(i) = "^" Then
                If sc(i + 1) = " " Or sc(i + 1) = "@" Or sc(i + 1) = "(" Or sc(i + 1) = "~" Or Char.IsDigit(sc(i + 1)) Then
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add("^")
                    objList.SubItems.Add("mathOp")
                    objList.SubItems.Add("powerOp, ^")
                    read = True
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'^'")
                    read = True
                End If
            End If
            'END NG ^

            If sc(i) = "&" Then
                If sc(i + 1) = " " Or sc(i + 1) = "(" Then
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add("&")
                    objList.SubItems.Add("logOp")
                    objList.SubItems.Add("logOp, &")
                    read = True
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'&'")
                    read = True
                End If
            End If
            'END NG &

            If sc(i) = "|" Then
                If sc(i + 1) = " " Or sc(i + 1) = "(" Then
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add("|")
                    objList.SubItems.Add("logOp")
                    objList.SubItems.Add("logOp, |")
                    read = True
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'|'")
                    read = True
                End If
            End If
            'END NG |

            If sc(i) = "(" Then
                If sc(i + 1) = " " Or sc(i + 1) = "@" Or sc(i + 1) = "(" Or sc(i + 1) = ")" Or sc(i + 1) = "~" _
                        Or sc(i + 1) = "+" Or sc(i + 1) = "-" Or sc(i + 1) = "f" Or sc(i + 1) = "t" Or sc(i + 1) = "w" _
                        Or sc(i + 1) = """" Or sc(i + 1) = "!" Or sc(i + 1) = "'" Or Char.IsDigit(sc(i + 1)) Then
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add("(")
                    objList.SubItems.Add("oppar")
                    objList.SubItems.Add("oppar")
                    read = True
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'('")
                    read = True
                End If
            End If
            'END NG (

            If sc(i) = ")" Then
                If sc(i + 1) = " " Or sc(i + 1) = ")" Or sc(i + 1) = "," Or sc(i + 1) = ":" _
                Or sc(i + 1) = "\" Or sc(i + 1) = "+" Or sc(i + 1) = "-" Or sc(i + 1) = "*" _
                Or sc(i + 1) = "/" Or sc(i + 1) = "%" Or sc(i + 1) = "^" Or sc(i + 1) = "&" _
                Or sc(i + 1) = "|" Or sc(i + 1) = "<" Or sc(i + 1) = ">" Or sc(i + 1) = "=" _
                Or sc(i + 1) = "!" Or sc(i + 1) = "#" Or sc(i + 1) = "}" Or sc(i + 1) = "newline" _
                Or Not inArray(sc(i + 1), allsym, 95) Then 'delim ang @
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(")")
                    objList.SubItems.Add("clpar")
                    objList.SubItems.Add("clpar")
                    read = True
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "')'")
                    read = True
                End If
            End If
            'END NG )

            If sc(i) = "[" Then
                If sc(i + 1) = " " Or sc(i + 1) = "@" Or sc(i + 1) = "]" Or Char.IsDigit(sc(i + 1)) Then
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add("[")
                    objList.SubItems.Add("opsquare")
                    objList.SubItems.Add("opsquare")
                    read = True
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'['")
                    read = True
                End If
            End If
            'END NG [

            If sc(i) = "]" Then
                If sc(i + 1) = " " Or sc(i + 1) = "@" Or sc(i + 1) = "\" _
                Or sc(i + 1) = "," Or sc(i + 1) = ":" Or sc(i + 1) = "+" _
                Or sc(i + 1) = "-" Or sc(i + 1) = "*" Or sc(i + 1) = "/" _
                Or sc(i + 1) = "%" Or sc(i + 1) = "^" Or sc(i + 1) = "&" _
                Or sc(i + 1) = "|" Or sc(i + 1) = "<" Or sc(i + 1) = ">" _
                Or sc(i + 1) = "=" Or sc(i + 1) = "!" Or sc(i + 1) = "[" Or sc(i + 1) = ")" Then
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add("]")
                    objList.SubItems.Add("clsquare")
                    objList.SubItems.Add("clsquare")
                    read = True
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "']'")
                    read = True
                End If
            End If
            'END NG ]

            If sc(i) = "{" Then
                If sc(i + 1) = " " Or sc(i + 1) = "(" Or sc(i + 1) = "~" Or sc(i + 1) = """" Or sc(i + 1) = "f" _
                        Or sc(i + 1) = "t" Or sc(i + 1) = "@" Or Char.IsDigit(sc(i + 1)) Then
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add("{")
                    objList.SubItems.Add("opcurly")
                    objList.SubItems.Add("opcurly")
                    read = True
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'{'")
                    read = True
                End If
            End If
            'END NG {

            If sc(i) = "}" Then
                If sc(i + 1) = " " Or sc(i + 1) = "\" Or sc(i + 1) = "," Then
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add("}")
                    objList.SubItems.Add("clcurly")
                    objList.SubItems.Add("clcurly")
                    read = True
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'}'")
                    read = True
                End If
            End If
            'END NG }

            If sc(i) = ";" Then
                If i + 1 < sourcecode.Length Then
                    If sc(i + 1) = " " Or sc(i + 1) = "<" Or sc(i + 1) = "#" Or sc(i + 1) = "t" Or sc(i + 1) = "newline" Or Not inArray(sc(i + 1), allsym, 95) Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(";")
                        objList.SubItems.Add(";")
                        objList.SubItems.Add("switch terminal symbol")
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "';'")
                        read = True
                    End If
                End If
            End If
            'END NG ;

            If sc(i) = "?" Then
                If i + 1 < sourcecode.Length Then
                    If sc(i + 1) = " " Or sc(i + 1) = "@" Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add("?")
                        objList.SubItems.Add("?")
                        objList.SubItems.Add("ternary operator")
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'?'")
                        read = True
                    End If
                End If
            End If
            'END NG ?

            If sc(i) = "'" Then
                If sc(i + 1) = "\" Then
                    If sc(i + 1) = "\" And sc(i + 2) = "0" Then
                        If sc(i + 1) = "\" And sc(i + 2) = "0" And sc(i + 3) = "'" Then
                            If sc(i + 4) = " " Or sc(i + 4) = ")" Then
                                symbolCtr += 1
                                objList = dGridLexi.Items.Add(symbolCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add("'\0'")
                                objList.SubItems.Add("'\0'")
                                objList.SubItems.Add("end of char")
                                i += 3
                                read = True
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(line)
                                objList.SubItems.Add(delimStr & "'\0'")
                                i += 3
                                read = True
                            End If
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'\0")
                            i += 2
                            read = True
                        End If
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'\")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = "'" Then
                    If sc(i + 2) = " " Or sc(i + 2) = ")" Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add("''")
                        objList.SubItems.Add("''")
                        objList.SubItems.Add("empty char")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "''")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = "*" Then
                    If sc(i + 1) = "*" And sc(i + 2) = "'" Then
                        If sc(i + 3) = " " Or sc(i + 3) = "\" Then
                            symbolCtr += 1
                            objList = dGridLexi.Items.Add(symbolCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add("'*'")
                            objList.SubItems.Add("'*'")
                            objList.SubItems.Add("char")
                            i += 2
                            read = True
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'*'")
                            i += 2
                            read = True
                        End If
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'*")
                        i += 1
                        read = True
                    End If
                ElseIf Char.IsLetterOrDigit(sc(i + 1)) Then
                    If sc(i + 2) = "'" Then
                        If sc(i + 3) = " " Then
                            symbolCtr += 1
                            objList = dGridLexi.Items.Add(symbolCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add("'" & sc(i + 1) & "'")
                            objList.SubItems.Add("valuu")
                            objList.SubItems.Add("char")
                            i += 2
                            read = True
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & "'val'")
                            i += 2
                            read = True
                        End If
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'val")
                        i += 1
                        read = True
                    End If
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'")
                    read = True
                End If
                'END NG '
            End If

            If sc(i) = "#" Then
                cmnt = ""
                read = True
                Dim x As Integer = 1
                Dim start As Integer = x
                Dim point As Integer = line

                While i + x + 1 < sourcecode.Length
                    If Not (Microsoft.VisualBasic.AscW(sc(i + x)) = 10) Then
                        x += 1
                    Else
                        Exit While
                    End If
                End While

                While Not (start = x)
                    cmnt = cmnt & sc(i + start)
                    start += 1
                End While
                symbolCtr += 1
                objList = dGridLexi.Items.Add(symbolCtr)
                objList.SubItems.Add(line)
                objList.SubItems.Add("#" & cmnt)
                objList.SubItems.Add("comment")
                objList.SubItems.Add("comment")
                read = True
                i += x
            End If
            'END NG #

            If sc(i) = "\" Then
                If i + 1 < sourcecode.Length Then
                    If sc(i + 1) = " " Or sc(i + 1) = "#" Or sc(i + 1) = "(" Or sc(i + 1) = ">" Or sc(i + 1) = "@" _
                        Or sc(i + 1) = "newline" Or Not inArray(sc(i + 1), allsym, 95) Then 'pending nl
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add("\")
                        objList.SubItems.Add("\")
                        objList.SubItems.Add("statement terminator")
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'\'")
                        read = True
                    End If
                End If
            End If
            'END NG \

            If sc(i) = "," Then
                If i + 1 < sourcecode.Length Then
                    If sc(i + 1) = " " Or sc(i + 1) = "@" Or sc(i + 1) = """" Or sc(i + 1) = "(" Or sc(i + 1) = "~" _
                        Or sc(i + 1) = "f" Or sc(i + 1) = "t" Or sc(i + 1) = "w" Or Char.IsDigit(sc(i + 1)) Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(",")
                        objList.SubItems.Add(",")
                        objList.SubItems.Add("separator symbol")
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "','")
                        read = True
                    End If
                End If
            End If
            'END NG ,

            If sc(i) = "~" Then
                If i + 1 < sourcecode.Length Then
                    If sc(i + 1) = "@" Or sc(i + 1) = "(" Or sc(i + 1) = " " Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add("~")
                        objList.SubItems.Add("~")
                        objList.SubItems.Add("negOp, ~, unary")
                        read = True
                    ElseIf Char.IsDigit(sc(i + 1)) Then 'leading
                        neg = True
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'~'")
                        read = True
                    End If
                End If
            End If
            'END NG ~

            If sc(i) = "." Then
                If sc(i + 1) = "+" Then
                    If sc(i + 2) = " " Or sc(i + 2) = "@" Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(".+")
                        objList.SubItems.Add(".+")
                        objList.SubItems.Add("strOp, .+, binary")
                        i += 1
                        read = True
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'.+'")
                        i += 1
                        read = True
                    End If
                ElseIf sc(i + 1) = " " Or sc(i + 1) = "i" Or sc(i + 1) = "l" Or sc(i + 1) = "z" Then
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(".")
                    objList.SubItems.Add(".")
                    objList.SubItems.Add(" ")
                    read = True
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'.'")
                    read = True
                End If
            End If
            'END NG .

            '-----------------textlit
            If sc(i) = """" Then
                str = ""
                read = True
                Dim x As Integer = 1
                Dim start As Integer = x
                Dim point As Integer = line
                While Not (sc(i + x) = """" Or Not inArray(sc(i + x), allsym, 95)) And i + x + 1 < sourcecode.Length 'outer "
                    x += 1
                End While

                While Not (start = x)
                    str = str & sc(i + start)
                    start += 1
                End While

                If sc(i + x) = """" Then
                    If str.Length <= 500 Then
                        If sc(i + x + 1) = " " Or sc(i + x + 1) = ":" Or sc(i + x + 1) = ";" Or sc(i + x + 1) = "\" _
                        Or sc(i + x + 1) = ")" Or sc(i + x + 1) = "," Or sc(i + x + 1) = "}" Or sc(i + x + 1) = "!" Then
                            symbolCtr += 1
                            objList = dGridLexi.Items.Add(symbolCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add("""" & str & """")
                            objList.SubItems.Add("textlit")
                            objList.SubItems.Add("textlit, " & """" & str & """")
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add(delimStr & """" & str & """")
                        End If
                    Else
                        If sc(i + x + 1) = " " Or sc(i + x + 1) = ":" Or sc(i + x + 1) = ";" Or sc(i + x + 1) = "\" _
                        Or sc(i + x + 1) = ")" Or sc(i + x + 1) = "," Or sc(i + x + 1) = "}" Or sc(i + x + 1) = "!" Then
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add("Invalid textlit. Exceed max. no of character in string")
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(line)
                            objList.SubItems.Add("Exceed max. no of character in string & Invalid lexeme")
                        End If
                    End If
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add("""" & str & " , Unterminated string")
                End If
                read = True
                i += x
            End If

            '-----------------NUMLIT
            If Char.IsDigit(sc(i)) Then
                Dim number As String = ""
                number = number + sc(i)
                Dim ctr1 As Integer = i + 1
                Dim length As Integer = 0
                While ctr1 < sourcecode.Length
                    If Char.IsDigit(sc(ctr1)) And length < 10 Then
                        number = number + sc(ctr1)
                        ctr1 += 1
                        length += 1
                    Else
                        Exit While
                    End If
                End While

                If sc(ctr1) = " " Or sc(ctr1) = "," Or sc(ctr1) = "\" _
                Or sc(ctr1) = "]" Or sc(ctr1) = "+" Or sc(ctr1) = "-" Or sc(ctr1) = "}" _
                Or sc(ctr1) = "*" Or sc(ctr1) = "/" Or sc(ctr1) = "%" Or sc(ctr1) = "^" _
                Or sc(ctr1) = "<" Or sc(ctr1) = ";" Or sc(ctr1) = ">" Or sc(ctr1) = "'" Or sc(ctr1) = "=" Or sc(ctr1) = ":" Or sc(ctr1) = ")" Then
                    symbolCtr += 1
                    objList = dGridLexi.Items.Add(symbolCtr)
                    objList.SubItems.Add(line)
                    If neg = True Then
                        objList.SubItems.Add("~" & number)
                        objList.SubItems.Add("wholelit")
                        objList.SubItems.Add("wholelit, ~" & number)
                    Else
                        objList.SubItems.Add(number)
                        objList.SubItems.Add("wholelit")
                        objList.SubItems.Add("wholelit, " & number)
                    End If
                    read = True
                    i = ctr1 - 1
                    neg = False

                ElseIf sc(ctr1) = "." Then
                    number = number + sc(ctr1)
                    Dim ctr2 As Integer = ctr1 + 1
                    Dim length1 As Integer = 0
                    While ctr2 < sourcecode.Length
                        If Char.IsDigit(sc(ctr2)) And length1 < 5 Then
                            number = number + sc(ctr2)
                            ctr2 += 1
                            length1 += 1
                        Else
                            Exit While
                        End If
                    End While

                    If sc(ctr2) = " " Or sc(ctr2) = "," Or sc(ctr2) = "\" _
                    Or sc(ctr2) = "]" Or sc(ctr2) = "+" Or sc(ctr2) = "-" Or sc(ctr2) = "}" _
                    Or sc(ctr2) = "*" Or sc(ctr2) = "/" Or sc(ctr2) = "%" Or sc(ctr2) = "^" _
                    Or sc(ctr2) = "<" Or sc(ctr2) = ";" Or sc(ctr2) = ">" Or sc(ctr2) = "'" Or sc(ctr2) = "=" Or sc(ctr2) = ":" Or sc(ctr2) = ")" Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        If neg = True Then
                            objList.SubItems.Add("~" & number)
                            objList.SubItems.Add("fraclit")
                            objList.SubItems.Add("fraclit, ~" & number)
                        Else
                            objList.SubItems.Add(number)
                            objList.SubItems.Add("wholelit")
                            objList.SubItems.Add("wholelit, " & number)
                        End If
                        read = True
                        i = ctr2 - 1
                        neg = False
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        If neg = True Then
                            objList.SubItems.Add(delimStr & "'~" & number & "'")
                        Else
                            objList.SubItems.Add(delimStr & "'" & number & "'")
                        End If
                        read = True
                        i = ctr2 - 1
                        neg = False
                    End If
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    If neg = True Then
                        objList.SubItems.Add(delimStr & "'~" & number & "'")
                    Else
                        objList.SubItems.Add(delimStr & "'" & number & "'")
                    End If
                    read = True
                    i = ctr1 - 1
                    neg = False
                End If
            End If
            'END NG digit

            '-----------------IDENTIFIER
            If sc(i) = "@" Then
                Dim ident As String = "@"
                If Char.IsLower(sc(i + 1)) Then
                    ident = ident + sc(i + 1)
                    Dim ctr1 As Integer = i + 2
                    Dim length As Integer = 1
                    While ctr1 < sourcecode.Length
                        If (Char.IsLower(sc(ctr1)) Or Char.IsDigit(sc(ctr1)) Or sc(ctr1) = "_") And length < 9 Then
                            ident = ident + sc(ctr1)
                            ctr1 += 1
                            length += 1
                        Else
                            Exit While
                        End If
                    End While

                    If sc(ctr1) = " " Or sc(ctr1) = "," Or sc(ctr1) = "\" _
                    Or sc(ctr1) = "]" Or sc(ctr1) = "[" Or sc(ctr1) = "+" Or sc(ctr1) = "-" Or sc(ctr1) = "^" _
                    Or sc(ctr1) = "*" Or sc(ctr1) = "/" Or sc(ctr1) = "%" Or sc(ctr1) = "(" _
                    Or sc(ctr1) = "<" Or sc(ctr1) = ")" Or sc(ctr1) = ">" Or sc(ctr1) = "=" Or sc(ctr1) = "!" Or sc(ctr1) = ":" Or Not inArray(sc(ctr1), allsym, 95) Then
                        symbolCtr += 1
                        objList = dGridLexi.Items.Add(symbolCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(ident)
                        objList.SubItems.Add("id")
                        objList.SubItems.Add("id")
                        read = True
                        i = ctr1 - 1
                    Else
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(line)
                        objList.SubItems.Add(delimStr & "'" & ident & "'")
                        read = True
                        i = ctr1 - 1
                    End If
                Else
                    '@
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(delimStr & "'" & ident & "'")
                    read = True
                End If
            End If
            'END NG @

            If Microsoft.VisualBasic.AscW(sc(i)) = 10 Then
                symbolCtr += 1
                objList = dGridLexi.Items.Add(symbolCtr)
                objList.SubItems.Add(line)
                objList.SubItems.Add("newline")
                objList.SubItems.Add("newline")
                objList.SubItems.Add("")
                line += 1
                read = True
            End If

            If Char.IsWhiteSpace(sc(i)) Then
                read = True
            End If

            If Not (read) Then
                If Char.IsLetter(sc(i)) Or sc(i) = "`" Or sc(i) = "$" Or sc(i) = "?" Then
                    Dim x As Integer = i
                    Dim unid As String = ""
                    While x < sourcecode.Length
                        If Char.IsLetter(sc(x)) Or sc(x) = "`" Or sc(x) = "$" Or sc(x) = "?" Then
                            unid = unid + sc(x)
                            x += 1
                        Else
                            Exit While
                        End If
                    End While

                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(unid & " -- Unidentified lexeme")
                    i = x - 1
                Else
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(line)
                    objList.SubItems.Add(sc(i) & " -- Unidentified character")
                End If
            End If

            i += 1 'LAGING NAGMOMOVE NG 1 CHAR
            'MessageBox.Show("sc(i)= " & sc & " i= " & i)
        End While

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnAna.Click
        dGridError.BackColor = Color.Black
        dGridLexi.BackColor = Color.Black
        'semant_table.BackColor = Color.Black
        lexi()
        'syntaxana()
        'identifierList()
        'semantic()
        'If dGridError.Items.Count = 0 Then
        '    translate()
        '    output()
        'End If


    End Sub

    Private Sub semantic()
        Dim dtype(4) As String
        dtype(0) = "whole"
        dtype(1) = "frac"
        dtype(2) = "flag"
        dtype(3) = "text"

        Dim k As Integer = 0
        Dim isMajor As Boolean = False
        Dim errCtr As Integer = 0
        Dim symbolCtr As Integer = 0
        Dim isBoard As Boolean = False
        Dim isFunction As Boolean = False

        While k < dGridLexi.Items.Count
            If setokee(k) = "board" Then
                isBoard = True
            End If

            If setokee(k) = "major" Then
                isBoard = False
                isMajor = True
            End If

            If setokee(k) = "opsymbol" Then
                symbolCtr += 1
            End If

            If setokee(k) = "clsymbol" Then
                symbolCtr -= 1
            End If

            If setokee(k) = "id" Then
                Dim kawntctr As Integer = 0
                Dim identifier As String = dGridLexi.Items.Item(k).SubItems(2).Text() 'name ng id sa lextable @sang
                Dim ctr As Integer = 0
                Dim curind As Integer

                If dGridIden.Items.Count > 1 Then
                    For index As Integer = 0 To dGridIden.Items.Count - 1
                        If dGridIden.Items.Item(index).SubItems(1).Text() = identifier Then 'kung nasa dGridIden yung @sang
                            curind = index
                            Exit For
                        End If
                    Next

                    For index As Integer = curind + 1 To dGridIden.Items.Count - 1
                        If identifier = dGridIden.Items.Item(index).SubItems(1).Text() Then 'kung nasa dGridIden yung @sang
                            ctr += 1
                        End If
                        If ctr >= 1 Then
                            Exit For
                        End If
                    Next

                    If ctr >= 1 Then
                        Dim x As Integer
                        x = k
                        While setokee(x) <> "newline"
                            x -= 1
                        End While

                        If setokee(x + 1) = "whole" Or setokee(x + 1) = "text" Or setokee(x + 1) = "frac" Or setokee(x + 1) = "flag" Then
                            kawntctr += 1
                            errCtr += 1
                            ''objList = semant_table.Items.Add(errCtr)
                            objList.SubItems.Add(selinee(k))
                            objList.SubItems.Add(identifier + " -Multiple declaration of variable")
                        End If
                    End If

                End If

                '========================================================================
                Dim identifier2 As String = dGridLexi.Items.Item(k).SubItems(2).Text() 'name ng id sa lextable @sang
                Dim ctr2 As Integer = 0
                For index As Integer = 0 To dGridIden.Items.Count - 1
                    If identifier2 = dGridIden.Items.Item(index).SubItems(1).Text Then 'kung nasa dGridIden yung @sang
                        ctr2 += 1
                    End If
                Next

                If dGridBoard.Items.Count > 0 Then
                    For index As Integer = 0 To dGridBoard.Items.Count - 1
                        If identifier2 = dGridBoard.Items.Item(index).SubItems(0).Text Then 'kung nasa dGridIden yung @sang
                            ctr2 += 1
                        End If
                    Next
                End If

                If ctr2 < 1 Then
                    errCtr += 1
                    ''objList = semant_table.Items.Add(errCtr)
                    objList.SubItems.Add(selinee(k))
                    objList.SubItems.Add(identifier2 + " -Undeclared variable/board")
                End If
                'GoTo boarde
                '=========================================================================
                Dim identifier3 As String = dGridLexi.Items.Item(k).SubItems(2).Text() 'name ng id sa lextable @sang
                Dim ctr3 As Integer = 0
                Dim cur As Integer

                For index As Integer = 0 To dGridIden.Items.Count - 1
                    If identifier3 = dGridIden.Items.Item(index).SubItems(1).Text Then 'kung nasa dGridIden yung @sang
                        ctr3 += 1
                    End If
                Next

                For index As Integer = 0 To dGridIden.Items.Count - 1
                    If identifier3 = dGridIden.Items.Item(index).SubItems(1).Text Then 'kung nasa dGridIden yung @sang
                        cur = index
                    End If
                Next

                If ctr3 > 0 Then
                    Dim ctr4 As Integer = 0
                    For index As Integer = 0 To dGridLexi.Items.Count - 1
                        If identifier3 = dGridLexi.Items.Item(index).SubItems(2).Text Then 'kung nasa dGridIden yung @sang
                            ctr4 += 1
                        End If
                    Next

                    If dGridBoard.Items.Count > 0 Then
                        For index As Integer = 0 To dGridBoard.Items.Count - 1
                            If identifier3 = dGridBoard.Items.Item(index).SubItems(0).Text Then 'kung nasa dGridIden yung @sang
                                ctr4 += 2
                            End If
                        Next
                    End If

                    If ctr4 < 2 And dGridIden.Items.Item(cur).SubItems(9).Text <> "board" Then
                        errCtr += 1
                        ''objList = semant_table.Items.Add(errCtr)
                        objList.SubItems.Add(selinee(k))
                        objList.SubItems.Add(identifier3 + " -Unused variable")
                    End If
                End If
                '==============================================================================
                Dim identifier4 As String = dGridLexi.Items.Item(k).SubItems(2).Text() 'name ng id sa lextable @sang

                Dim declCount As Integer = 0
                Dim declCtr As Integer = k
                While Not (setokee(declCtr) = "\" Or setokee(declCtr) = "newline" Or inArray(setokee(k), dtype, 4))
                    If setokee(declCtr) = "to" Then
                        declCount += 1
                    End If
                    declCtr -= 1
                End While

                If declCount > 0 Then   'if declaration
                    Dim c As Integer
                    For index As Integer = 0 To dGridIden.Items.Count - 1
                        If dGridIden.Items.Item(index).SubItems(1).Text() = identifier4 Then
                            c = index
                        End If
                    Next

                    Dim curType = dGridIden.Items.Item(c).SubItems(5).Text()
                    If setokee(k + 1) = "assgnOp" Then  'para sa variable
                        Dim datatype As String = dGridIden.Items.Item(c).SubItems(2).Text()
                        Dim val_data As String = dGridIden.Items.Item(c).SubItems(4).Text()
                        Dim value As String = dGridIden.Items.Item(c).SubItems(3).Text()
                        If datatype = "whole" Then
                            If Not (val_data = "wholelit" Or val_data = "null") Then
                                errCtr += 1
                                ''objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(value + " -Invalid value for data type " + datatype)
                            End If
                        ElseIf datatype = "text" Then
                            If Not (val_data = "textlit" Or val_data = "null") Then
                                errCtr += 1
                                ''objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(value + " -Invalid value for data type " + datatype)
                            End If
                        ElseIf datatype = "flag" Then
                            If Not (val_data = "flaglit" Or val_data = "null") Then
                                errCtr += 1
                                ''objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(value + " -Invalid value for data type " + datatype)
                            End If
                        ElseIf datatype = "frac" Then
                            If Not (val_data = "fraclit" Or val_data = "wholelit" Or val_data = "null") Then
                                errCtr += 1
                                ''objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(value + " -Invalid value for data type " + datatype)
                            End If
                        End If
                    ElseIf setokee(k + 1) = "oppar" Then    'para sa function
                        'MessageBox.Show("line= " & selinee(k))
                        Dim kawnt As Integer = k + 1
                        While setokee(kawnt) <> "newline"
                            If setokee(kawnt) = "clpar" Then
                                Exit While
                            End If
                            kawnt += 1
                        End While

                        If setokee(kawnt + 1) = "\" Then
                            Dim datatype2 As String = dGridIden.Items.Item(c).SubItems(2).Text()
                            Dim count As Integer = k + 1
                            Dim counter As Integer = 0
                            While Not setokee(count) = "\"
                                If Not (setokee(count) = datatype2 Or setokee(count) = "," Or setokee(count) = "oppar" Or setokee(count) = "clpar") Then
                                    counter += 1
                                End If
                                count += 1
                            End While
                            If counter >= 1 Then
                                errCtr += 1
                                ''objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add("Data Type of parameter should be the same with the function itself.")
                            End If
                        Else 'PANG FUNCTION DEFINITION
                            Dim datatype2 As String = dGridIden.Items.Item(c).SubItems(2).Text()
                            'MessageBox.Show(datatype2 & "Sa Else")
                            Dim count As Integer = k + 1
                            Dim counter As Integer = 0
                            Dim counter2 As Integer = 0
                            While Not setokee(count) = "clpar"
                                'MessageBox.Show(setokee(count))
                                If Not (setokee(count) = datatype2 Or setokee(count) = "," Or setokee(count) = "to" Or setokee(count) = "id" Or setokee(count) = "opsquare" Or setokee(count) = "clsquare" Or setokee(count) = "oppar" Or setokee(count) = "clpar") Then
                                    counter += 1
                                End If
                                count += 1
                            End While
                            If counter >= 1 Then
                                errCtr += 1
                                ''objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add("Data Type of parameter should be the same with the function itself.")
                            End If

                            count = k + 1
                            If setokee(k + 2) <> "clpar" Then
                                While setokee(count) <> "clpar"
                                    If setokee(count) = "," Then
                                        counter2 += 1
                                    End If
                                    count += 1
                                End While

                                counter2 += 1
                                'MessageBox.Show(cou)
                                If dGridIden.Items.Count > 0 Then
                                    Dim param As String = dGridIden.Items.Item(c).SubItems(8).Text()
                                    If Int(param) <> counter2 Then
                                        errCtr += 1
                                        ''objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add("No. of parameter in function definition is not equal with function declaration.")
                                    End If
                                End If
                            End If
                        End If

                    ElseIf setokee(k + 1) = "opsquare" Then
                        Dim currType As String = dGridIden.Items.Item(c).SubItems(5).Text() 'array1/array2
                        If currType = "array1" Then
                            Dim arrSize As String = dGridIden.Items.Item(c).SubItems(7).Text
                            If Char.IsDigit(arrSize) Then
                                If Int(arrSize) < 1 Or Int(arrSize) > 10 Then
                                    errCtr += 1
                                    ''objList = semant_table.Items.Add(errCtr)
                                    objList.SubItems.Add(selinee(k))
                                    objList.SubItems.Add("Size should be greater than 0 or less than 100")
                                End If
                            Else
                                errCtr += 1
                                ''objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add("Size should be a wholelit or id with data type of 'whole'")
                            End If
                        ElseIf currType = "array2" Then
                            Dim arrSize As String = dGridIden.Items.Item(c).SubItems(7).Text
                            Dim arrSize2 As String = dGridIden.Items.Item(c).SubItems(10).Text
                            If Char.IsDigit(arrSize) Then
                                If Int(arrSize) < 1 Or Int(arrSize) > 10 Then
                                    errCtr += 1
                                    ''objList = semant_table.Items.Add(errCtr)
                                    objList.SubItems.Add(selinee(k))
                                    objList.SubItems.Add("Size should be greater than 0 or less than 10")
                                End If
                            Else
                                errCtr += 1
                                ''objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add("Size should be a wholelit or id with data type of 'whole'")
                            End If

                            If Char.IsDigit(arrSize2) Then
                                If Int(arrSize2) < 1 Or Int(arrSize2) > 10 Then
                                    errCtr += 1
                                    ''objList = semant_table.Items.Add(errCtr)
                                    objList.SubItems.Add(selinee(k))
                                    objList.SubItems.Add("Size should be greater than 0 or less than 10")
                                End If
                            Else
                                errCtr += 1
                                ''objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add("Size should be a wholelit or id with data type of 'whole'")
                            End If
                        End If



                        If setokee(k + 3) = "assgnOp" Or setokee(k + 4) = "assgnOp" Or setokee(k + 5) = "assgnOp" Or setokee(k + 6) = "assgnOp" Or setokee(k + 7) = "assgnOp" Then
                            Dim arrdtype As String = dGridIden.Items.Item(c).SubItems(4).Text()
                            Dim arrType As String = dGridIden.Items.Item(c).SubItems(5).Text()
                            Dim arrcount As Integer = k
                            Dim arrctr As Integer = 0
                            Dim elemCtr As Integer = k + 4
                            Dim commaCtr As Integer = 0
                            Dim parCtr As Integer = 0

                            While setokee(arrcount) <> "assgnOp"
                                arrcount += 1
                            End While

                            While Not (setokee(arrcount) = "\" Or setokee(arrcount) = "clcurly")
                                If Not (setokee(arrcount) = "assgnOp" Or setokee(arrcount) = "opcurly" Or setokee(arrcount) = "clcurly" Or setokee(arrcount) = "oppar" _
                                    Or setokee(arrcount) = "," Or setokee(arrcount) = "clpar" Or setokee(arrcount) = arrdtype) Then
                                    arrctr += 1
                                End If
                                arrcount += 1
                            End While

                            If arrctr > 0 Then
                                errCtr += 1
                                ''objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add("Data Type of element should be the same with the array itself.")
                            End If

                            If arrType = "array1" Then
                                While Not (setokee(elemCtr) = "\" Or setokee(elemCtr) = "clcurly")
                                    If setokee(elemCtr) = "," Then
                                        commaCtr += 1
                                    End If
                                    elemCtr += 1
                                End While

                                Dim arrSize1 As String = ""
                                If Not dGridIden.Items.Item(c).SubItems(7).Text() = "null" Then
                                    arrSize1 = dGridIden.Items.Item(c).SubItems(7).Text()
                                End If

                                If commaCtr >= Int(arrSize1) Then
                                    errCtr += 1
                                    ''objList = semant_table.Items.Add(errCtr)
                                    objList.SubItems.Add(selinee(k))
                                    objList.SubItems.Add("No. of element/s is not within the size of the array.")
                                End If

                            ElseIf arrType = "array2" Then
                                While Not (setokee(elemCtr) = "\" Or setokee(elemCtr) = "clcurly")
                                    If setokee(elemCtr) = "," Then
                                        commaCtr += 1
                                    ElseIf setokee(elemCtr) = "oppar" Then
                                        parCtr += 1
                                    End If
                                    elemCtr += 1
                                End While

                                Dim arrSize1 As String = dGridIden.Items.Item(c).SubItems(7).Text()
                                Dim arrSize2 As String = dGridIden.Items.Item(c).SubItems(10).Text()
                                Dim totalSize As String = Int(arrSize1) * Int(arrSize2)

                                If commaCtr >= totalSize Or commaCtr > 100 Then
                                    errCtr += 1
                                    ''objList = semant_table.Items.Add(errCtr)
                                    objList.SubItems.Add(selinee(k))
                                    objList.SubItems.Add("No. of column/s is not within the size of the array.")
                                End If

                                If parCtr > arrSize1 Or parCtr > 10 Then
                                    errCtr += 1
                                    ''objList = semant_table.Items.Add(errCtr)
                                    objList.SubItems.Add(selinee(k))
                                    objList.SubItems.Add("No. of row/s is not within the size of the array.")
                                End If

                            End If

                        End If
                    End If

                ElseIf declCount = 0 Then   'di declaration

                    If setokee(k) = "id" Then
                        'INDEX  out of bounds
                        If dGridIden.Items.Count > 0 Then
                            Dim setID As String = dGridLexi.Items.Item(k).SubItems(2).Text()
                            Dim d1 As Integer
                            For index As Integer = 0 To dGridIden.Items.Count - 1
                                If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then
                                    d1 = index
                                End If
                            Next

                            Dim setType As String = dGridIden.Items.Item(d1).SubItems(5).Text
                            If setType = "array1" Then
                                Dim getSize As String = dGridIden.Items.Item(d1).SubItems(7).Text
                                If setokee(k + 1) = "wholelit" Then
                                    Dim curIndex As String = dGridLexi.Items.Item(k).SubItems(2).Text
                                    MessageBox.Show(curIndex & " " & getSize)
                                    If curIndex >= getSize Then
                                        errCtr += 1
                                        ''objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add("Index out of bounds")
                                    End If
                                End If
                                '-------------------------------------------------------------------
                                'No. of parameter
                            ElseIf setType = "function" Then
                                Dim getParam As String = dGridIden.Items.Item(d1).SubItems(8).Text
                                Dim getDtype As String = dGridIden.Items.Item(d1).SubItems(2).Text
                                Dim counta As Integer = k + 1
                                Dim paramCtr As Integer = 0

                                If setokee(k + 1) = "oppar" Then
                                    While Not setokee(counta) = "clpar"
                                        If setokee(counta) = "," Then
                                            paramCtr += 1
                                        End If
                                        counta += 1
                                    End While

                                    paramCtr += 1

                                    If getDtype <> "vacant" Then
                                        If paramCtr < Int(getParam) Or paramCtr > Int(getParam) Then
                                            errCtr += 1
                                            ''objList = semant_table.Items.Add(errCtr)
                                            objList.SubItems.Add(selinee(k))
                                            objList.SubItems.Add("No. of parameter is not equal to the declared parameter")
                                        End If
                                    End If

                                    MessageBox.Show("paramCtr= " & paramCtr)
                                    '------------------------------------------------------------------
                                    Dim counta2 As Integer = k + 1

                                    While Not setokee(counta2) = "clpar"
                                        If getDtype = "whole" Then
                                            If setokee(counta2) = "id" Then
                                                Dim currID As String = dGridLexi.Items.Item(counta2).SubItems(2).Text() 'c
                                                Dim counta3 As Integer 'c
                                                For index As Integer = 0 To dGridIden.Items.Count - 1
                                                    If dGridIden.Items.Item(index).SubItems(1).Text() = currID Then 'c
                                                        counta3 = index 'c
                                                    End If
                                                Next

                                                Dim currDType As String = dGridIden.Items.Item(counta3).SubItems(2).Text() 'c
                                                If currDType = "frac" Or currDType = "flag" Or currDType = "text" Then
                                                    errCtr += 1
                                                    ''objList = semant_table.Items.Add(errCtr)
                                                    objList.SubItems.Add(selinee(k))
                                                    objList.SubItems.Add(dGridLexi.Items.Item(counta2).SubItems(2).Text() & " - Invalid data type for parameter")
                                                End If
                                            ElseIf setokee(counta2) = "fraclit" Or setokee(counta2) = "flaglit" Or setokee(counta2) = "textlit" Then
                                                errCtr += 1
                                                ''objList = semant_table.Items.Add(errCtr)
                                                objList.SubItems.Add(selinee(k))
                                                objList.SubItems.Add(dGridLexi.Items.Item(counta2).SubItems(2).Text() & " - Invalid data type for parameter")
                                            End If

                                        ElseIf getDtype = "frac" Then
                                            If setokee(counta2) = "id" Then
                                                Dim currID As String = dGridLexi.Items.Item(counta2).SubItems(2).Text() 'c
                                                Dim counta3 As Integer 'c
                                                For index As Integer = 0 To dGridIden.Items.Count - 1
                                                    If dGridIden.Items.Item(index).SubItems(1).Text() = currID Then 'c
                                                        counta3 = index 'c
                                                    End If
                                                Next

                                                Dim currDType As String = dGridIden.Items.Item(counta3).SubItems(2).Text() 'c
                                                If currDType = "whole" Or currDType = "flag" Or currDType = "text" Then
                                                    errCtr += 1
                                                    ''objList = semant_table.Items.Add(errCtr)
                                                    objList.SubItems.Add(selinee(k))
                                                    objList.SubItems.Add(dGridLexi.Items.Item(counta2).SubItems(2).Text() & " - Invalid data type for parameter")
                                                End If
                                            ElseIf setokee(counta2) = "wholelit" Or setokee(counta2) = "flaglit" Or setokee(counta2) = "textlit" Then
                                                errCtr += 1
                                                ''objList = semant_table.Items.Add(errCtr)
                                                objList.SubItems.Add(selinee(k))
                                                objList.SubItems.Add(dGridLexi.Items.Item(counta2).SubItems(2).Text() & " - Invalid data type for parameter")
                                            End If

                                        ElseIf getDtype = "flag" Then
                                            If setokee(counta2) = "id" Then
                                                Dim currID As String = dGridLexi.Items.Item(counta2).SubItems(2).Text() 'c
                                                Dim counta3 As Integer 'c
                                                For index As Integer = 0 To dGridIden.Items.Count - 1
                                                    If dGridIden.Items.Item(index).SubItems(1).Text() = currID Then 'c
                                                        counta3 = index 'c
                                                    End If
                                                Next

                                                Dim currDType As String = dGridIden.Items.Item(counta3).SubItems(2).Text() 'c
                                                If currDType = "frac" Or currDType = "whole" Or currDType = "text" Then
                                                    errCtr += 1
                                                    ''objList = semant_table.Items.Add(errCtr)
                                                    objList.SubItems.Add(selinee(k))
                                                    objList.SubItems.Add(dGridLexi.Items.Item(counta2).SubItems(2).Text() & " - Invalid data type for parameter")
                                                End If
                                            ElseIf setokee(counta2) = "fraclit" Or setokee(counta2) = "wholelit" Or setokee(counta2) = "textlit" Then
                                                errCtr += 1
                                                ''objList = semant_table.Items.Add(errCtr)
                                                objList.SubItems.Add(selinee(k))
                                                objList.SubItems.Add(dGridLexi.Items.Item(counta2).SubItems(2).Text() & " - Invalid data type for parameter")
                                            End If
                                        ElseIf getDtype = "text" Then
                                            If setokee(counta2) = "id" Then
                                                Dim currID As String = dGridLexi.Items.Item(counta2).SubItems(2).Text() 'c
                                                Dim counta3 As Integer 'c
                                                For index As Integer = 0 To dGridIden.Items.Count - 1
                                                    If dGridIden.Items.Item(index).SubItems(1).Text() = currID Then 'c
                                                        counta3 = index 'c
                                                    End If
                                                Next

                                                Dim currDType As String = dGridIden.Items.Item(counta3).SubItems(2).Text() 'c
                                                If currDType = "frac" Or currDType = "flag" Or currDType = "whole" Then
                                                    errCtr += 1
                                                    ''objList = semant_table.Items.Add(errCtr)
                                                    objList.SubItems.Add(selinee(k))
                                                    objList.SubItems.Add(dGridLexi.Items.Item(counta2).SubItems(2).Text() & " - Invalid data type for parameter")
                                                End If
                                            ElseIf setokee(counta2) = "fraclit" Or setokee(counta2) = "flaglit" Or setokee(counta2) = "wholelit" Then
                                                errCtr += 1
                                                ''objList = semant_table.Items.Add(errCtr)
                                                objList.SubItems.Add(selinee(k))
                                                objList.SubItems.Add(dGridLexi.Items.Item(counta2).SubItems(2).Text() & " - Invalid data type for parameter")
                                            End If
                                        End If
                                        counta2 += 1
                                    End While
                                Else
                                    errCtr += 1
                                    ''objList = semant_table.Items.Add(errCtr)
                                    objList.SubItems.Add(selinee(k))
                                    objList.SubItems.Add(setID & " - is used not as a function")

                                    Dim x As Integer = k + 1
                                    While setokee(x) <> "newline"
                                        x += 1
                                    End While
                                    k = x
                                End If

                                '------------------------------------------------------------------
                            ElseIf setokee(k + 1) = "to" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim boaId As String = dGridLexi.Items.Item(k).SubItems(2).Text()
                                    Dim match As Integer
                                    Dim isMember As Boolean = False
                                    Dim isBoar As Boolean = False
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = boaId Then 'c
                                            match = index 'c
                                        End If
                                    Next

                                    Dim typee As String = dGridIden.Items.Item(match).SubItems(5).Text

                                    If typee <> "board" Then
                                        errCtr += 1
                                        ''objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(boaId & " - is not a board name")
                                    Else
                                        isBoar = True
                                    End If

                                    If isBoar = True Then
                                        Dim boaObj As String = dGridLexi.Items.Item(k + 2).SubItems(2).Text()
                                        For index As Integer = 0 To dGridBoard.Items.Count - 1
                                            If dGridBoard.Items.Item(index).SubItems(0).Text() = boaObj Then 'c
                                                isMember = True
                                            End If
                                        Next

                                        If isMember = True Then
                                            errCtr += 1
                                            ''objList = semant_table.Items.Add(errCtr)
                                            objList.SubItems.Add(selinee(k))
                                            objList.SubItems.Add(boaObj & " - id is already used a board name")
                                        Else
                                            objList = dGridBoard.Items.Add(boaObj)
                                            objList.SubItems.Add(boaId)
                                        End If
                                    End If


                                End If

                            End If
                            'END SA IF-FUNCTION
                        End If
                        'END IF MAY LAMAN YUNG dGridIden
                    End If
                    'END IF ID YUNG SETOKEE(K) PARA SA DECLARATION
                    Dim identifier5 As String = dGridLexi.Items.Item(k).SubItems(2).Text()

                    Dim d As Integer
                    For index As Integer = 0 To dGridIden.Items.Count - 1
                        If dGridIden.Items.Item(index).SubItems(1).Text() = identifier5 Then
                            d = index
                        End If
                    Next

                    Dim curIDType As String = dGridIden.Items.Item(d).SubItems(5).Text()

                    If setokee(k + 1) = "assgnOp" And (setokee(k + 3) = "," Or setokee(k + 3) = "\") Then      'para sa variable
                        If Not curIDType = "constant" Then
                            Dim idDType As String = ""
                            Dim idType As String = ""
                            Dim curID As String = ""

                            If setokee(k + 2) = "id" Then
                                curID = dGridLexi.Items.Item(k + 2).SubItems(2).Text()  '@sang
                                Dim e As Integer
                                For index As Integer = 0 To dGridIden.Items.Count - 1
                                    If dGridIden.Items.Item(index).SubItems(1).Text() = curID Then
                                        e = index
                                    End If
                                Next
                                If dGridIden.Items.Item(e).SubItems(4).Text() = "null" Then
                                    idDType = dGridIden.Items.Item(e).SubItems(2).Text()
                                    If idDType = "whole" Then
                                        idType = "wholelit"
                                    ElseIf idDType = "flag" Then
                                        idType = "flaglit"
                                    ElseIf idDType = "frac" Then
                                        idType = "fraclit"
                                    ElseIf idDType = "text" Then
                                        idType = "textlit"
                                    End If
                                Else
                                    idType = dGridIden.Items.Item(e).SubItems(4).Text()
                                End If
                            Else
                                idType = dGridLexi.Items.Item(k + 2).SubItems(3).Text()
                            End If

                            Dim curDType As String = ""
                            Dim curType As String = ""
                            If dGridIden.Items.Item(d).SubItems(4).Text() = "null" Then
                                curDType = dGridIden.Items.Item(d).SubItems(2).Text()
                                If curDType = "whole" Then
                                    curType = "wholelit"
                                ElseIf curDType = "flag" Then
                                    curType = "flaglit"
                                ElseIf curDType = "frac" Then
                                    curType = "fraclit"
                                ElseIf curDType = "text" Then
                                    curType = "textlit"
                                End If
                            Else
                                curType = dGridIden.Items.Item(d).SubItems(4).Text()
                            End If
                            '-------------------------------------
                            'TYPE MISMATCH SA ASSIGNMENT NG VALUE SA VARIABLE
                            If Not curType = idType Then
                                errCtr += 1
                                ''objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add("Type mismatch.") 'assigning ng value sa var
                            End If

                            'If setokee(k + 2) = "id" Then
                            '    Dim se1Type As String = dGridIden.Items.Item(d).SubItems(5).Text 'if variable talaga yung 1st
                            '    Dim fDType As String = dGridIden.Items.Item(d).SubItems(2).Text
                            '    Dim sID As String = dGridLexi.Items.Item(k + 2).SubItems(2).Text()  '@sang
                            '    Dim sDType As String = ""
                            '    Dim f As Integer
                            '    For index As Integer = 0 To dGridIden.Items.Count - 1
                            '        If dGridIden.Items.Item(index).SubItems(1).Text() = sID Then
                            '            f = index
                            '        End If
                            '    Next
                            '    Dim se2Type As String = dGridIden.Items.Item(f).SubItems(5).Text 'if variable talaga yung 2nd
                            '    sDType = dGridIden.Items.Item(f).SubItems(2).Text

                            '    'MessageBox.Show("Type1= " & se1Type & " ,Type2= " & se2Type)

                            '        If se1Type <> "variable" Then
                            '            errCtr += 1
                            '            'objList = semant_table.Items.Add(errCtr)
                            '            objList.SubItems.Add(selinee(k))
                            '            objList.SubItems.Add(se1Type & " " & dGridIden.Items.Item(d).SubItems(1).Text & " is used as a variable")
                            '        End If

                            '        If se2Type <> "variable" Then
                            '            errCtr += 1
                            '            'objList = semant_table.Items.Add(errCtr)
                            '            objList.SubItems.Add(selinee(k))
                            '            objList.SubItems.Add(se2Type & " " & dGridIden.Items.Item(f).SubItems(1).Text & " is used as a variable")
                            '        End If
                            'End If


                            '--------------------------------------------------------------------
                        Else
                            errCtr += 1
                            ''objList = semant_table.Items.Add(errCtr)
                            objList.SubItems.Add(selinee(k))
                            objList.SubItems.Add("Cannot change value for set")
                        End If
                    ElseIf setokee(k + 1) = "assgnOp" And setokee(k + 2) = "id" Then
                        'MessageBox.Show("assign tayo")
                        Dim fDType As String = dGridIden.Items.Item(d).SubItems(2).Text
                        Dim sID As String = dGridLexi.Items.Item(k + 2).SubItems(2).Text()  '@sang
                        Dim sDType As String = ""
                        Dim f As Integer
                        For index As Integer = 0 To dGridIden.Items.Count - 1
                            If dGridIden.Items.Item(index).SubItems(1).Text() = sID Then
                                f = index
                            End If
                        Next
                        sDType = dGridIden.Items.Item(f).SubItems(2).Text

                        'MessageBox.Show("Type1= " & se1Type & " ,Type2= " & se2Type)
                        If fDType <> sDType Then
                            errCtr += 1
                            ''objList = semant_table.Items.Add(errCtr)
                            objList.SubItems.Add(selinee(k))
                            objList.SubItems.Add("Type mismatch for assigning value to " & dGridIden.Items.Item(d).SubItems(1).Text)
                        End If
                        '------------

                        '-----------------------------------------------------------------
                        'MATH EXP SA TEXT OR FLAG
                    ElseIf setokee(k + 2) = "increOp" Or setokee(k + 2) = "decreOp" Or setokee(k + 3) = "mathOp" _
                         Or setokee(k + 3) = "decreOp" Or setokee(k + 3) = "increOp" Then

                        Dim curDType = dGridIden.Items.Item(d).SubItems(2).Text()
                        If curDType = "text" Or curDType = "flag" Then
                            errCtr += 1
                            ''objList = semant_table.Items.Add(errCtr)
                            objList.SubItems.Add(selinee(k))
                            objList.SubItems.Add("Type mismatch. Can't assign math operation to variable with '" & curDType & "' data type.")
                        End If
                        '--------------------------------------------------------------------
                        'PARA SA ARRAY
                    ElseIf curIDType = "array1" Then
                        If setokee(k + 2) = "wholelit" Or setokee(k + 2) = "id" Then
                            Dim setID As String = dGridLexi.Items.Item(k).SubItems(2).Text()
                            Dim d1 As Integer
                            For index As Integer = 0 To dGridIden.Items.Count - 1
                                If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then
                                    d1 = index
                                End If
                            Next
                            'INDEX OUT OF BOUNDS
                            If dGridIden.Items.Count > 0 Then
                                Dim setType As String = dGridIden.Items.Item(d1).SubItems(5).Text
                                Dim getSize As String = dGridIden.Items.Item(d1).SubItems(7).Text
                                If setType = "array1" Then
                                    If setokee(k + 2) = "wholelit" Then
                                        Dim curIndex As String = dGridLexi.Items.Item(k + 2).SubItems(2).Text
                                        If Int(curIndex) >= Int(getSize) Or Int(curIndex) < 0 Then
                                            errCtr += 1
                                            ''objList = semant_table.Items.Add(errCtr)
                                            objList.SubItems.Add(selinee(k))
                                            objList.SubItems.Add("Index out of bounds ")
                                        End If
                                    ElseIf setokee(k + 2) = "id" Then
                                        Dim sizeID As String = dGridLexi.Items.Item(k + 2).SubItems(2).Text()
                                        Dim d2 As Integer
                                        For index As Integer = 0 To dGridIden.Items.Count - 1
                                            If dGridIden.Items.Item(index).SubItems(1).Text() = sizeID Then
                                                d2 = index
                                            End If
                                        Next

                                        Dim sizeDType As String = dGridIden.Items.Item(d2).SubItems(2).Text
                                        If Not sizeDType = "whole" Then
                                            errCtr += 1
                                            ''objList = semant_table.Items.Add(errCtr)
                                            objList.SubItems.Add(selinee(k))
                                            objList.SubItems.Add("Can't assign variable " & sizeID & " as size of array")
                                        Else
                                            Dim sizeVal As String = dGridIden.Items.Item(d2).SubItems(3).Text
                                            If sizeVal = "null" Then
                                                errCtr += 1
                                                'objList = semant_table.Items.Add(errCtr)
                                                objList.SubItems.Add(selinee(k))
                                                objList.SubItems.Add(sizeID & " - No value is assigned before using as size of array")
                                            Else
                                                If Int(sizeVal) >= Int(getSize) Or Int(sizeVal) < 0 Then
                                                    errCtr += 1
                                                    'objList = semant_table.Items.Add(errCtr)
                                                    objList.SubItems.Add(selinee(k))
                                                    objList.SubItems.Add("Index out of bounds.")
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                            'END IF MAY LAMAN YUNG dGridIden
                        End If

                        If setokee(k + 4) = "assgnOp" Then
                            Dim daType As String = dGridIden.Items.Item(d).SubItems(2).Text
                            If daType = "whole" Then
                                If setokee(k + 5) = "fraclit" Or setokee(k + 5) = "flaglit" Or setokee(k + 5) = "textlit" Then
                                    errCtr += 1
                                    ''objList = semant_table.Items.Add(errCtr)
                                    objList.SubItems.Add(selinee(k))
                                    objList.SubItems.Add("Type mismatch for assigning value to " & dGridIden.Items.Item(d).SubItems(1).Text)
                                ElseIf setokee(k + 5) = "id" Then
                                    Dim cureID = dGridLexi.Items.Item(k + 5).SubItems(2).Text()  '@sang
                                    Dim e As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = cureID Then
                                            e = index
                                        End If
                                    Next

                                    Dim getDT As String = dGridIden.Items.Item(e).SubItems(2).Text()
                                    If getDT <> daType Then
                                        errCtr += 1
                                        ''objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add("Type mismatch for assigning value to " & dGridIden.Items.Item(d).SubItems(1).Text)
                                    End If
                                End If
                            ElseIf daType = "frac" Then
                                If setokee(k + 5) = "wholelit" Or setokee(k + 5) = "flaglit" Or setokee(k + 5) = "textlit" Then
                                    errCtr += 1
                                    ''objList = semant_table.Items.Add(errCtr)
                                    objList.SubItems.Add(selinee(k))
                                    objList.SubItems.Add("Type mismatch for assigning value to " & dGridIden.Items.Item(d).SubItems(1).Text)
                                ElseIf setokee(k + 5) = "id" Then
                                    Dim cureID = dGridLexi.Items.Item(k + 5).SubItems(2).Text()  '@sang
                                    Dim e As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = cureID Then
                                            e = index
                                        End If
                                    Next

                                    Dim getDT As String = dGridIden.Items.Item(e).SubItems(2).Text()
                                    If getDT <> daType Then
                                        errCtr += 1
                                        ''objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add("Type mismatch for assigning value to " & dGridIden.Items.Item(d).SubItems(1).Text)
                                    End If
                                End If
                            ElseIf daType = "flag" Then
                                If setokee(k + 5) = "fraclit" Or setokee(k + 5) = "wholelit" Or setokee(k + 5) = "textlit" Then
                                    errCtr += 1
                                    ''objList = semant_table.Items.Add(errCtr)
                                    objList.SubItems.Add(selinee(k))
                                    objList.SubItems.Add("Type mismatch for assigning value to " & dGridIden.Items.Item(d).SubItems(1).Text)
                                ElseIf setokee(k + 5) = "id" Then
                                    Dim cureID = dGridLexi.Items.Item(k + 5).SubItems(2).Text()  '@sang
                                    Dim e As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = cureID Then
                                            e = index
                                        End If
                                    Next

                                    Dim getDT As String = dGridIden.Items.Item(e).SubItems(2).Text()
                                    If getDT <> daType Then
                                        errCtr += 1
                                        ''objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add("Type mismatch for assigning value to " & dGridIden.Items.Item(d).SubItems(1).Text)
                                    End If
                                End If
                            ElseIf daType = "text" Then
                                If setokee(k + 5) = "fraclit" Or setokee(k + 5) = "flaglit" Or setokee(k + 5) = "wholelit" Then
                                    errCtr += 1
                                    ''objList = semant_table.Items.Add(errCtr)
                                    objList.SubItems.Add(selinee(k))
                                    objList.SubItems.Add("Type mismatch for assigning value to " & dGridIden.Items.Item(d).SubItems(1).Text)
                                ElseIf setokee(k + 5) = "id" Then
                                    Dim cureID = dGridLexi.Items.Item(k + 5).SubItems(2).Text()  '@sang
                                    Dim e As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = cureID Then
                                            e = index
                                        End If
                                    Next

                                    Dim getDT As String = dGridIden.Items.Item(e).SubItems(2).Text()
                                    If getDT <> daType Then
                                        errCtr += 1
                                        ''objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add("Type mismatch for assigning value to " & dGridIden.Items.Item(d).SubItems(1).Text)
                                    End If
                                End If
                            End If
                        End If
                    ElseIf curIDType = "array2" Then
                        If setokee(k + 2) = "wholelit" Or setokee(k + 2) = "id" Then
                            Dim setID As String = dGridLexi.Items.Item(k).SubItems(2).Text()
                            Dim d1 As Integer
                            For index As Integer = 0 To dGridIden.Items.Count - 1
                                If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then
                                    d1 = index
                                End If
                            Next
                            'INDEX OUT OF BOUNDS
                            If dGridIden.Items.Count > 0 Then
                                Dim setType As String = dGridIden.Items.Item(d1).SubItems(5).Text
                                Dim getSize1 As String = dGridIden.Items.Item(d1).SubItems(7).Text
                                Dim getSize2 As String = dGridIden.Items.Item(d1).SubItems(10).Text
                                If setType = "array2" Then
                                    If setokee(k + 2) = "wholelit" Then
                                        Dim curIndex As String = dGridLexi.Items.Item(k + 2).SubItems(2).Text
                                        If Int(curIndex) >= Int(getSize1) Or Int(curIndex) < 0 Then
                                            errCtr += 1
                                            ''objList = semant_table.Items.Add(errCtr)
                                            objList.SubItems.Add(selinee(k))
                                            objList.SubItems.Add("Index1 out of bounds ")
                                        End If
                                    ElseIf setokee(k + 2) = "id" Then
                                        Dim sizeID As String = dGridLexi.Items.Item(k + 2).SubItems(2).Text()
                                        Dim d2 As Integer
                                        For index As Integer = 0 To dGridIden.Items.Count - 1
                                            If dGridIden.Items.Item(index).SubItems(1).Text() = sizeID Then
                                                d2 = index
                                            End If
                                        Next

                                        Dim sizeDType As String = dGridIden.Items.Item(d2).SubItems(2).Text
                                        If Not sizeDType = "whole" Then
                                            errCtr += 1
                                            ''objList = semant_table.Items.Add(errCtr)
                                            objList.SubItems.Add(selinee(k))
                                            objList.SubItems.Add("Can't assign variable " & sizeID & " as index1 of array")
                                        Else
                                            Dim sizeVal As String = dGridIden.Items.Item(d2).SubItems(3).Text
                                            If sizeVal = "null" Then
                                                errCtr += 1
                                                ''objList = semant_table.Items.Add(errCtr)
                                                objList.SubItems.Add(selinee(k))
                                                objList.SubItems.Add(sizeID & " - No value is assigned before using as index1 of array")
                                            Else
                                                If Int(sizeVal) >= Int(getSize1) Or Int(sizeVal) < 0 Then
                                                    errCtr += 1
                                                    ''objList = semant_table.Items.Add(errCtr)
                                                    objList.SubItems.Add(selinee(k))
                                                    objList.SubItems.Add("Index1 out of bounds.")
                                                End If
                                            End If
                                        End If
                                    End If

                                    If setokee(k + 5) = "wholelit" Then
                                        Dim curIndex As String = dGridLexi.Items.Item(k + 5).SubItems(2).Text
                                        If Int(curIndex) >= Int(getSize2) Or Int(curIndex) < 0 Then
                                            errCtr += 1
                                            ''objList = semant_table.Items.Add(errCtr)
                                            objList.SubItems.Add(selinee(k))
                                            objList.SubItems.Add("Index2 out of bounds ")
                                        End If
                                    ElseIf setokee(k + 5) = "id" Then
                                        Dim sizeID As String = dGridLexi.Items.Item(k + 5).SubItems(2).Text()
                                        Dim d2 As Integer
                                        For index As Integer = 0 To dGridIden.Items.Count - 1
                                            If dGridIden.Items.Item(index).SubItems(1).Text() = sizeID Then
                                                d2 = index
                                            End If
                                        Next

                                        Dim sizeDType As String = dGridIden.Items.Item(d2).SubItems(2).Text
                                        If Not sizeDType = "whole" Then
                                            errCtr += 1
                                            ''objList = semant_table.Items.Add(errCtr)
                                            objList.SubItems.Add(selinee(k))
                                            objList.SubItems.Add("Can't assign variable " & sizeID & " as index2 of array")
                                        Else
                                            Dim sizeVal As String = dGridIden.Items.Item(d2).SubItems(3).Text
                                            If sizeVal = "null" Then
                                                errCtr += 1
                                                ''objList = semant_table.Items.Add(errCtr)
                                                objList.SubItems.Add(selinee(k))
                                                objList.SubItems.Add(sizeID & " - No value is assigned before using as index2 of array")
                                            Else
                                                If Int(sizeVal) >= Int(getSize2) Or Int(sizeVal) < 0 Then
                                                    errCtr += 1
                                                    ''objList = semant_table.Items.Add(errCtr)
                                                    objList.SubItems.Add(selinee(k))
                                                    objList.SubItems.Add("Index2 out of bounds.")
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                            'END IF MAY LAMAN YUNG dGridIden
                        End If

                        If setokee(k + 7) = "assgnOp" Then
                            Dim daType As String = dGridIden.Items.Item(d).SubItems(2).Text
                            If daType = "whole" Then
                                If setokee(k + 8) = "fraclit" Or setokee(k + 8) = "flaglit" Or setokee(k + 8) = "textlit" Then
                                    errCtr += 1
                                    ''objList = semant_table.Items.Add(errCtr)
                                    objList.SubItems.Add(selinee(k))
                                    objList.SubItems.Add("Type mismatch for assigning value to " & dGridIden.Items.Item(d).SubItems(1).Text)
                                ElseIf setokee(k + 8) = "id" Then
                                    Dim cureID = dGridLexi.Items.Item(k + 8).SubItems(2).Text()  '@sang
                                    Dim e As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = cureID Then
                                            e = index
                                        End If
                                    Next

                                    Dim getDT As String = dGridIden.Items.Item(e).SubItems(2).Text()
                                    If getDT <> daType Then
                                        errCtr += 1
                                        ''objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add("Type mismatch for assigning value to " & dGridIden.Items.Item(d).SubItems(1).Text)
                                    End If
                                End If
                            ElseIf daType = "frac" Then
                                If setokee(k + 8) = "wholelit" Or setokee(k + 8) = "flaglit" Or setokee(k + 8) = "textlit" Then
                                    errCtr += 1
                                    ''objList = semant_table.Items.Add(errCtr)
                                    objList.SubItems.Add(selinee(k))
                                    objList.SubItems.Add("Type mismatch for assigning value to " & dGridIden.Items.Item(d).SubItems(1).Text)
                                ElseIf setokee(k + 8) = "id" Then
                                    Dim cureID = dGridLexi.Items.Item(k + 8).SubItems(2).Text()  '@sang
                                    Dim e As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = cureID Then
                                            e = index
                                        End If
                                    Next

                                    Dim getDT As String = dGridIden.Items.Item(e).SubItems(2).Text()
                                    If getDT <> daType Then
                                        errCtr += 1
                                        ''objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add("Type mismatch for assigning value to " & dGridIden.Items.Item(d).SubItems(1).Text)
                                    End If
                                End If
                            ElseIf daType = "flag" Then
                                If setokee(k + 8) = "fraclit" Or setokee(k + 8) = "wholelit" Or setokee(k + 8) = "textlit" Then
                                    errCtr += 1
                                    ''objList = semant_table.Items.Add(errCtr)
                                    objList.SubItems.Add(selinee(k))
                                    objList.SubItems.Add("Type mismatch for assigning value to " & dGridIden.Items.Item(d).SubItems(1).Text)
                                ElseIf setokee(k + 8) = "id" Then
                                    Dim cureID = dGridLexi.Items.Item(k + 8).SubItems(2).Text()  '@sang
                                    Dim e As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = cureID Then
                                            e = index
                                        End If
                                    Next

                                    Dim getDT As String = dGridIden.Items.Item(e).SubItems(2).Text()
                                    If getDT <> daType Then
                                        errCtr += 1
                                        ''objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add("Type mismatch for assigning value to " & dGridIden.Items.Item(d).SubItems(1).Text)
                                    End If
                                End If
                            ElseIf daType = "text" Then
                                If setokee(k + 8) = "fraclit" Or setokee(k + 8) = "flaglit" Or setokee(k + 8) = "wholelit" Then
                                    errCtr += 1
                                    ''objList = semant_table.Items.Add(errCtr)
                                    objList.SubItems.Add(selinee(k))
                                    objList.SubItems.Add("Type mismatch for assigning value to " & dGridIden.Items.Item(d).SubItems(1).Text)
                                ElseIf setokee(k + 8) = "id" Then
                                    Dim cureID = dGridLexi.Items.Item(k + 8).SubItems(2).Text()  '@sang
                                    Dim e As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = cureID Then
                                            e = index
                                        End If
                                    Next

                                    Dim getDT As String = dGridIden.Items.Item(e).SubItems(2).Text()
                                    If getDT <> daType Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add("Type mismatch for assigning value to " & dGridIden.Items.Item(d).SubItems(1).Text)
                                    End If
                                End If
                            End If
                        End If

                    End If
                End If
            End If
            If setokee(k) = "mathOp" Then
                If setokee(k - 1) = "id" Then 'c
                    If dGridIden.Items.Count > 0 Then
                        Dim currID As String = dGridLexi.Items.Item(k - 1).SubItems(2).Text() 'c
                        Dim counta As Integer 'c
                        For index As Integer = 0 To dGridIden.Items.Count - 1
                            If dGridIden.Items.Item(index).SubItems(1).Text() = currID Then 'c
                                counta = index 'c
                            End If
                        Next

                        Dim currDType As String = dGridIden.Items.Item(counta).SubItems(2).Text() 'c
                        If currDType = "text" Or currDType = "flag" Then 'c
                            errCtr += 1
                            'objList = semant_table.Items.Add(errCtr)
                            objList.SubItems.Add(selinee(k))
                            objList.SubItems.Add(dGridLexi.Items.Item(k - 1).SubItems(2).Text() & " - Invalid for math expression") 'c
                        ElseIf currDType = "whole" Or currDType = "frac" Then
                            Dim currVal As String = dGridIden.Items.Item(counta).SubItems(3).Text()
                            If currVal = "null" Then
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k - 1).SubItems(2).Text() & " - No value is assigned before using in math expression")
                            End If

                        End If
                    End If
                ElseIf setokee(k - 1) = "textlit" Or setokee(k - 1) = "flaglit" Then
                    errCtr += 1
                    'objList = semant_table.Items.Add(errCtr)
                    objList.SubItems.Add(selinee(k))
                    objList.SubItems.Add(dGridLexi.Items.Item(k - 1).SubItems(2).Text() & " - Invalid for math expression") 'c
                End If

                If setokee(k + 1) = "id" Then 'c
                    If dGridIden.Items.Count > 0 Then
                        Dim currID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text() 'c
                        Dim counta As Integer 'c
                        For index As Integer = 0 To dGridIden.Items.Count - 1
                            If dGridIden.Items.Item(index).SubItems(1).Text() = currID Then 'c
                                counta = index 'c
                            End If
                        Next

                        Dim currDType As String = dGridIden.Items.Item(counta).SubItems(2).Text() 'c
                        If currDType = "text" Or currDType = "flag" Then 'c
                            errCtr += 1
                            'objList = semant_table.Items.Add(errCtr)
                            objList.SubItems.Add(selinee(k))
                            objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid for math expression") 'c
                        ElseIf currDType = "whole" Or currDType = "frac" Then
                            Dim currVal As String = dGridIden.Items.Item(counta).SubItems(3).Text()
                            If currVal = "null" Then
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k - 1).SubItems(2).Text() & " - No value is assigned before using in math expression")
                            End If
                        End If
                    End If
                ElseIf setokee(k + 1) = "textlit" Or setokee(k + 1) = "flaglit" Then
                    errCtr += 1
                    'objList = semant_table.Items.Add(errCtr)
                    objList.SubItems.Add(selinee(k))
                    objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid for math expression") 'c
                End If
            End If

            If setokee(k) = "increOp" Or setokee(k) = "decreOp" Then
                If setokee(k - 1) = "id" Then 'c
                    If dGridIden.Items.Count > 0 Then
                        Dim currID As String = dGridLexi.Items.Item(k - 1).SubItems(2).Text() 'c
                        Dim counta As Integer 'c
                        For index As Integer = 0 To dGridIden.Items.Count - 1
                            If dGridIden.Items.Item(index).SubItems(1).Text() = currID Then 'c
                                counta = index 'c
                            End If
                        Next

                        Dim currDType As String = dGridIden.Items.Item(counta).SubItems(2).Text() 'c
                        If currDType = "text" Or currDType = "flag" Or currDType = "frac" Then 'c
                            errCtr += 1
                            'objList = semant_table.Items.Add(errCtr)
                            objList.SubItems.Add(selinee(k))
                            objList.SubItems.Add(dGridLexi.Items.Item(k - 1).SubItems(2).Text() & " (" & currDType & ") - Invalid for increment/ decrement operation") 'c
                        ElseIf currDType = "whole" Then
                            Dim currVal As String = dGridIden.Items.Item(counta).SubItems(3).Text()
                            If currVal = "null" Then
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k - 1).SubItems(2).Text() & " - No value is assigned before using in incre/decre operation")
                            End If
                        End If
                    End If
                ElseIf setokee(k - 1) = "textlit" Or setokee(k - 1) = "flaglit" Or setokee(k - 1) = "fraclit" Then
                    errCtr += 1
                    'objList = semant_table.Items.Add(errCtr)
                    objList.SubItems.Add(selinee(k))
                    objList.SubItems.Add(dGridLexi.Items.Item(k - 1).SubItems(2).Text() & " - Invalid for increment/ decrement operation") 'c
                End If

                If setokee(k + 1) = "id" Then 'c
                    If dGridIden.Items.Count > 0 Then
                        Dim currID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text() 'c
                        Dim counta As Integer 'c
                        For index As Integer = 0 To dGridIden.Items.Count - 1
                            If dGridIden.Items.Item(index).SubItems(1).Text() = currID Then 'c
                                counta = index 'c
                            End If
                        Next

                        Dim currDType As String = dGridIden.Items.Item(counta).SubItems(2).Text() 'c
                        If currDType = "text" Or currDType = "flag" Or currDType = "frac" Then 'c
                            errCtr += 1
                            'objList = semant_table.Items.Add(errCtr)
                            objList.SubItems.Add(selinee(k))
                            objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " (" & currDType & ") - Invalid for increment/ decrement operation") 'c
                        ElseIf currDType = "whole" Then
                            Dim currVal As String = dGridIden.Items.Item(counta).SubItems(3).Text()
                            If currVal = "null" Then
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k - 1).SubItems(2).Text() & " - No value is assigned before using in incre/decre operation")
                            End If
                        End If
                    End If
                ElseIf setokee(k + 1) = "textlit" Or setokee(k + 1) = "flaglit" Or setokee(k - 1) = "fraclit" Then
                    errCtr += 1
                    'objList = semant_table.Items.Add(errCtr)
                    objList.SubItems.Add(selinee(k))
                    objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid for increment/ decrement operation") 'c
                End If
            End If
            If setokee(k) = ".+" Then
                If dGridIden.Items.Count > 1 Then
                    Dim fId As String = dGridLexi.Items.Item(k - 1).SubItems(2).Text
                    Dim sId As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text
                    Dim fDtype As String = ""
                    Dim sDtype As String = ""
                    Dim cF, cS As Integer

                    For index As Integer = 0 To dGridIden.Items.Count - 1
                        If dGridIden.Items.Item(index).SubItems(1).Text() = fId Then 'c
                            cF = index 'c
                        End If
                    Next

                    For index As Integer = 0 To dGridIden.Items.Count - 1
                        If dGridIden.Items.Item(index).SubItems(1).Text() = sId Then 'c
                            cS = index 'c
                        End If
                    Next

                    fDtype = dGridIden.Items.Item(cF).SubItems(2).Text
                    If fDtype <> "text" Then
                        errCtr += 1
                        'objList = semant_table.Items.Add(errCtr)
                        objList.SubItems.Add(selinee(k))
                        objList.SubItems.Add("Data type of " & fId & " should be 'text' for string operator")
                    End If

                    sDtype = dGridIden.Items.Item(cS).SubItems(2).Text
                    If sDtype <> "text" Then
                        errCtr += 1
                        'objList = semant_table.Items.Add(errCtr)
                        objList.SubItems.Add(selinee(k))
                        objList.SubItems.Add("Data type of " & sId & " should be 'text' for string operator")
                    End If
                End If
                'end ng if may laman yung dGridIden
            End If
            If setokee(k) = "relOp2" Then
                If setokee(k - 1) = "id" Then 'VARIABLE
                    If dGridIden.Items.Count > 0 Then
                        Dim currID As String = dGridLexi.Items.Item(k - 1).SubItems(2).Text() 'CHANGE
                        Dim counta As Integer 'c
                        For index As Integer = 0 To dGridIden.Items.Count - 1
                            If dGridIden.Items.Item(index).SubItems(1).Text() = currID Then 'c
                                counta = index 'c
                            End If
                        Next
                        Dim currDType As String = dGridIden.Items.Item(counta).SubItems(2).Text() 'datatype ng k-?
                        'MessageBox.Show(currDType)

                        If currDType = "whole" Then 'whole==
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "frac" Or setDType = "flag" Or setDType = "text" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "fraclit" Or setokee(k + 1) = "flaglit" Or setokee(k + 1) = "textlit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                            End If
                        ElseIf currDType = "frac" Then
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "whole" Or setDType = "flag" Or setDType = "text" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "wholelit" Or setokee(k + 1) = "flaglit" Or setokee(k + 1) = "textlit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                            End If
                        ElseIf currDType = "flag" Then
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "frac" Or setDType = "whole" Or setDType = "text" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "fraclit" Or setokee(k + 1) = "wholelit" Or setokee(k + 1) = "textlit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                            End If
                        ElseIf currDType = "text" Then
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "frac" Or setDType = "flag" Or setDType = "whole" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "fraclit" Or setokee(k + 1) = "flaglit" Or setokee(k + 1) = "wholelit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                            End If
                        End If

                    End If
                ElseIf setokee(k - 1) = "clsquare" And setokee(k - 4) = "id" Then
                    '1d array
                    If dGridIden.Items.Count > 0 Then
                        Dim currID As String = dGridLexi.Items.Item(k - 4).SubItems(2).Text() 'CHANGE
                        Dim counta As Integer 'c
                        For index As Integer = 0 To dGridIden.Items.Count - 1
                            If dGridIden.Items.Item(index).SubItems(1).Text() = currID Then 'c
                                counta = index 'c
                            End If
                        Next
                        Dim currDType As String = dGridIden.Items.Item(counta).SubItems(2).Text() 'datatype ng k-?
                        'MessageBox.Show(currDType)

                        If currDType = "whole" Then 'whole==
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "frac" Or setDType = "flag" Or setDType = "text" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "fraclit" Or setokee(k + 1) = "flaglit" Or setokee(k + 1) = "textlit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                            End If
                        ElseIf currDType = "frac" Then
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "whole" Or setDType = "flag" Or setDType = "text" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "wholelit" Or setokee(k + 1) = "flaglit" Or setokee(k + 1) = "textlit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                            End If
                        ElseIf currDType = "flag" Then
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "frac" Or setDType = "whole" Or setDType = "text" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "fraclit" Or setokee(k + 1) = "wholelit" Or setokee(k + 1) = "textlit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                            End If
                        ElseIf currDType = "text" Then
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "frac" Or setDType = "flag" Or setDType = "whole" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "fraclit" Or setokee(k + 1) = "flaglit" Or setokee(k + 1) = "wholelit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                            End If
                        End If

                    End If
                ElseIf setokee(k - 1) = "clsquare" And setokee(k - 4) = "clsquare" And setokee(k - 7) = "id" Then
                    '2d array
                    If dGridIden.Items.Count > 0 Then
                        Dim currID As String = dGridLexi.Items.Item(k - 7).SubItems(2).Text() 'CHANGE
                        Dim counta As Integer 'c
                        For index As Integer = 0 To dGridIden.Items.Count - 1
                            If dGridIden.Items.Item(index).SubItems(1).Text() = currID Then 'c
                                counta = index 'c
                            End If
                        Next
                        Dim currDType As String = dGridIden.Items.Item(counta).SubItems(2).Text() 'datatype ng k-?
                        'MessageBox.Show(currDType)

                        If currDType = "whole" Then 'whole==
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "frac" Or setDType = "flag" Or setDType = "text" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "fraclit" Or setokee(k + 1) = "flaglit" Or setokee(k + 1) = "textlit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                            End If
                        ElseIf currDType = "frac" Then
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "whole" Or setDType = "flag" Or setDType = "text" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "wholelit" Or setokee(k + 1) = "flaglit" Or setokee(k + 1) = "textlit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                            End If
                        ElseIf currDType = "flag" Then
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "frac" Or setDType = "whole" Or setDType = "text" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "fraclit" Or setokee(k + 1) = "wholelit" Or setokee(k + 1) = "textlit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                            End If
                        ElseIf currDType = "text" Then
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "frac" Or setDType = "flag" Or setDType = "whole" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "fraclit" Or setokee(k + 1) = "flaglit" Or setokee(k + 1) = "wholelit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Arguments should have the same data type for condition")
                            End If
                        End If

                    End If
                End If
            End If
            If setokee(k) = "relOp1" Then
                If setokee(k - 1) = "id" Then 'VARIABLE
                    If dGridIden.Items.Count > 0 Then
                        Dim currID As String = dGridLexi.Items.Item(k - 1).SubItems(2).Text() 'CHANGE
                        Dim counta As Integer 'c
                        For index As Integer = 0 To dGridIden.Items.Count - 1
                            If dGridIden.Items.Item(index).SubItems(1).Text() = currID Then 'c
                                counta = index 'c
                            End If
                        Next
                        Dim currDType As String = dGridIden.Items.Item(counta).SubItems(2).Text() 'datatype ng k-?
                        'MessageBox.Show(currDType)

                        If currDType = "whole" Then 'whole==
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "flag" Or setDType = "text" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid data type for this relational operation")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "flaglit" Or setokee(k + 1) = "textlit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid data type for this relational operation")
                            End If
                        ElseIf currDType = "frac" Then
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "flag" Or setDType = "text" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid data type for this relational operation")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "flaglit" Or setokee(k + 1) = "textlit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid data type for this relational operation")
                            End If
                        ElseIf currDType = "flag" Or currDType = "text" Then
                            errCtr += 1
                            'objList = semant_table.Items.Add(errCtr)
                            objList.SubItems.Add(selinee(k))
                            objList.SubItems.Add(dGridIden.Items.Item(counta).SubItems(1).Text() & " - Invalid data type for this relational operation")
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "flag" Or setDType = "text" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid data type for this relational operation")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "flaglit" Or setokee(k + 1) = "textlit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid data type for this relational operation")
                            End If

                        End If

                    End If
                ElseIf setokee(k - 1) = "clsquare" And setokee(k - 4) = "id" Then
                    '1d array
                    If dGridIden.Items.Count > 0 Then
                        Dim currID As String = dGridLexi.Items.Item(k - 4).SubItems(2).Text() 'CHANGE
                        Dim counta As Integer 'c
                        For index As Integer = 0 To dGridIden.Items.Count - 1
                            If dGridIden.Items.Item(index).SubItems(1).Text() = currID Then 'c
                                counta = index 'c
                            End If
                        Next
                        Dim currDType As String = dGridIden.Items.Item(counta).SubItems(2).Text() 'datatype ng k-?
                        'MessageBox.Show(currDType)

                        If currDType = "whole" Then 'whole==
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "flag" Or setDType = "text" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid data type for this relational operation")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "flaglit" Or setokee(k + 1) = "textlit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid data type for this relational operation")
                            End If
                        ElseIf currDType = "frac" Then
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "flag" Or setDType = "text" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid data type for this relational operation")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "flaglit" Or setokee(k + 1) = "textlit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid data type for this relational operation")
                            End If
                        ElseIf currDType = "flag" Or currDType = "text" Then
                            errCtr += 1
                            'objList = semant_table.Items.Add(errCtr)
                            objList.SubItems.Add(selinee(k))
                            objList.SubItems.Add(dGridIden.Items.Item(counta).SubItems(1).Text() & " - Invalid data type for this relational operation")
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "flag" Or setDType = "text" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid data type for this relational operation")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "flaglit" Or setokee(k + 1) = "textlit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid data type for this relational operation")
                            End If
                        End If
                    End If
                ElseIf setokee(k - 1) = "clsquare" And setokee(k - 4) = "clsquare" And setokee(k - 7) = "id" Then
                    '2d array
                    If dGridIden.Items.Count > 0 Then
                        Dim currID As String = dGridLexi.Items.Item(k - 7).SubItems(2).Text() 'CHANGE
                        Dim counta As Integer 'c
                        For index As Integer = 0 To dGridIden.Items.Count - 1
                            If dGridIden.Items.Item(index).SubItems(1).Text() = currID Then 'c
                                counta = index 'c
                            End If
                        Next
                        Dim currDType As String = dGridIden.Items.Item(counta).SubItems(2).Text() 'datatype ng k-?
                        'MessageBox.Show(currDType)

                        If currDType = "whole" Then 'whole==
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "flag" Or setDType = "text" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid data type for this relational operation")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "flaglit" Or setokee(k + 1) = "textlit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid data type for this relational operation")
                            End If
                        ElseIf currDType = "frac" Then
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "flag" Or setDType = "text" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid data type for this relational operation")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "flaglit" Or setokee(k + 1) = "textlit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid data type for this relational operation")
                            End If
                        ElseIf currDType = "flag" Or currDType = "text" Then
                            errCtr += 1
                            'objList = semant_table.Items.Add(errCtr)
                            objList.SubItems.Add(selinee(k))
                            objList.SubItems.Add(dGridIden.Items.Item(counta).SubItems(1).Text() & " - Invalid data type for this relational operation")
                            If setokee(k + 1) = "id" Then
                                If dGridIden.Items.Count > 0 Then
                                    Dim setID As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text()
                                    Dim setCtr As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text() = setID Then 'c
                                            setCtr = index 'c
                                        End If
                                    Next

                                    Dim setDType As String = dGridIden.Items.Item(setCtr).SubItems(2).Text()
                                    If setDType = "flag" Or setDType = "text" Then
                                        errCtr += 1
                                        'objList = semant_table.Items.Add(errCtr)
                                        objList.SubItems.Add(selinee(k))
                                        objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid data type for this relational operation")
                                    End If
                                End If
                            ElseIf setokee(k + 1) = "flaglit" Or setokee(k + 1) = "textlit" Then 'CHANGE
                                errCtr += 1
                                'objList = semant_table.Items.Add(errCtr)
                                objList.SubItems.Add(selinee(k))
                                objList.SubItems.Add(dGridLexi.Items.Item(k + 1).SubItems(2).Text() & " - Invalid data type for this relational operation")
                            End If
                        End If

                    End If
                End If
            End If

            If setokee(k) = "deport" Then
                MessageBox.Show("deport")
                Dim depDtype As String = ""
                Dim funcDtype As String = ""
                If setokee(k + 1) = "id" Then
                    Dim seId As String = dGridLexi.Items.Item(k + 1).SubItems(2).Text
                    Dim getID As Integer

                    If dGridIden.Items.Count > 0 Then
                        For index As Integer = 0 To dGridIden.Items.Count - 1
                            If dGridIden.Items.Item(index).SubItems(1).Text() = seId Then 'c
                                getID = index 'c
                            End If
                        Next
                    End If

                    depDtype = dGridIden.Items.Item(getID).SubItems(2).Text
                ElseIf setokee(k + 1) = "wholelit" Then
                    depDtype = "whole"
                ElseIf setokee(k + 1) = "fraclit" Then
                    depDtype = "frac"
                ElseIf setokee(k + 1) = "flaglit" Then
                    depDtype = "flag"
                ElseIf setokee(k + 1) = "textlit" Then
                    depDtype = "text"
                End If

                'MessageBox.Show(depDtype)
                Dim dep As Integer = k
                While dep >= 0
                    If setokee(dep) = "clpar" And setokee(dep + 1) = "newline" Then
                        Exit While
                    Else
                        dep -= 1
                    End If
                End While

                Dim les As Integer = dep
                'MessageBox.Show(dep)
                While setokee(les) <> "oppar"
                    If setokee(les) = "whole" Or setokee(les) = "frac" Or setokee(les) = "flag" Or setokee(les) = "text" Then
                        funcDtype = setokee(les)
                        Exit While
                    Else
                        les -= 1
                    End If
                End While

                'MessageBox.Show(funcDtype)

                If depDtype <> funcDtype Then
                    errCtr += 1
                    'objList = semant_table.Items.Add(errCtr)
                    objList.SubItems.Add(selinee(k))
                    objList.SubItems.Add("Mismatch data type of deport value")
                End If
            End If



            k += 1
        End While

        'para sa errors
        'Dim err As String = ""
        'Dim err1 As String = ""
        'Dim err2 As String = ""
        'Dim err21 As String = ""
        'Dim er1 As ListViewItem
        'Dim er2 As ListViewItem
        'If semant_table.Items.Count > 1 Then
        '    For i As Integer = 0 To semant_table.Items.Count - 1
        '        er1 = semant_table.Items(i)
        '        err = semant_table.Items.Item(i).SubItems(1).Text()
        '        err1 = semant_table.Items.Item(i).SubItems(2).Text()

        '        For j As Integer = i + 1 To semant_table.Items.Count - 1
        '            er2 = semant_table.Items(j)
        '            err2 = semant_table.Items.Item(j).SubItems(1).Text()
        '            err21 = semant_table.Items.Item(j).SubItems(2).Text()

        '            If err = err2 And err1 = err21 Then
        '                semant_table.Items.Remove(er2)
        '            End If
        '        Next
        '    Next
        'End If

    End Sub

    Private Sub identifierList()
        Dim x As Integer = 0
        Dim isMajor As Boolean = False
        Dim isBoard As Boolean = False
        Dim isFunction As Boolean = False
        Dim Ctr As Integer = 0
        Dim bCtr As Integer = 0
        Dim valDType As String = ""
        Dim value As String = ""
        Dim curDtype As String = ""
        Dim type As String = ""
        Dim used As String = "No"
        Dim arraySize As String = ""
        Dim arraySize2 As String = ""
        Dim parameter As String = ""
        Dim constAns As String = ""

        Dim dtype(4) As String
        dtype(0) = "whole"
        dtype(1) = "frac"
        dtype(2) = "flag"
        dtype(3) = "text"

        For i As Integer = 0 To dGridLexi.Items.Count - 1
            selinee(i) = dGridLexi.Items.Item(i).SubItems(1).Text() 'LINE
        Next

        For i As Integer = 0 To dGridLexi.Items.Count - 1
            setokee(i) = dGridLexi.Items.Item(i).SubItems(3).Text() 'TOKEN
        Next

        While x < dGridLexi.Items.Count
            If setokee(x) = "major" Then        'if "major"
                isBoard = False
                isMajor = True
            End If

            If setokee(x) = "board" Then
                isBoard = True
                MessageBox.Show(isBoard)
                Ctr += 1
                objList = dGridIden.Items.Add(Ctr)
                objList.SubItems.Add(dGridLexi.Items.Item(x + 2).SubItems(2).Text())
                objList.SubItems.Add("-")
                objList.SubItems.Add("-")
                objList.SubItems.Add("-")
                objList.SubItems.Add("board")
                objList.SubItems.Add("-")
                objList.SubItems.Add("-")
                objList.SubItems.Add("-")
                objList.SubItems.Add("board/global")
                objList.SubItems.Add("-")
            End If

            If setokee(x) = "clsymbol" Then
                Dim termi As Integer = x
                Dim termi2 As Integer = x
                Dim iden As String = ""
                If setokee(x + 1) = "id" Then
                    While termi2 >= 0
                        If setokee(termi2) = "board" Then
                            Exit While
                        End If
                        termi2 -= 1
                    End While

                    iden = dGridLexi.Items.Item(x).SubItems(2).Text
                    While setokee(termi) <> "\"
                        If setokee(termi) = "id" Then
                            bCtr += 1
                            objList = dGridBoard.Items.Add(dGridLexi.Items.Item(termi).SubItems(2).Text())
                            objList.SubItems.Add(dGridLexi.Items.Item(termi2 + 2).SubItems(2).Text())
                        End If
                        termi += 1
                    End While
                    isBoard = False
                ElseIf setokee(x + 1) = "\" Then
                    isBoard = False
                End If
            End If

            If setokee(x) = "vacant" Then
                Dim kawnter As Integer = x
                While setokee(kawnter) <> "clpar"
                    kawnter += 1
                End While
                If setokee(kawnter + 1) = "\" Then
                    Ctr += 1
                    objList = dGridIden.Items.Add(Ctr)
                    objList.SubItems.Add(dGridLexi.Items.Item(x + 2).SubItems(2).Text())
                    objList.SubItems.Add(setokee(x))
                    objList.SubItems.Add("-")
                    objList.SubItems.Add("-")
                    objList.SubItems.Add("function")
                    objList.SubItems.Add("No")
                    objList.SubItems.Add("-")
                    objList.SubItems.Add("0")
                    objList.SubItems.Add("global")
                    objList.SubItems.Add("-")
                End If
            End If

            If inArray(setokee(x), dtype, 4) Then
                Dim kownt As Integer = x
                While setokee(kownt) <> "newline"
                    If setokee(kownt) = "newline" Then
                        Exit While
                    End If
                    kownt += 1
                End While

                If setokee(kownt - 1) = "clpar" Or setokee(kownt - 1) = "opsymbol" Then
                    isMajor = False
                    isBoard = False
                    isFunction = True
                End If

            End If

            If inArray(setokee(x), dtype, 4) Then   'if datatype (declaration)
                curDtype = setokee(x)   'data type nung dinedeclare

                Dim declCount As Integer = 0
                Dim declCtr As Integer = x
                While Not (setokee(declCtr) = "\" Or setokee(declCtr) = "newline")
                    If setokee(declCtr) = "to" Then
                        declCount += 1
                    End If
                    declCtr += 1
                End While

                If declCount = 1 Then
                    While Not (setokee(x) = "\" Or setokee(x) = "newline")

                        'MessageBox.Show("x= " & x & ", " & setokee(x) & ", " & setokee(x + 1) & ", " & setokee(x + 2) & ", " & setokee(x + 3))

                        If setokee(x) = "id" And setokee(x + 1) <> "clsquare" And Not (setokee(x) = "id" And setokee(x + 1) = "oppar" And setokee(x + 2) = "clpar" And (setokee(x + 3) = "newline" Or setokee(x + 3) = "opsymbol")) Then
                            If setokee(x + 1) = "assgnOp" Then
                                valDType = setokee(x + 2).ToString
                                value = dGridLexi.Items.Item(x + 2).SubItems(2).Text()
                                If setokee(x - 3) = "set" Then
                                    type = "constant"
                                Else
                                    type = "variable"
                                End If

                            ElseIf setokee(x + 1) = "opsquare" Then
                                value = "-"     'DI PA FINAL
                                If curDtype = "whole" Then
                                    valDType = "wholelit"
                                ElseIf curDtype = "frac" Then
                                    valDType = "fraclit"
                                ElseIf curDtype = "flag" Then
                                    valDType = "flaglit"
                                ElseIf curDtype = "text" Then
                                    valDType = "textlit"
                                End If
                                If setokee(x + 3) = "opsquare" Or setokee(x + 4) = "opsquare" Then
                                    type = "array2"
                                Else
                                    type = "array1"
                                End If
                            ElseIf setokee(x + 1) = "oppar" Then
                                Dim lol As Integer = x + 1
                                While setokee(lol) <> "newline"
                                    If setokee(lol) = "\" Then
                                        Exit While
                                    End If
                                    lol += 1
                                End While

                                If Not (setokee(x + 1) = "oppar" And setokee(x + 2) = "clpar" And (setokee(x + 3) = "newline" Or setokee(x + 3) = "opsymbol")) Then
                                    value = "-" 'DIPA FINAL
                                    If curDtype = "whole" Then
                                        valDType = "wholelit"
                                    ElseIf curDtype = "frac" Then
                                        valDType = "fraclit"
                                    ElseIf curDtype = "flag" Then
                                        valDType = "flaglit"
                                    ElseIf curDtype = "text" Then
                                        valDType = "textlit"
                                    End If
                                    type = "function"
                                End If
                            Else
                                If Not (setokee(x) = "id" And setokee(x + 1) = "oppar" And setokee(x + 2) = "clpar" And (setokee(x + 3) = "newline" Or setokee(x + 3) = "opsymbol")) Then
                                    If curDtype = "whole" Then
                                        value = "0"
                                        valDType = "wholelit"
                                    ElseIf curDtype = "flag" Then
                                        value = "true"
                                        valDType = "flaglit"
                                    ElseIf curDtype = "frac" Then
                                        value = "0.0"
                                        valDType = "fraclit"
                                    ElseIf curDtype = "text" Then
                                        value = ""
                                        valDType = "textlit"
                                    End If
                                    type = "variable"
                                End If
                            End If

                            Ctr += 1
                            objList = dGridIden.Items.Add(Ctr)
                            objList.SubItems.Add(dGridLexi.Items.Item(x).SubItems(2).Text())
                            objList.SubItems.Add(curDtype)
                            objList.SubItems.Add(value)
                            objList.SubItems.Add(valDType)
                            objList.SubItems.Add(type)
                            objList.SubItems.Add(used)

                            If dGridIden.Items.Item(Ctr - 1).SubItems(5).Text() = "array1" Then     'size ng array
                                If setokee(x + 2) = "wholelit" Then
                                    arraySize = dGridLexi.Items.Item(x + 2).SubItems(2).Text()
                                    arraySize2 = "-"
                                ElseIf setokee(x + 2) = "id" Then
                                    Dim arrID As String = dGridLexi.Items.Item(x + 2).SubItems(2).Text
                                    Dim a As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text = arrID Then
                                            a = index
                                        End If
                                    Next

                                    Dim val As String = dGridIden.Items.Item(a).SubItems(3).Text
                                    arraySize = val
                                    arraySize2 = "-"
                                ElseIf setokee(x + 2) = "clsquare" Then
                                    arraySize = "100"
                                    arraySize2 = "-"
                                End If
                            ElseIf dGridIden.Items.Item(Ctr - 1).SubItems(5).Text() = "array2" Then
                                If setokee(x + 2) = "wholelit" Then '[3][?]
                                    arraySize = dGridLexi.Items.Item(x + 2).SubItems(2).Text()
                                    If setokee(x + 5) = "wholelit" Then '[3][2]
                                        arraySize = arraySize
                                        arraySize2 = dGridLexi.Items.Item(x + 5).SubItems(2).Text()
                                    ElseIf setokee(x + 5) = "id" Then '[3][@a]
                                        Dim arrayID As String = dGridLexi.Items.Item(x + 5).SubItems(2).Text
                                        Dim b As Integer
                                        For index As Integer = 0 To dGridIden.Items.Count - 1
                                            If dGridIden.Items.Item(index).SubItems(1).Text = arrayID Then
                                                b = index
                                            End If
                                        Next
                                        Dim value1 As String = dGridIden.Items.Item(b).SubItems(3).Text
                                        arraySize = arraySize
                                        arraySize2 = value1
                                    ElseIf setokee(x + 5) = "clsquare" Then '[3][]
                                        arraySize = arraySize
                                        arraySize2 = "10"
                                    End If
                                ElseIf setokee(x + 2) = "id" Then '[@a][?]
                                    Dim arrID As String = dGridLexi.Items.Item(x + 2).SubItems(2).Text
                                    Dim a As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text = arrID Then
                                            a = index
                                        End If
                                    Next

                                    Dim val As String = dGridIden.Items.Item(a).SubItems(3).Text
                                    arraySize = val

                                    If setokee(x + 5) = "wholelit" Then '[@s][2]
                                        arraySize = arraySize
                                        arraySize2 = dGridLexi.Items.Item(x + 5).SubItems(2).Text()
                                    ElseIf setokee(x + 5) = "id" Then '[@s][@a]
                                        Dim arrayID As String = dGridLexi.Items.Item(x + 5).SubItems(2).Text
                                        Dim b As Integer
                                        For index As Integer = 0 To dGridIden.Items.Count - 1
                                            If dGridIden.Items.Item(index).SubItems(1).Text = arrayID Then
                                                b = index
                                            End If
                                        Next
                                        Dim value1 As String = dGridIden.Items.Item(b).SubItems(3).Text
                                        arraySize = arraySize
                                        arraySize2 = value1
                                    ElseIf setokee(x + 5) = "clsquare" Then '[@s][]
                                        arraySize = arraySize
                                        arraySize2 = "10"
                                    End If

                                ElseIf setokee(x + 2) = "clsquare" Then
                                    arraySize = "10"
                                    If setokee(x + 4) = "wholelit" Then '[@s][2]
                                        arraySize = arraySize
                                        arraySize2 = dGridLexi.Items.Item(x + 4).SubItems(2).Text()
                                    ElseIf setokee(x + 4) = "id" Then '[@s][@a]
                                        Dim arrayID As String = dGridLexi.Items.Item(x + 4).SubItems(2).Text
                                        Dim b As Integer
                                        For index As Integer = 0 To dGridIden.Items.Count - 1
                                            If dGridIden.Items.Item(index).SubItems(1).Text = arrayID Then
                                                b = index
                                            End If
                                        Next
                                        Dim value1 As String = dGridIden.Items.Item(b).SubItems(3).Text
                                        arraySize = arraySize
                                        arraySize2 = value1
                                    ElseIf setokee(x + 4) = "clsquare" Then '[@s][]
                                        arraySize = arraySize
                                        arraySize2 = "10"
                                    End If
                                End If
                            Else
                                arraySize = "-"
                                arraySize2 = "-"
                            End If

                            objList.SubItems.Add(arraySize)


                            If dGridIden.Items.Item(Ctr - 1).SubItems(5).Text() = "function" Then
                                Dim paramCtr As Integer = x
                                Dim paramCount As Integer = 0
                                While Not setokee(paramCtr) = "clpar"
                                    If inArray(setokee(paramCtr), dtype, 4) Then
                                        paramCount += 1
                                    End If
                                    paramCtr += 1
                                End While
                                parameter = paramCount.ToString
                            Else
                                parameter = "-"
                            End If

                            objList.SubItems.Add(parameter)

                            If isMajor = True Then
                                objList.SubItems.Add("major")
                            ElseIf isBoard = True Then
                                Dim kaw As Integer = x
                                While kaw >= 0
                                    If setokee(kaw) = "opsymbol" Then
                                        Exit While
                                    Else
                                        kaw -= 1
                                    End If
                                End While
                                If setokee(kaw - 1) = "newline" Then
                                    objList.SubItems.Add(dGridLexi.Items.Item(kaw - 2).SubItems(2).Text)
                                Else
                                    objList.SubItems.Add(dGridLexi.Items.Item(kaw - 1).SubItems(2).Text)
                                End If
                            ElseIf isFunction = True Then
                                objList.SubItems.Add("minor")
                            Else
                                objList.SubItems.Add("global")
                            End If

                            objList.SubItems.Add(arraySize2)
                        End If
                        x += 1
                    End While
                ElseIf declCount >= 1 Then 'PARA SA PARAM SA FUNCTION
                    Dim kawnt As Integer = x
                    While setokee(kawnt) <> "newline"
                        If setokee(kawnt) = "newline" Then
                            Exit While
                        End If
                        kawnt += 1
                    End While

                    While setokee(x) <> ","
                        If setokee(x) = "id" And setokee(x + 1) <> "clsquare" And Not (setokee(x) = "id" And setokee(x + 1) = "oppar" And (setokee(kawnt - 1) = "clpar" Or setokee(kawnt - 1) = "opsymbol")) Then
                            If setokee(x + 1) = "assgnOp" Then
                                valDType = setokee(x + 2).ToString
                                value = dGridLexi.Items.Item(x + 2).SubItems(2).Text()
                                If setokee(x - 3) = "set" Then
                                    type = "constant"
                                Else
                                    type = "variable"
                                End If

                            ElseIf setokee(x + 1) = "opsquare" Then
                                value = "-"     'DI PA FINAL
                                If curDtype = "whole" Then
                                    valDType = "wholelit"
                                ElseIf curDtype = "frac" Then
                                    valDType = "fraclit"
                                ElseIf curDtype = "flag" Then
                                    valDType = "flaglit"
                                ElseIf curDtype = "text" Then
                                    valDType = "textlit"
                                End If
                                If setokee(x + 3) = "opsquare" Or setokee(x + 4) = "opsquare" Then
                                    type = "array2"
                                Else
                                    type = "array1"
                                End If
                            ElseIf setokee(x + 1) = "oppar" Then
                                Dim lol As Integer = x + 1
                                While setokee(lol) <> "newline"
                                    If setokee(lol) = "\" Then
                                        Exit While
                                    End If
                                    lol += 1
                                End While

                                If Not (setokee(x + 1) = "oppar" And setokee(x + 2) = "clpar" And (setokee(x + 3) = "newline" Or setokee(x + 3) = "opsymbol")) Then
                                    value = "-" 'DIPA FINAL
                                    If curDtype = "whole" Then
                                        valDType = "wholelit"
                                    ElseIf curDtype = "frac" Then
                                        valDType = "fraclit"
                                    ElseIf curDtype = "flag" Then
                                        valDType = "flaglit"
                                    ElseIf curDtype = "text" Then
                                        valDType = "textlit"
                                    End If
                                    type = "function"
                                End If
                            Else
                                If Not (setokee(x) = "id" And setokee(x + 1) = "oppar" And setokee(x + 2) = "clpar" And (setokee(x + 3) = "newline" Or setokee(x + 3) = "opsymbol")) Then
                                    If curDtype = "whole" Then
                                        value = "0"
                                        valDType = "wholelit"
                                    ElseIf curDtype = "flag" Then
                                        value = "true"
                                        valDType = "flaglit"
                                    ElseIf curDtype = "frac" Then
                                        value = "0.0"
                                        valDType = "fraclit"
                                    ElseIf curDtype = "text" Then
                                        value = ""
                                        valDType = "textlit"
                                    End If
                                    type = "variable"
                                End If
                            End If

                            Ctr += 1
                            objList = dGridIden.Items.Add(Ctr)
                            objList.SubItems.Add(dGridLexi.Items.Item(x).SubItems(2).Text())
                            objList.SubItems.Add(curDtype)
                            objList.SubItems.Add(value)
                            objList.SubItems.Add(valDType)
                            objList.SubItems.Add(type)
                            objList.SubItems.Add(used)

                            If dGridIden.Items.Item(Ctr - 1).SubItems(5).Text() = "array1" Then     'size ng array
                                If setokee(x + 2) = "wholelit" Then
                                    arraySize = dGridLexi.Items.Item(x + 2).SubItems(2).Text()
                                    arraySize2 = "-"
                                ElseIf setokee(x + 2) = "id" Then
                                    Dim arrID As String = dGridLexi.Items.Item(x + 2).SubItems(2).Text
                                    Dim a As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text = arrID Then
                                            a = index
                                        End If
                                    Next

                                    Dim val As String = dGridIden.Items.Item(a).SubItems(3).Text
                                    arraySize = val
                                    arraySize2 = "-"
                                ElseIf setokee(x + 2) = "clsquare" Then
                                    arraySize = "100"
                                    arraySize2 = "-"
                                End If
                            ElseIf dGridIden.Items.Item(Ctr - 1).SubItems(5).Text() = "array2" Then
                                If setokee(x + 2) = "wholelit" Then '[3][?]
                                    arraySize = dGridLexi.Items.Item(x + 2).SubItems(2).Text()
                                    If setokee(x + 5) = "wholelit" Then '[3][2]
                                        arraySize = arraySize
                                        arraySize2 = dGridLexi.Items.Item(x + 5).SubItems(2).Text()
                                    ElseIf setokee(x + 5) = "id" Then '[3][@a]
                                        Dim arrayID As String = dGridLexi.Items.Item(x + 5).SubItems(2).Text
                                        Dim b As Integer
                                        For index As Integer = 0 To dGridIden.Items.Count - 1
                                            If dGridIden.Items.Item(index).SubItems(1).Text = arrayID Then
                                                b = index
                                            End If
                                        Next
                                        Dim value1 As String = dGridIden.Items.Item(b).SubItems(3).Text
                                        arraySize = arraySize
                                        arraySize2 = value1
                                    ElseIf setokee(x + 5) = "clsquare" Then '[3][]
                                        arraySize = arraySize
                                        arraySize2 = "10"
                                    End If
                                ElseIf setokee(x + 2) = "id" Then '[@a][?]
                                    Dim arrID As String = dGridLexi.Items.Item(x + 2).SubItems(2).Text
                                    Dim a As Integer
                                    For index As Integer = 0 To dGridIden.Items.Count - 1
                                        If dGridIden.Items.Item(index).SubItems(1).Text = arrID Then
                                            a = index
                                        End If
                                    Next

                                    Dim val As String = dGridIden.Items.Item(a).SubItems(3).Text
                                    arraySize = val

                                    If setokee(x + 5) = "wholelit" Then '[@s][2]
                                        arraySize = arraySize
                                        arraySize2 = dGridLexi.Items.Item(x + 5).SubItems(2).Text()
                                    ElseIf setokee(x + 5) = "id" Then '[@s][@a]
                                        Dim arrayID As String = dGridLexi.Items.Item(x + 5).SubItems(2).Text
                                        Dim b As Integer
                                        For index As Integer = 0 To dGridIden.Items.Count - 1
                                            If dGridIden.Items.Item(index).SubItems(1).Text = arrayID Then
                                                b = index
                                            End If
                                        Next
                                        Dim value1 As String = dGridIden.Items.Item(b).SubItems(3).Text
                                        arraySize = arraySize
                                        arraySize2 = value1
                                    ElseIf setokee(x + 5) = "clsquare" Then '[@s][]
                                        arraySize = arraySize
                                        arraySize2 = "10"
                                    End If

                                ElseIf setokee(x + 2) = "clsquare" Then
                                    arraySize = "10"
                                    If setokee(x + 4) = "wholelit" Then '[@s][2]
                                        arraySize = arraySize
                                        arraySize2 = dGridLexi.Items.Item(x + 4).SubItems(2).Text()
                                    ElseIf setokee(x + 4) = "id" Then '[@s][@a]
                                        Dim arrayID As String = dGridLexi.Items.Item(x + 4).SubItems(2).Text
                                        Dim b As Integer
                                        For index As Integer = 0 To dGridIden.Items.Count - 1
                                            If dGridIden.Items.Item(index).SubItems(1).Text = arrayID Then
                                                b = index
                                            End If
                                        Next
                                        Dim value1 As String = dGridIden.Items.Item(b).SubItems(3).Text
                                        arraySize = arraySize
                                        arraySize2 = value1
                                    ElseIf setokee(x + 4) = "clsquare" Then '[@s][]
                                        arraySize = arraySize
                                        arraySize2 = "10"
                                    End If
                                End If
                            Else
                                arraySize = "-"
                                arraySize2 = "-"
                            End If

                            objList.SubItems.Add(arraySize)

                            If dGridIden.Items.Item(Ctr - 1).SubItems(5).Text() = "function" Then
                                Dim paramCtr As Integer = x
                                Dim paramCount As Integer = 0
                                While Not setokee(paramCtr) = "clpar"
                                    If inArray(setokee(paramCtr), dtype, 4) Then
                                        paramCount += 1
                                    End If
                                    paramCtr += 1
                                End While
                                parameter = paramCount.ToString
                            Else
                                parameter = "-"
                            End If

                            objList.SubItems.Add(parameter)

                            If isMajor = True Then
                                objList.SubItems.Add("major")
                            ElseIf isBoard = True Then
                                Dim kaw As Integer = x
                                While kaw >= 0
                                    If setokee(kaw) = "opsymbol" Then
                                        Exit While
                                    Else
                                        kaw -= 1
                                    End If
                                End While
                                If setokee(kaw - 1) = "newline" Then
                                    objList.SubItems.Add(dGridLexi.Items.Item(kaw - 2).SubItems(2).Text)
                                Else
                                    objList.SubItems.Add(dGridLexi.Items.Item(kaw - 1).SubItems(2).Text)
                                End If

                            ElseIf isFunction = True Then
                                objList.SubItems.Add("minor")
                            Else
                                objList.SubItems.Add("global")
                            End If

                            objList.SubItems.Add(arraySize2)

                        End If
                        x += 1
                    End While
                End If
            End If


            x += 1
        End While
    End Sub

    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    Private Sub syntaxana()
        Dim globdec(7) As String
        globdec(0) = "whole"
        globdec(1) = "frac"
        globdec(2) = "flag"
        globdec(3) = "text"
        globdec(4) = "set"
        globdec(5) = "board"
        globdec(6) = "vacant"

        Dim specdec(5) As String
        specdec(0) = "whole"
        specdec(1) = "frac"
        specdec(2) = "flag"
        specdec(3) = "text"
        specdec(4) = "id"

        Dim stmt(18) As String
        stmt(0) = "checkin"
        stmt(1) = "checkout"
        stmt(2) = "id"
        stmt(3) = "when"
        stmt(4) = "take"
        stmt(5) = "till"
        stmt(6) = "during"
        stmt(7) = "run"
        stmt(8) = "clearfield"
        stmt(9) = "wholelit"
        stmt(10) = "increOp"
        stmt(11) = "decreOp"
        stmt(12) = "otherwisewhen"
        stmt(13) = "otherwise"
        stmt(14) = "gate"
        stmt(15) = "terminal"
        stmt(16) = "opsymbol"
        stmt(17) = "clsymbol"

        Dim x, y, z, z1 As Integer
        Dim ctrA As Integer = 0
        Dim ctrD As Integer = 0
        Dim ctrM As Integer = 0
        Dim k As Integer = 0
        Dim ifArrive As Boolean = False
        Dim ifMajor As Boolean = False
        Dim ifMajorOne As Boolean = False
        Dim ifDepart As Boolean = False
        Dim ifFunction As Boolean = False
        Dim ifRun As Boolean = False
        Dim ifTake As Boolean = False
        Dim ifWhen As Boolean = False
        Dim ifOwen As Boolean = False
        Dim iSarrive As Integer = 0
        Dim iSdepart As Integer = 0
        Dim isRead = False

        If dGridError.Items.Count = 0 And dGridLexi.Items.Count > 0 Then
            MessageBox.Show("No Error Found, Proceeding to Syntax Analyzer!!")
            errorCtr = 0
            dGridError.BackColor = Color.MidnightBlue
            dGridLexi.BackColor = Color.MidnightBlue
            'semant_table.BackColor = Color.MidnightBlue

            For i As Integer = 0 To dGridLexi.Items.Count - 1
                linee(i) = dGridLexi.Items.Item(i).SubItems(1).Text() 'LINE
            Next

            For i As Integer = 0 To dGridLexi.Items.Count - 1
                tokee(i) = dGridLexi.Items.Item(i).SubItems(3).Text() 'TOKEN
            Next

            'ARRIVE---------------------------------------------------------
            If tokee(0) <> "entrance" Then
                'MessageBox.Show(tokee(0))
                Dim kawnt As Integer = 0
                For index As Integer = 0 To dGridLexi.Items.Count - 1
                    If dGridLexi.Items.Item(index).SubItems(3).Text() = "entrance" Then
                        kawnt += 1
                    End If
                Next

                If kawnt = 0 Then
                    errorCtr += 1
                    objList = dGridError.Items.Add(errorCtr)
                    objList.SubItems.Add(linee(x))
                    objList.SubItems.Add("Program should start with reserved word 'entrance'")
                Else
                    Dim kawn2 As Integer
                    For index As Integer = 0 To dGridLexi.Items.Count - 1
                        If dGridLexi.Items.Item(index).SubItems(3).Text() = "entrance" Then
                            iSarrive = index
                            Exit For
                        End If
                    Next

                    kawn2 = iSarrive
                    While kawn2 >= 0
                        If tokee(kawn2) = "entrance" Or tokee(kawn2) = "comment" Or tokee(kawn2) = "newline" Then
                            kawn2 -= 1
                            ifArrive = True
                        Else
                            errorCtr += 1
                            objList = dGridError.Items.Add(errorCtr)
                            objList.SubItems.Add(linee(x))
                            objList.SubItems.Add("Program should start with reserved word 'entrance'")
                            ifArrive = False
                            Exit While
                        End If
                    End While
                End If
            Else
                ifArrive = True
            End If

            If dGridLexi.Items.Count > 1 Then
                If tokee(dGridLexi.Items.Count - 1) <> "depart" Then
                    Dim kawnt As Integer = 0

                    For index As Integer = 0 To dGridLexi.Items.Count - 1
                        If dGridLexi.Items.Item(index).SubItems(3).Text() = "depart" Then
                            kawnt += 1
                        End If
                    Next

                    If kawnt = 0 Then
                        errorCtr += 1
                        objList = dGridError.Items.Add(errorCtr)
                        objList.SubItems.Add(linee(dGridLexi.Items.Count - 1))
                        objList.SubItems.Add("Program should end with reserved word 'depart'")
                    Else
                        Dim kawn2 As Integer
                        For index As Integer = 0 To dGridLexi.Items.Count - 1
                            If dGridLexi.Items.Item(index).SubItems(3).Text() = "depart" Then
                                iSdepart = index
                                Exit For
                            End If
                        Next

                        kawn2 = iSdepart
                        While kawn2 < dGridLexi.Items.Count
                            If tokee(kawn2) = "depart" Or tokee(kawn2) = "comment" Or tokee(kawn2) = "newline" Then
                                kawn2 += 1
                                ifDepart = True
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(linee(dGridLexi.Items.Count - 1))
                                objList.SubItems.Add("Program should end with reserved word 'depart'")
                                ifDepart = False
                                Exit While
                            End If
                        End While
                    End If
                Else
                    ifDepart = True
                End If
            End If
            'ARRIVE and start at DEPART ang end

            '----------------------------------------------------------
            y = 0
            z = 0
            z1 = 0
            Dim ind1, ind2, ind3 As Integer
            For i As Integer = 0 To dGridLexi.Items.Count - 1
                If dGridLexi.Items.Item(i).SubItems(3).Text() = "entrance" Then
                    y += 1
                    ind1 = i
                End If
            Next
            For i As Integer = 0 To dGridLexi.Items.Count - 1
                If dGridLexi.Items.Item(i).SubItems(3).Text() = "depart" Then
                    z += 1
                    ind2 = i
                End If
            Next
            For i As Integer = 0 To dGridLexi.Items.Count - 1
                If dGridLexi.Items.Item(i).SubItems(3).Text() = "major" Then
                    z1 += 1
                    ind3 = i
                End If
            Next

            If y > 1 Then
                errorCtr += 1
                objList = dGridError.Items.Add(errorCtr)
                objList.SubItems.Add(linee(ind1))
                objList.SubItems.Add("'entrance' should only be used once in the program")
                ifArrive = False
            Else
                ifArrive = True
                x = ind1 + 1
            End If
            If z > 1 Then
                errorCtr += 1
                objList = dGridError.Items.Add(errorCtr)
                objList.SubItems.Add(linee(ind2))
                objList.SubItems.Add("'depart' should only be used once in the program")
                ifDepart = False
            Else
                ifDepart = True
            End If
            If z1 > 1 Then
                errorCtr += 1
                objList = dGridError.Items.Add(errorCtr)
                objList.SubItems.Add(linee(ind3))
                objList.SubItems.Add("'major' should only be used once in the program")
                ifMajorOne = False
            Else
                ifMajorOne = True
            End If
            'COUNT NG ARRIVE AT DEPART--------------------------------------------------


            '--------SYNTAX ANA NG BUONG PROGRAM
            If ifArrive = True And ifDepart = True And ifMajorOne = True Then
                MessageBox.Show("checking whole program")
                Dim parCtr As Integer = 0
                While x < dGridLexi.Items.Count
                    'COMMENT
                    If tokee(x) = "comment" Then
                        x += 1
                    End If
                    'end ng COMMENT

                    'NEWLINE
                    If tokee(x) = "newline" Then
                        x += 1
                    End If
                    'end ng NEWLINE

                    'GENDECL
                    If ifMajor = False Then
                        While x < dGridLexi.Items.Count
                            If inArray(tokee(x), globdec, 7) Then
                                If tokee(x) = "whole" Or tokee(x) = "text" Or tokee(x) = "frac" Or tokee(x) = "flag" Then
                                    x += 1
                                    If tokee(x) = "to" Then 'whole to
                                        x += 1
wholeid:                                If tokee(x) = "id" Then 'whole to @a
                                            x += 1
wholeter:                                   If tokee(x) = "\" Then 'whole to @a\
                                                x += 1
                                                If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                    x += 1
                                                Else
                                                    errorCtr += 1
                                                    objList = dGridError.Items.Add(errorCtr)
                                                    objList.SubItems.Add(linee(x))
                                                    objList.SubItems.Add("Single line declaration only.")
                                                    k = x
                                                    While tokee(k) <> "newline"
                                                        k += 1
                                                    End While
                                                    x = k + 1
                                                End If
                                            ElseIf tokee(x) = "," Then 'whole to @a,
                                                x += 1
                                                If tokee(x) = "id" Then 'whole to @a,@b
                                                    GoTo wholeid
                                                Else
                                                    errorCtr += 1
                                                    objList = dGridError.Items.Add(errorCtr)
                                                    objList.SubItems.Add(linee(x))
                                                    objList.SubItems.Add("Expected identfier after ','")
                                                    k = x
                                                    While tokee(k) <> "newline"
                                                        k += 1
                                                    End While
                                                    x = k + 1
                                                End If
                                            ElseIf tokee(x) = "assgnOp" Then '@a=
                                                x += 1
                                                If tokee(x) = "wholelit" Or tokee(x) = "textlit" Or tokee(x) = "fraclit" Or tokee(x) = "flaglit" Then '@a=3
                                                    x += 1
                                                    If tokee(x) = "\" Or tokee(x) = "," Then '@a=3\
                                                        GoTo wholeter
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Expected terminator/ separator")
                                                        k = x
                                                        While tokee(k) <> "newline"
                                                            k += 1
                                                        End While
                                                        x = k + 1
                                                    End If
                                                Else
                                                    errorCtr += 1
                                                    objList = dGridError.Items.Add(errorCtr)
                                                    objList.SubItems.Add(linee(x))
                                                    objList.SubItems.Add("Expected value after assignment operator")
                                                    k = x
                                                    While tokee(k) <> "newline"
                                                        k += 1
                                                    End While
                                                    x = k + 1
                                                End If
                                            ElseIf tokee(x) = "opsquare" Then '@a[
                                                x += 1
                                                If tokee(x) = "wholelit" Or tokee(x) = "id" Then '@a[8
                                                    x += 1
                                                    If tokee(x) = "clsquare" Then '@a[8]
                                                        x += 1
array1assign:                                           If tokee(x) = "assgnOp" Then '@a[8]=
                                                            x += 1
                                                            If tokee(x) = "opcurly" Then '@a[8]={
                                                                x += 1
arrayelem1:                                                     If tokee(x) = "wholelit" Or tokee(x) = "textlit" Or tokee(x) = "fraclit" Or tokee(x) = "flaglit" Then '@a[8]={2
                                                                    x += 1
                                                                    If tokee(x) = "clcurly" Then '@a[8]={2}
                                                                        x += 1
                                                                        If tokee(x) = "," Or tokee(x) = "\" Then
                                                                            GoTo wholeter
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected terminator/ separator")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    ElseIf tokee(x) = "," Then '@a[8]={2,
                                                                        x += 1
                                                                        If tokee(x) = "wholelit" Or tokee(x) = "textlit" Or tokee(x) = "fraclit" Or tokee(x) = "flaglit" Then '@a[8]={2,4
                                                                            GoTo arrayelem1
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected element after ','")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Expected separator(,) or '}' after element")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Expected value after '{'")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected '{' after assignment operator")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        ElseIf tokee(x) = "\" Or tokee(x) = "," Then '@a[8]\
                                                            GoTo wholeter
                                                        ElseIf tokee(x) = "opsquare" Then '@a[8][
                                                            x += 1
array2:                                                     If tokee(x) = "id" Or tokee(x) = "wholelit" Then '@a[8][2
                                                                x += 1
                                                                If tokee(x) = "clsquare" Then '@a[8][2]
                                                                    x += 1
array2assign:                                                       If tokee(x) = "assgnOp" Then '@a[8][2]=
                                                                        x += 1
                                                                        If tokee(x) = "opcurly" Then '@a[8][2]={
                                                                            x += 1
arrayelempar2:                                                              If tokee(x) = "oppar" Then '@a[8][2]={(
                                                                                x += 1
arrayelem2:                                                                     If tokee(x) = "wholelit" Or tokee(x) = "textlit" Or tokee(x) = "fraclit" Or tokee(x) = "flaglit" Then '@a[8][2]={(4
                                                                                    x += 1
                                                                                    If tokee(x) = "clpar" Then '@a[8][2]={(4)
                                                                                        x += 1
                                                                                        If tokee(x) = "clcurly" Then '@a[8][2]={(4)}
                                                                                            x += 1
                                                                                            If tokee(x) = "," Or tokee(x) = "\" Then '@a[8][2]={(4)}\
                                                                                                GoTo wholeter
                                                                                            Else
                                                                                                errorCtr += 1
                                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                                objList.SubItems.Add(linee(x))
                                                                                                objList.SubItems.Add("Expected terminator/ separator")
                                                                                                k = x
                                                                                                While tokee(k) <> "newline"
                                                                                                    k += 1
                                                                                                End While
                                                                                                x = k + 1
                                                                                            End If
                                                                                        ElseIf tokee(x) = "," Then '@a[8][2]={(4),
                                                                                            x += 1
                                                                                            If tokee(x) = "oppar" Then '@a[8][2]={(4),(
                                                                                                GoTo arrayelempar2
                                                                                            Else
                                                                                                errorCtr += 1
                                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                                objList.SubItems.Add(linee(x))
                                                                                                objList.SubItems.Add("Expected '(' after separator")
                                                                                                k = x
                                                                                                While tokee(k) <> "newline"
                                                                                                    k += 1
                                                                                                End While
                                                                                                x = k + 1
                                                                                            End If
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Expected '}' or ','")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                        End If
                                                                                    ElseIf tokee(x) = "," Then '@a[8][2]={(4,
                                                                                        x += 1
                                                                                        If tokee(x) = "wholelit" Or tokee(x) = "textlit" Or tokee(x) = "fraclit" Or tokee(x) = "flaglit" Then '@a[8][2]={(4,1
                                                                                            GoTo arrayelem2
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Expected value after ','")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                        End If
                                                                                    Else
                                                                                        errorCtr += 1
                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                        objList.SubItems.Add(linee(x))
                                                                                        objList.SubItems.Add("Expected separator or close parenthesis after value")
                                                                                        k = x
                                                                                        While tokee(k) <> "newline"
                                                                                            k += 1
                                                                                        End While
                                                                                        x = k + 1
                                                                                    End If
                                                                                Else
                                                                                    errorCtr += 1
                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                    objList.SubItems.Add(linee(x))
                                                                                    objList.SubItems.Add("Expected value after open parenthesis")
                                                                                    k = x
                                                                                    While tokee(k) <> "newline"
                                                                                        k += 1
                                                                                    End While
                                                                                    x = k + 1
                                                                                End If
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add("Expected '(' after open curly brace")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                                x = k + 1
                                                                            End If
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected '{' after assignment operator")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    ElseIf tokee(x) = "\" Or tokee(x) = "," Then '@a[8][2],
                                                                        GoTo wholeter
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Expected terminator/ separator/ assignment operator")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                End If
                                                            ElseIf tokee(x) = "clsquare" Then '@a[8][]
                                                                x += 1
                                                                If tokee(x) = "assgnOp" Or tokee(x) = "\" Or tokee(x) = "," Then '@a[8][]= | @a[8][]\
                                                                    GoTo array2assign
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Expected terminator/ assignment operator/ separator")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add(tokee(x) & " - Invalid index for 2D array")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Expected terminator/ separator/ assignment operator")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Expected symbol: ']'")
                                                        k = x
                                                        While tokee(k) <> "newline"
                                                            k += 1
                                                        End While
                                                        x = k + 1
                                                    End If
                                                ElseIf tokee(x) = "clsquare" Then '@a[]
                                                    x += 1
                                                    If tokee(x) = "assgnOp" Or tokee(x) = "\" Or tokee(x) = "," Then '@a[]= | @a[]\
                                                        GoTo array1assign

                                                    ElseIf tokee(x) = "opsquare" Then '@a[][
                                                        x += 1
                                                        If tokee(x) = "wholelit" Or tokee(x) = "id" Or tokee(x) = "clsquare" Then
                                                            GoTo array2
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add(tokee(x) & " - Invalid index for 2D array")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Expected statement terminator")
                                                        k = x
                                                        While tokee(k) <> "newline"
                                                            k += 1
                                                        End While
                                                        x = k + 1
                                                    End If
                                                Else
                                                    errorCtr += 1
                                                    objList = dGridError.Items.Add(errorCtr)
                                                    objList.SubItems.Add(linee(x))
                                                    objList.SubItems.Add(tokee(x) & " - Invalid index for 1D array")
                                                    k = x
                                                    While tokee(k) <> "newline"
                                                        k += 1
                                                    End While
                                                    x = k + 1
                                                End If
                                            ElseIf tokee(x) = "oppar" Then '@a(
                                                x += 1
funcparam:                                      If tokee(x) = "whole" Or tokee(x) = "text" Or tokee(x) = "frac" Or tokee(x) = "flag" Then '@a(whole
                                                    x += 1
                                                    If tokee(x) = "clpar" Then '@a(whole)
                                                        x += 1
                                                        If tokee(x) = "\" Then '@a(whole)\
                                                            x += 1
                                                            If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                x += 1
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Only single declaration allowed")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Expected statement terminator after function declaration")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    ElseIf tokee(x) = "," Then '@a(whole,
                                                        x += 1
                                                        If tokee(x) = "whole" Or tokee(x) = "text" Or tokee(x) = "frac" Or tokee(x) = "flag" Then '@a(whole,whole
                                                            GoTo funcparam
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Expected parameter after ','")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Expected separator ',' or parameter terminator ')'")
                                                        k = x
                                                        While tokee(k) <> "newline"
                                                            k += 1
                                                        End While
                                                        x = k + 1
                                                    End If
                                                ElseIf tokee(x) = "clpar" Then
                                                    errorCtr += 1
                                                    objList = dGridError.Items.Add(errorCtr)
                                                    objList.SubItems.Add(linee(x))
                                                    objList.SubItems.Add("Function should have atleast 1 parameter")
                                                    k = x
                                                    While tokee(k) <> "newline"
                                                        k += 1
                                                    End While
                                                    x = k + 1
                                                Else
                                                    errorCtr += 1
                                                    objList = dGridError.Items.Add(errorCtr)
                                                    objList.SubItems.Add(linee(x))
                                                    objList.SubItems.Add(tokee(x) & "- Invalid parameter for function declaration")
                                                    k = x
                                                    While tokee(k) <> "newline"
                                                        k += 1
                                                    End While
                                                    x = k + 1
                                                End If
                                            Else
                                                errorCtr += 1
                                                objList = dGridError.Items.Add(errorCtr)
                                                objList.SubItems.Add(linee(x))
                                                objList.SubItems.Add("Expected statement terminator")
                                                k = x
                                                While tokee(k) <> "newline"
                                                    k += 1
                                                End While
                                                x = k + 1
                                            End If
                                        Else
                                            errorCtr += 1
                                            objList = dGridError.Items.Add(errorCtr)
                                            objList.SubItems.Add(linee(x))
                                            objList.SubItems.Add("Expected identifier")
                                            k = x
                                            While tokee(k) <> "newline"
                                                k += 1
                                            End While
                                            x = k + 1
                                        End If
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(linee(x))
                                        objList.SubItems.Add("Expected reserved word: to")
                                        k = x
                                        While tokee(k) <> "newline"
                                            k += 1
                                        End While
                                        x = k + 1
                                    End If
                                ElseIf tokee(x) = "set" Then
                                    x += 1
                                    If tokee(x) = "whole" Or tokee(x) = "text" Or tokee(x) = "flag" Or tokee(x) = "frac" Then 'set whole
                                        x += 1
                                        If tokee(x) = "to" Then 'set whole to
                                            x += 1
setid:                                      If tokee(x) = "id" Then 'set whole to @b
                                                x += 1
                                                If tokee(x) = "assgnOp" Then 'set whole to @b=
                                                    x += 1
                                                    If tokee(x) = "wholelit" Or tokee(x) = "textlit" Or tokee(x) = "fraclit" Or tokee(x) = "flaglit" Then 'set whole to @b=4
                                                        x += 1
                                                        If tokee(x) = "," Then  'set whole to @b=4,
                                                            x += 1
                                                            If tokee(x) = "id" Then 'set whole to @b=4, @a
                                                                GoTo setid
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected identifier after ','")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        ElseIf tokee(x) = "\" Then  'set whole to @b=4\
                                                            x += 1
                                                            If tokee(x) = "newline" Or tokee(x) = "comment" Then 'set whole to @b=4\ #comment
                                                                x += 1
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Only single statement is allowed")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Expected terminator/ separator")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Expected value after assigment operator")
                                                        k = x
                                                        While tokee(k) <> "newline"
                                                            k += 1
                                                        End While
                                                        x = k + 1
                                                    End If
                                                Else
                                                    errorCtr += 1
                                                    objList = dGridError.Items.Add(errorCtr)
                                                    objList.SubItems.Add(linee(x))
                                                    objList.SubItems.Add("Expected assignment operator after identifier")
                                                    k = x
                                                    While tokee(k) <> "newline"
                                                        k += 1
                                                    End While
                                                    x = k + 1
                                                End If
                                            Else
                                                errorCtr += 1
                                                objList = dGridError.Items.Add(errorCtr)
                                                objList.SubItems.Add(linee(x))
                                                objList.SubItems.Add("Expected identifier after 'to'")
                                                k = x
                                                While tokee(k) <> "newline"
                                                    k += 1
                                                End While
                                                x = k + 1
                                            End If
                                        Else
                                            errorCtr += 1
                                            objList = dGridError.Items.Add(errorCtr)
                                            objList.SubItems.Add(linee(x))
                                            objList.SubItems.Add("Expected reserved word: 'to'")
                                            k = x
                                            While tokee(k) <> "newline"
                                                k += 1
                                            End While
                                            x = k + 1
                                        End If
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(linee(x))
                                        objList.SubItems.Add("Expected data type after 'set'")
                                        k = x
                                        While tokee(k) <> "newline"
                                            k += 1
                                        End While
                                        x = k + 1
                                    End If
                                ElseIf tokee(x) = "vacant" Then
                                    x += 1
                                    If tokee(x) = "to" Then
                                        x += 1
                                        If tokee(x) = "id" Then
                                            x += 1
                                            If tokee(x) = "oppar" Then
                                                x += 1
                                                If tokee(x) = "clpar" Then
                                                    x += 1
                                                    If tokee(x) = "\" Then
                                                        x += 1
                                                        If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                            x += 1
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Only single statement allowed")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Expected statement terminator")
                                                        k = x
                                                        While tokee(k) <> "newline"
                                                            k += 1
                                                        End While
                                                        x = k + 1
                                                    End If
                                                Else
                                                    errorCtr += 1
                                                    objList = dGridError.Items.Add(errorCtr)
                                                    objList.SubItems.Add(linee(x))
                                                    objList.SubItems.Add("Expected reserved symbol ')' after open parenthesis")
                                                    k = x
                                                    While tokee(k) <> "newline"
                                                        k += 1
                                                    End While
                                                    x = k + 1
                                                End If
                                            Else
                                                errorCtr += 1
                                                objList = dGridError.Items.Add(errorCtr)
                                                objList.SubItems.Add(linee(x))
                                                objList.SubItems.Add("Expected reserved symbol '(' after identifier")
                                                k = x
                                                While tokee(k) <> "newline"
                                                    k += 1
                                                End While
                                                x = k + 1
                                            End If
                                        Else
                                            errorCtr += 1
                                            objList = dGridError.Items.Add(errorCtr)
                                            objList.SubItems.Add(linee(x))
                                            objList.SubItems.Add("Expected identifier after 'to'")
                                            k = x
                                            While tokee(k) <> "newline"
                                                k += 1
                                            End While
                                            x = k + 1
                                        End If
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(linee(x))
                                        objList.SubItems.Add("Expected reserved word: 'to'")
                                        k = x
                                        While tokee(k) <> "newline"
                                            k += 1
                                        End While
                                        x = k + 1
                                    End If
                                ElseIf tokee(x) = "board" Then 'board
                                    Dim elemCtr As Integer = 0
                                    x += 1
                                    If tokee(x) = "to" Then
                                        x += 1
                                        If tokee(x) = "id" Then
                                            x += 1
boardopsym:                                 If tokee(x) = "opsymbol" Then
                                                x += 1
                                                While x < dGridLexi.Items.Count
boardnoop:                                          If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                        x += 1
                                                    ElseIf tokee(x) = "whole" Or tokee(x) = "text" Or tokee(x) = "frac" Or tokee(x) = "flag" Then
                                                        elemCtr += 1
                                                        x += 1
                                                        If tokee(x) = "to" Then
                                                            x += 1
boardelem:                                                  If tokee(x) = "id" Then
                                                                x += 1
                                                                If tokee(x) = "," Then
                                                                    x += 1
                                                                    If tokee(x) = "id" Then
                                                                        GoTo boardelem
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Expected identifier after ','")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = "\" Then
                                                                    x += 1
                                                                    If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                        x += 1
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Only single statement allowed")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Expected statement terminator")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected identifier after 'to'")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Expected reserved word: 'to'")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    ElseIf tokee(x) = "clsymbol" Then
                                                        If elemCtr = 0 Then
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x - 1))
                                                            objList.SubItems.Add("Board should have atleast 1 element")
                                                        End If
                                                        x += 1
                                                        Exit While
                                                    ElseIf tokee(x) = "major" Then
                                                        If elemCtr = 0 Then
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x - 1))
                                                            objList.SubItems.Add("Board should have atleast 1 element")
                                                        End If
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Expected reserved symbol: '>>'")
                                                        ifMajor = True
                                                        GoTo boardexit
                                                    Else
                                                        MessageBox.Show(tokee(x))
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Invalid statement for board element declaration")
                                                        k = x
                                                        While tokee(k) <> "newline"
                                                            k += 1
                                                        End While
                                                        x = k + 1
                                                    End If
                                                End While
                                                If tokee(x) = "\" Then
                                                    x += 1
                                                    If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                        x += 1
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("No statement allowed after board terminator")
                                                        k = x
                                                        While tokee(k) <> "newline"
                                                            k += 1
                                                        End While
                                                        x = k + 1
                                                    End If
                                                ElseIf tokee(x) = "id" Then
boardobj:                                           x += 1
                                                    If tokee(x) = "," Then
                                                        x += 1
                                                        If tokee(x) = "id" Then
                                                            GoTo boardobj
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Expected identifier after ','")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    ElseIf tokee(x) = "\" Then
                                                        MessageBox.Show(tokee(x))
                                                        x += 1
                                                        If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                            x += 1
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("No statement allowed after board terminator")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Expected terminator")
                                                        k = x
                                                        While tokee(k) <> "newline"
                                                            k += 1
                                                        End While
                                                        x = k + 1
                                                    End If
                                                Else
                                                    errorCtr += 1
                                                    objList = dGridError.Items.Add(errorCtr)
                                                    objList.SubItems.Add(linee(x))
                                                    objList.SubItems.Add("Expected terminator or board object declaration")
                                                    k = x
                                                    While tokee(k) <> "newline"
                                                        k += 1
                                                    End While
                                                    x = k + 1
                                                End If
                                            ElseIf tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                k = x
                                                While tokee(k) = "newline" Or tokee(x) = "comment"
                                                    k += 1
                                                End While
                                                x = k
                                                If tokee(x) = "opsymbol" Then
                                                    GoTo boardopsym
                                                Else
                                                    errorCtr += 1
                                                    objList = dGridError.Items.Add(errorCtr)
                                                    objList.SubItems.Add(linee(x))
                                                    objList.SubItems.Add("Expected reserved symbol: '<<'")
                                                    GoTo boardnoop
                                                End If
                                            Else
                                                errorCtr += 1
                                                objList = dGridError.Items.Add(errorCtr)
                                                objList.SubItems.Add(linee(x))
                                                objList.SubItems.Add("Expected reserved symbol: '<<'")
                                                GoTo boardnoop
                                            End If
                                        Else
                                            errorCtr += 1
                                            objList = dGridError.Items.Add(errorCtr)
                                            objList.SubItems.Add(linee(x))
                                            objList.SubItems.Add("Expected identifier after 'to'")
                                            k = x
                                            While tokee(k) <> "newline"
                                                k += 1
                                            End While
                                            x = k + 1
                                        End If
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(linee(x))
                                        objList.SubItems.Add("Expected reserved word: 'to'")
                                        k = x
                                        While tokee(k) <> "newline"
                                            k += 1
                                        End While
                                        x = k + 1
                                    End If
                                End If
                                'PART NG GENDECL
                            ElseIf tokee(x) = "major" Then
                                ifMajor = True
                                Exit While
                            ElseIf tokee(x) = "comment" Or tokee(x) = "newline" Then
                                x += 1
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(linee(x))
                                objList.SubItems.Add("Invalid statement for general declaration")
                                k = x
                                While tokee(k) <> "newline"
                                    k += 1
                                End While
                                x = k + 1
                            End If
                        End While
boardexit:          End If
                    'end ng GENDECL

                    'MAJOR
                    If ifMajor = True Then
                        If tokee(x) = "major" Then
                            x += 1
                            If tokee(x) = "oppar" Then
                                x += 1
                                If tokee(x) = "clpar" Then
                                    x += 1
majoropsym:                         If tokee(x) = "opsymbol" Then
                                        x += 1
                                        'SPECDECL
                                        While x < dGridLexi.Items.Count
majornoop:                                  If inArray(tokee(x), specdec, 5) Then
                                                If tokee(x) = "whole" Or tokee(x) = "text" Or tokee(x) = "frac" Or tokee(x) = "flag" Then
                                                    x += 1
                                                    If tokee(x) = "to" Then 'whole to
                                                        x += 1
sid:                                                    If tokee(x) = "id" Then 'whole to @a
                                                            x += 1
ster:                                                       If tokee(x) = "\" Then 'whole to @a\
                                                                x += 1
                                                                If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                    x += 1
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Single line declaration only.")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            ElseIf tokee(x) = "," Then 'whole to @a,
                                                                x += 1
                                                                If tokee(x) = "id" Then 'whole to @a,@b
                                                                    GoTo sid
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Expected identfier after ','")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            ElseIf tokee(x) = "assgnOp" Then '@a=
                                                                x += 1
                                                                If tokee(x) = "wholelit" Or tokee(x) = "textlit" Or tokee(x) = "fraclit" Or tokee(x) = "flaglit" Then '@a=3
                                                                    x += 1
                                                                    If tokee(x) = "\" Or tokee(x) = "," Then '@a=3\
                                                                        GoTo ster
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Expected terminator/ separator")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Expected value after assignment operator")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            ElseIf tokee(x) = "opsquare" Then '@a[
                                                                x += 1
                                                                If tokee(x) = "wholelit" Or tokee(x) = "id" Then '@a[8
                                                                    x += 1
                                                                    If tokee(x) = "clsquare" Then '@a[8]
                                                                        x += 1
sarr1assign:                                                            If tokee(x) = "assgnOp" Then '@a[8]=
                                                                            x += 1
                                                                            If tokee(x) = "opcurly" Then '@a[8]={
                                                                                x += 1
sarrelem1:                                                                      If tokee(x) = "wholelit" Or tokee(x) = "textlit" Or tokee(x) = "fraclit" Or tokee(x) = "flaglit" Then '@a[8]={2
                                                                                    x += 1
                                                                                    If tokee(x) = "clcurly" Then '@a[8]={2}
                                                                                        x += 1
                                                                                        If tokee(x) = "," Or tokee(x) = "\" Then
                                                                                            GoTo wholeter
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Expected terminator/ separator")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                        End If
                                                                                    ElseIf tokee(x) = "," Then '@a[8]={2,
                                                                                        x += 1
                                                                                        If tokee(x) = "wholelit" Or tokee(x) = "textlit" Or tokee(x) = "fraclit" Or tokee(x) = "flaglit" Then '@a[8]={2,4
                                                                                            GoTo sarrelem1
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Expected element after ','")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                        End If
                                                                                    Else
                                                                                        errorCtr += 1
                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                        objList.SubItems.Add(linee(x))
                                                                                        objList.SubItems.Add("Expected separator(,) or '}' after element")
                                                                                        k = x
                                                                                        While tokee(k) <> "newline"
                                                                                            k += 1
                                                                                        End While
                                                                                        x = k + 1
                                                                                    End If
                                                                                Else
                                                                                    errorCtr += 1
                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                    objList.SubItems.Add(linee(x))
                                                                                    objList.SubItems.Add("Expected value after '{'")
                                                                                    k = x
                                                                                    While tokee(k) <> "newline"
                                                                                        k += 1
                                                                                    End While
                                                                                    x = k + 1
                                                                                End If
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add("Expected '{' after assignment operator")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                                x = k + 1
                                                                            End If
                                                                        ElseIf tokee(x) = "\" Or tokee(x) = "," Then '@a[8]\
                                                                            GoTo wholeter
                                                                        ElseIf tokee(x) = "opsquare" Then '@a[8][
                                                                            x += 1
sarr2:                                                                      If tokee(x) = "id" Or tokee(x) = "wholelit" Then '@a[8][2
                                                                                x += 1
                                                                                If tokee(x) = "clsquare" Then '@a[8][2]
                                                                                    x += 1
sarr2assign:                                                                        If tokee(x) = "assgnOp" Then '@a[8][2]=
                                                                                        x += 1
                                                                                        If tokee(x) = "opcurly" Then '@a[8][2]={
                                                                                            x += 1
sarrelempar2:                                                                               If tokee(x) = "oppar" Then '@a[8][2]={(
                                                                                                x += 1
sarrelem2:                                                                                      If tokee(x) = "wholelit" Or tokee(x) = "textlit" Or tokee(x) = "fraclit" Or tokee(x) = "flaglit" Then '@a[8][2]={(4
                                                                                                    x += 1
                                                                                                    If tokee(x) = "clpar" Then '@a[8][2]={(4)
                                                                                                        x += 1
                                                                                                        If tokee(x) = "clcurly" Then '@a[8][2]={(4)}
                                                                                                            x += 1
                                                                                                            If tokee(x) = "," Or tokee(x) = "\" Then '@a[8][2]={(4)}\
                                                                                                                GoTo wholeter
                                                                                                            Else
                                                                                                                errorCtr += 1
                                                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                                                objList.SubItems.Add(linee(x))
                                                                                                                objList.SubItems.Add("Expected terminator/ separator")
                                                                                                                k = x
                                                                                                                While tokee(k) <> "newline"
                                                                                                                    k += 1
                                                                                                                End While
                                                                                                                x = k + 1
                                                                                                            End If
                                                                                                        ElseIf tokee(x) = "," Then '@a[8][2]={(4),
                                                                                                            x += 1
                                                                                                            If tokee(x) = "oppar" Then '@a[8][2]={(4),(
                                                                                                                GoTo sarrelempar2
                                                                                                            Else
                                                                                                                errorCtr += 1
                                                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                                                objList.SubItems.Add(linee(x))
                                                                                                                objList.SubItems.Add("Expected '(' after separator")
                                                                                                                k = x
                                                                                                                While tokee(k) <> "newline"
                                                                                                                    k += 1
                                                                                                                End While
                                                                                                                x = k + 1
                                                                                                            End If
                                                                                                        Else
                                                                                                            errorCtr += 1
                                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                                            objList.SubItems.Add(linee(x))
                                                                                                            objList.SubItems.Add("Expected '}' or ','")
                                                                                                            k = x
                                                                                                            While tokee(k) <> "newline"
                                                                                                                k += 1
                                                                                                            End While
                                                                                                            x = k + 1
                                                                                                        End If
                                                                                                    ElseIf tokee(x) = "," Then '@a[8][2]={(4,
                                                                                                        x += 1
                                                                                                        If tokee(x) = "wholelit" Or tokee(x) = "textlit" Or tokee(x) = "fraclit" Or tokee(x) = "flaglit" Then '@a[8][2]={(4,1
                                                                                                            GoTo sarrelem2
                                                                                                        Else
                                                                                                            errorCtr += 1
                                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                                            objList.SubItems.Add(linee(x))
                                                                                                            objList.SubItems.Add("Expected value after ','")
                                                                                                            k = x
                                                                                                            While tokee(k) <> "newline"
                                                                                                                k += 1
                                                                                                            End While
                                                                                                            x = k + 1
                                                                                                        End If
                                                                                                    Else
                                                                                                        errorCtr += 1
                                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                                        objList.SubItems.Add(linee(x))
                                                                                                        objList.SubItems.Add("Expected separator or close parenthesis after value")
                                                                                                        k = x
                                                                                                        While tokee(k) <> "newline"
                                                                                                            k += 1
                                                                                                        End While
                                                                                                        x = k + 1
                                                                                                    End If
                                                                                                Else
                                                                                                    errorCtr += 1
                                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                                    objList.SubItems.Add(linee(x))
                                                                                                    objList.SubItems.Add("Expected value after open parenthesis")
                                                                                                    k = x
                                                                                                    While tokee(k) <> "newline"
                                                                                                        k += 1
                                                                                                    End While
                                                                                                    x = k + 1
                                                                                                End If
                                                                                            Else
                                                                                                errorCtr += 1
                                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                                objList.SubItems.Add(linee(x))
                                                                                                objList.SubItems.Add("Expected '(' after open curly brace")
                                                                                                k = x
                                                                                                While tokee(k) <> "newline"
                                                                                                    k += 1
                                                                                                End While
                                                                                                x = k + 1
                                                                                            End If
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Expected '{' after assignment operator")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                        End If
                                                                                    ElseIf tokee(x) = "\" Or tokee(x) = "," Then '@a[8][2],
                                                                                        GoTo wholeter
                                                                                    Else
                                                                                        errorCtr += 1
                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                        objList.SubItems.Add(linee(x))
                                                                                        objList.SubItems.Add("Expected terminator/ separator/ assignment operator")
                                                                                        k = x
                                                                                        While tokee(k) <> "newline"
                                                                                            k += 1
                                                                                        End While
                                                                                        x = k + 1
                                                                                    End If
                                                                                End If
                                                                            ElseIf tokee(x) = "clsquare" Then '@a[8][]
                                                                                x += 1
                                                                                If tokee(x) = "assgnOp" Or tokee(x) = "\" Or tokee(x) = "," Then '@a[8][]= | @a[8][]\
                                                                                    GoTo sarr2assign
                                                                                Else
                                                                                    errorCtr += 1
                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                    objList.SubItems.Add(linee(x))
                                                                                    objList.SubItems.Add("Expected terminator/ assignment operator/ separator")
                                                                                    k = x
                                                                                    While tokee(k) <> "newline"
                                                                                        k += 1
                                                                                    End While
                                                                                    x = k + 1
                                                                                End If
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add(tokee(x) & " - Invalid index for 2D array")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                                x = k + 1
                                                                            End If
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected terminator/ separator/ assignment operator")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Expected symbol: ']'")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = "clsquare" Then '@a[]
                                                                    x += 1
                                                                    If tokee(x) = "assgnOp" Or tokee(x) = "\" Or tokee(x) = "," Then '@a[]= | @a[]\
                                                                        GoTo sarr1assign
                                                                    ElseIf tokee(x) = "opsquare" Then '@a[][
                                                                        x += 1
                                                                        If tokee(x) = "wholelit" Or tokee(x) = "id" Or tokee(x) = "clsquare" Then
                                                                            GoTo sarr2
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add(tokee(x) & " - Invalid index for 2D array")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Expected statement terminator")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add(tokee(x) & " - Invalid index for 1D array")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected terminator\ separator after identifier")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Expected identifier")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Expected reserved word: 'to'")
                                                        k = x
                                                        While tokee(k) <> "newline"
                                                            k += 1
                                                        End While
                                                        x = k + 1
                                                    End If
                                                ElseIf tokee(x) = "id" Then
                                                    x += 1
                                                    If tokee(x) = "assgnOp" Or tokee(x) = "assgnOp2" Or tokee(x) = "oppar" Or tokee(x) = "increOp" _
                                                         Or tokee(x) = "decreOp" Or tokee(x) = "opsquare" Or tokee(x) = "!+" Then
                                                        x -= 1
                                                        Exit While
                                                    ElseIf tokee(x) = "to" Then
                                                        x += 1
                                                        If tokee(x) = "id" Then
                                                            x += 1
                                                            If tokee(x) = "\" Then
                                                                x += 1
                                                                If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                    x += 1
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Only single statement is allowed")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected statement terminator")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Expected identifier after 'to'")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    ElseIf tokee(x) = "assgnOp" Or tokee(x) = "assgnOp2" Or tokee(x) = "increOp" Or tokee(x) = "decreOp" Then
                                                        Exit While
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Expected reserved word: 'to'")
                                                        k = x
                                                        While tokee(k) <> "newline"
                                                            k += 1
                                                        End While
                                                        x = k + 1
                                                    End If
                                                End If
                                            ElseIf tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                x += 1
                                            ElseIf tokee(x) = "checkin" Or tokee(x) = "checkout" Or tokee(x) = "when" Or tokee(x) = "take" Or tokee(x) = "id" _
                                                Or tokee(x) = "till" Or tokee(x) = "during" Or tokee(x) = "run" Or tokee(x) = "clearfield" Or tokee(x) = "increOp" Or tokee(x) = "decreOp" Then
                                                Exit While
                                            ElseIf tokee(x) = "clsymbol" Then
                                                GoTo majclsym
                                            Else
                                                errorCtr += 1
                                                objList = dGridError.Items.Add(errorCtr)
                                                objList.SubItems.Add(linee(x))
                                                objList.SubItems.Add("Invalid statement for local declaration")
                                                k = x
                                                While tokee(k) <> "newline"
                                                    k += 1
                                                End While
                                                x = k + 1
                                            End If
                                        End While
                                        'end ng SPECDECL

                                        'STATEMENT
state:                                  While x < dGridLexi.Items.Count
                                            If inArray(tokee(x), stmt, 18) Then
                                                If tokee(x) = "checkin" Then
                                                    x += 1
                                                    If tokee(x) = ":>" Then
                                                        x += 1
                                                        If tokee(x) = "id" Then
                                                            x += 1
                                                            If tokee(x) = "\" Then
                                                                x += 1
                                                                If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                    x += 1
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Only single statement is allowed")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            ElseIf tokee(x) = ":>" Then
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Only single input is allowed")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected statement terminator")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Expected identifier after ':>'")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Expected reserved symbol: ':>'")
                                                        k = x
                                                        While tokee(k) <> "newline"
                                                            k += 1
                                                        End While
                                                        x = k + 1
                                                    End If
                                                ElseIf tokee(x) = "checkout" Then
                                                    x += 1
                                                    If tokee(x) = ":<" Then
coutrep:                                                x += 1
                                                        If tokee(x) = "textlit" Or tokee(x) = ":n" Or tokee(x) = ":t" Then
                                                            x += 1
                                                            If tokee(x) = "\" Then
                                                                x += 1
                                                                If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                    x += 1
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Only single statement is allowed")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            ElseIf tokee(x) = ":<" Then
                                                                GoTo coutrep
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected terminator/ output symbol")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        ElseIf tokee(x) = "increOp" Or tokee(x) = "decreOp" Then
                                                            x += 1
                                                            If tokee(x) = "id" Then
                                                                x += 1
                                                                If tokee(x) = "\" Then
                                                                    x += 1
                                                                    If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                        x += 1
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Only single statement is allowed")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = ":<" Then
                                                                    GoTo coutrep
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Expected terminator/ output symbol")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected identifier after incre/decre operator")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        ElseIf tokee(x) = "wholelit" Then
mathwhole:                                                  x += 1
                                                            If tokee(x) = "mathOp" Then
                                                                x += 1
                                                                If tokee(x) = "id" Then
                                                                    GoTo mathid
                                                                ElseIf tokee(x) = "wholelit" Then
                                                                    GoTo mathwhole
                                                                ElseIf tokee(x) = "fraclit" Then
                                                                    GoTo mathfrac
                                                                ElseIf tokee(x) = "oppar" Then
                                                                    GoTo mathoppar
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Expected operand after operator")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            ElseIf tokee(x) = "clpar" Then
mathclpar:                                                      x += 1
                                                                If tokee(x) = "clpar" Then
                                                                    GoTo mathclpar
                                                                ElseIf tokee(x) = "\" Then
                                                                    x += 1
                                                                    If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                        x += 1
                                                                        parCtr = 0
                                                                        k = x
                                                                        While tokee(k) <> ":<"
                                                                            If tokee(k) = "oppar" Then
                                                                                parCtr += 1
                                                                            ElseIf tokee(k) = "clpar" Then
                                                                                parCtr -= 1
                                                                            End If
                                                                            k -= 1
                                                                        End While
                                                                        If parCtr > 0 Then
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Missing ')'")
                                                                        End If
                                                                        If parCtr < 0 Then
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Missing '('")
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Only single statement is allowed")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = ":<" Then
                                                                    GoTo coutrep
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Expected math operator after identifier")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            ElseIf tokee(x) = "\" Then
                                                                x += 1
                                                                If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                    x += 1
                                                                    parCtr = 0
                                                                    k = x
                                                                    While tokee(k) <> ":<"
                                                                        If tokee(k) = "oppar" Then
                                                                            parCtr += 1
                                                                        ElseIf tokee(k) = "clpar" Then
                                                                            parCtr -= 1
                                                                        End If
                                                                        k -= 1
                                                                    End While
                                                                    If parCtr > 0 Then
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Missing ')'")
                                                                    End If
                                                                    If parCtr < 0 Then
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Missing '('")
                                                                    End If
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Only single statement is allowed")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            ElseIf tokee(x) = ":<" Then
                                                                GoTo coutrep
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected math operator after wholelit")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        ElseIf tokee(x) = "fraclit" Then
mathfrac:                                                   x += 1
                                                            If tokee(x) = "mathOp" Then
                                                                x += 1
                                                                If tokee(x) = "id" Then
                                                                    GoTo mathid
                                                                ElseIf tokee(x) = "wholelit" Then
                                                                    GoTo mathwhole
                                                                ElseIf tokee(x) = "fraclit" Then
                                                                    GoTo mathfrac
                                                                ElseIf tokee(x) = "oppar" Then
                                                                    GoTo mathoppar
                                                                ElseIf tokee(x) = "~" Then
                                                                    GoTo mathneg
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Expected operand after operator")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            ElseIf tokee(x) = "clpar" Then
                                                                GoTo mathclpar
                                                            ElseIf tokee(x) = "\" Then
                                                                x += 1
                                                                If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                    x += 1
                                                                    parCtr = 0
                                                                    k = x
                                                                    While tokee(k) <> ":<"
                                                                        If tokee(k) = "oppar" Then
                                                                            parCtr += 1
                                                                        ElseIf tokee(k) = "clpar" Then
                                                                            parCtr -= 1
                                                                        End If
                                                                        k -= 1
                                                                    End While
                                                                    If parCtr > 0 Then
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Missing ')'")
                                                                    End If
                                                                    If parCtr < 0 Then
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Missing '('")
                                                                    End If
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Only single statement is allowed")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            ElseIf tokee(x) = ":<" Then
                                                                GoTo coutrep
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected math operator after fraclit")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        ElseIf tokee(x) = "oppar" Then
mathoppar:                                                  x += 1
                                                            If tokee(x) = "id" Then
                                                                GoTo mathid
                                                            ElseIf tokee(x) = "wholelit" Then
                                                                GoTo mathwhole
                                                            ElseIf tokee(x) = "fraclit" Then
                                                                GoTo mathfrac
                                                            ElseIf tokee(x) = "oppar" Then
                                                                GoTo mathoppar
                                                            ElseIf tokee(x) = "~" Then
                                                                GoTo mathneg
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected operand after '('")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        ElseIf tokee(x) = "~" Then
mathneg:                                                    x += 1
                                                            If tokee(x) = "oppar" Then
                                                                GoTo mathoppar
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected open parenthesis after '~'")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        ElseIf tokee(x) = "id" Then
                                                            Dim isMath As Boolean = False
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                If tokee(k) = "mathOp" Then
                                                                    isMath = True
                                                                    Exit While
                                                                Else
                                                                    k += 1
                                                                End If
                                                            End While
                                                            If isMath = False Then
                                                                x += 1
                                                                If tokee(x) = "increOp" Or tokee(x) = "decreOp" Then
                                                                    x += 1
                                                                    If tokee(x) = "\" Then
                                                                        x += 1
                                                                        If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                            x += 1
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Only single statement is allowed")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    ElseIf tokee(x) = ":<" Then
                                                                        GoTo coutrep
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Expected terminator/ output symbol")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = "!+" Then
                                                                    x += 1
                                                                    If tokee(x) = "id" Then
                                                                        x += 1
                                                                        If tokee(x) = "\" Then
                                                                            x += 1
                                                                            If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                                x += 1
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add("Only single statement is allowed")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                                x = k + 1
                                                                            End If
                                                                        ElseIf tokee(x) = ":<" Then
                                                                            GoTo coutrep
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected terminator/ output symbol")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Expected identifier after '!+'")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = "opsquare" Then ':<@a[
                                                                    x += 1
                                                                    If tokee(x) = "id" Or tokee(x) = "wholelit" Then ':<@a[2
                                                                        x += 1
                                                                        If tokee(x) = "clsquare" Then ':<@a[2]
                                                                            x += 1
                                                                            If tokee(x) = "opsquare" Then ':<@a[2][
                                                                                x += 1
                                                                                If tokee(x) = "id" Or tokee(x) = "wholelit" Then ':<@a[2][5
                                                                                    x += 1
                                                                                    If tokee(x) = "clsquare" Then ':<@a[2][5]
                                                                                        x += 1
                                                                                        If tokee(x) = "\" Then ':<@a[2][5]\
                                                                                            x += 1
                                                                                            If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                                                x += 1
                                                                                            Else
                                                                                                errorCtr += 1
                                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                                objList.SubItems.Add(linee(x))
                                                                                                objList.SubItems.Add("Only single statement is allowed")
                                                                                                k = x
                                                                                                While tokee(k) <> "newline"
                                                                                                    k += 1
                                                                                                End While
                                                                                                x = k + 1
                                                                                            End If
                                                                                        ElseIf tokee(x) = ":<" Then
                                                                                            GoTo coutrep
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Expected terminator/ output symbol")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                        End If
                                                                                    End If
                                                                                Else
                                                                                    errorCtr += 1
                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                    objList.SubItems.Add(linee(x))
                                                                                    objList.SubItems.Add("Invalid index for array")
                                                                                    k = x
                                                                                    While tokee(k) <> "newline"
                                                                                        k += 1
                                                                                    End While
                                                                                    x = k + 1
                                                                                End If
                                                                            ElseIf tokee(x) = "\" Then
                                                                                x += 1
                                                                                If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                                    x += 1
                                                                                Else
                                                                                    errorCtr += 1
                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                    objList.SubItems.Add(linee(x))
                                                                                    objList.SubItems.Add("Only single statement is allowed")
                                                                                    k = x
                                                                                    While tokee(k) <> "newline"
                                                                                        k += 1
                                                                                    End While
                                                                                    x = k + 1
                                                                                End If
                                                                            ElseIf tokee(x) = ":<" Then
                                                                                GoTo coutrep
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add("Expected terminator/ output symbol")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                                x = k + 1
                                                                            End If
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected reserved symbol: ']'")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Invalid index for array")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = "oppar" Then '@a(
                                                                    x += 1
funcpar:                                                            If tokee(x) = "wholelit" Or tokee(x) = "textlit" Or tokee(x) = "flaglit" Or tokee(x) = "fraclit" Then '@a("sang"                                                                        x += 1
                                                                        x += 1
                                                                        If tokee(x) = "clpar" Then '@a("sang")
                                                                            GoTo funcclpar
                                                                        ElseIf tokee(x) = "," Then
                                                                            x += 1
                                                                            GoTo funcpar
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected close parenthesis/ separator")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    ElseIf tokee(x) = "id" Then '@a(@b
                                                                        x += 1
                                                                        If tokee(x) = "," Then '@a(@b,
                                                                            x += 1
                                                                            GoTo funcpar
                                                                        ElseIf tokee(x) = "clpar" Then '@a(@b)
                                                                            GoTo funcclpar
                                                                        ElseIf tokee(x) = "opsquare" Then '@a(@b[
                                                                            x += 1
                                                                            If tokee(x) = "id" Or tokee(x) = "wholelit" Then '@a(@b[7
                                                                                x += 1
                                                                                If tokee(x) = "clsquare" Then '@a(@b[7]
                                                                                    x += 1
                                                                                    If tokee(x) = "clpar" Then '@a(@b[9])
                                                                                        GoTo funcclpar
                                                                                    ElseIf tokee(x) = "," Then '@a(@b[9],
                                                                                        x += 1
                                                                                        GoTo funcpar
                                                                                    ElseIf tokee(x) = "opsquare" Then '@a(@b[9][
                                                                                        x += 1
                                                                                        If tokee(x) = "id" Or tokee(x) = "wholelit" Then '@a(@b[9][8
                                                                                            x += 1
                                                                                            If tokee(x) = "clsquare" Then '@a(@b[9][8]
                                                                                                x += 1
                                                                                                If tokee(x) = "clpar" Then '@a(@b[9][8])
                                                                                                    GoTo funcclpar
                                                                                                ElseIf tokee(x) = "," Then '@a(@b[9][8],
                                                                                                    x += 1
                                                                                                    GoTo funcpar
                                                                                                Else
                                                                                                    errorCtr += 1
                                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                                    objList.SubItems.Add(linee(x))
                                                                                                    objList.SubItems.Add("Expected close parenthesis/ separator")
                                                                                                    k = x
                                                                                                    While tokee(k) <> "newline"
                                                                                                        k += 1
                                                                                                    End While
                                                                                                    x = k + 1
                                                                                                End If
                                                                                            Else
                                                                                                errorCtr += 1
                                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                                objList.SubItems.Add(linee(x))
                                                                                                objList.SubItems.Add("Expected reserved symbol: ']'")
                                                                                                k = x
                                                                                                While tokee(k) <> "newline"
                                                                                                    k += 1
                                                                                                End While
                                                                                                x = k + 1
                                                                                            End If
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Invalid index for array")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                        End If
                                                                                    Else
                                                                                        errorCtr += 1
                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                        objList.SubItems.Add(linee(x))
                                                                                        objList.SubItems.Add("Expected close parenthesis/ separator")
                                                                                        k = x
                                                                                        While tokee(k) <> "newline"
                                                                                            k += 1
                                                                                        End While
                                                                                        x = k + 1
                                                                                    End If
                                                                                Else
                                                                                    errorCtr += 1
                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                    objList.SubItems.Add(linee(x))
                                                                                    objList.SubItems.Add("Expected reserved symbol: ']'")
                                                                                    k = x
                                                                                    While tokee(k) <> "newline"
                                                                                        k += 1
                                                                                    End While
                                                                                    x = k + 1
                                                                                End If
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add("Invalid index for array")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                                x = k + 1
                                                                            End If
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected close parenthesis/ separator")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    ElseIf tokee(x) = "clpar" Then
funcclpar:                                                              x += 1
                                                                        If tokee(x) = "\" Then ':<@a[2][5]\
                                                                            x += 1
                                                                            If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                                x += 1
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add("Only single statement is allowed")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                                x = k + 1
                                                                            End If
                                                                        ElseIf tokee(x) = ":<" Then
                                                                            GoTo coutrep
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected terminator/ output symbol")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Invalid parameter for function calling")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = "\" Then
                                                                    x += 1
                                                                    If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                        x += 1
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Only single statement is allowed")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = ":<" Then
                                                                    GoTo coutrep
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Invalid symbol after identifier")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            Else
mathid:                                                         x += 1
                                                                If tokee(x) = "mathOp" Then '@a+
mathope:                                                            x += 1
                                                                    If tokee(x) = "id" Then
                                                                        GoTo mathid
                                                                    ElseIf tokee(x) = "wholelit" Then
                                                                        GoTo mathwhole
                                                                    ElseIf tokee(x) = "fraclit" Then
                                                                        GoTo mathfrac
                                                                    ElseIf tokee(x) = "oppar" Then
                                                                        GoTo mathoppar
                                                                    ElseIf tokee(x) = "~" Then
                                                                        GoTo mathneg
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Expected operand after operator")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = "!+" Then '@a!+
                                                                    x += 1
                                                                    If tokee(x) = "id" Then '@a!+@b
                                                                        x += 1
                                                                        If tokee(x) = "mathOp" Then '@a!+@b *
                                                                            GoTo mathope
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected math operator after board access")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Expected identifier after '!+'")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = "opsquare" Then '@a[
                                                                    x += 1
                                                                    If tokee(x) = "id" Or tokee(x) = "wholelit" Then '@a[7
                                                                        x += 1
                                                                        If tokee(x) = "clsquare" Then '@a[7]
                                                                            x += 1
                                                                            If tokee(x) = "opsquare" Then '@a[9][
                                                                                x += 1
                                                                                If tokee(x) = "id" Or tokee(x) = "wholelit" Then '@a[9][8
                                                                                    x += 1
                                                                                    If tokee(x) = "clsquare" Then '@a[9][8]
                                                                                        x += 1
                                                                                        If tokee(x) = "mathOp" Then
                                                                                            GoTo mathope
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Expected math operator after array")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                        End If
                                                                                    Else
                                                                                        errorCtr += 1
                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                        objList.SubItems.Add(linee(x))
                                                                                        objList.SubItems.Add("Expected reserved symbol: ']'")
                                                                                        k = x
                                                                                        While tokee(k) <> "newline"
                                                                                            k += 1
                                                                                        End While
                                                                                        x = k + 1
                                                                                    End If
                                                                                Else
                                                                                    errorCtr += 1
                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                    objList.SubItems.Add(linee(x))
                                                                                    objList.SubItems.Add("Invalid index for array")
                                                                                    k = x
                                                                                    While tokee(k) <> "newline"
                                                                                        k += 1
                                                                                    End While
                                                                                    x = k + 1
                                                                                End If
                                                                            ElseIf tokee(x) = "mathOp" Then '@a[9]+
                                                                                GoTo mathope
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add("Expected math operator after array")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                                x = k + 1
                                                                            End If
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected reserved symbol: ']'")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Invalid index for array")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = "clpar" Then
                                                                    GoTo mathclpar
                                                                ElseIf tokee(x) = "\" Then
                                                                    x += 1
                                                                    If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                        x += 1
                                                                        parCtr = 0
                                                                        k = x
                                                                        While tokee(k) <> ":<"
                                                                            If tokee(k) = "oppar" Then
                                                                                parCtr += 1
                                                                            ElseIf tokee(k) = "clpar" Then
                                                                                parCtr -= 1
                                                                            End If
                                                                            k -= 1
                                                                        End While
                                                                        If parCtr > 0 Then
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Missing ')'")
                                                                        End If
                                                                        If parCtr < 0 Then
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Missing '('")
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Only single statement is allowed")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = ":<" Then
                                                                    GoTo coutrep
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Expected math operator after identifier")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            End If
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Invalid value after output symbol")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Expected reserved symbol: ':<'")
                                                        k = x
                                                        While tokee(k) <> "newline"
                                                            k += 1
                                                        End While
                                                        x = k + 1
                                                    End If
                                                ElseIf tokee(x) = "increOp" Or tokee(x) = "decreOp" Then
                                                    x += 1
                                                    If tokee(x) = "id" Then
                                                        x += 1
                                                        If tokee(x) = "\" Then
                                                            x += 1
                                                            If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                x += 1
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Only single statement is allowed")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Expected statement terminator")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Expected identifier after incre/decre operator")
                                                        k = x
                                                        While tokee(k) <> "newline"
                                                            k += 1
                                                        End While
                                                        x = k + 1
                                                    End If
                                                ElseIf tokee(x) = "clearfield" Then
                                                    x += 1
                                                    If tokee(x) = "\" Then
                                                        x += 1
                                                        If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                            x += 1
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Only single statement is allowed")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Expected statement terminator")
                                                        k = x
                                                        While tokee(k) <> "newline"
                                                            k += 1
                                                        End While
                                                        x = k + 1
                                                    End If
                                                ElseIf tokee(x) = "when" Then
                                                    'WAIT
                                                ElseIf tokee(x) = "take" Then
                                                    'WAIT
                                                ElseIf tokee(x) = "till" Then 'till
                                                    x += 1
                                                    If tokee(x) = "oppar" Then 'till(
                                                        x += 1
                                                        If tokee(x) = "id" Then 'till(@i
                                                            x += 1
                                                            If tokee(x) = "assgnOp" Then 'till(@i=
                                                                x += 1
                                                                If tokee(x) = "wholelit" Or tokee(x) = "id" Then 'till(@i=0
                                                                    x += 1
                                                                    If tokee(x) = "\" Then 'till(i=0\
                                                                        x += 1
                                                                        If tokee(x) = "id" Then 'till(@i=0\@i
                                                                            x += 1
                                                                            If tokee(x) = "relOp1" Then 'till(@i=0\@i<
                                                                                x += 1
                                                                                If tokee(x) = "id" Then 'till(@i=0\@i<@a
timathid:                                                                           x += 1
                                                                                    If tokee(x) = "mathOp" Then 'till(@i=0\@i<@a+
timathope:                                                                              x += 1
                                                                                        If tokee(x) = "id" Then
                                                                                            GoTo timathid
                                                                                        ElseIf tokee(x) = "wholelit" Or tokee(x) = "fraclit" Then
                                                                                            GoTo timathwhole
                                                                                        ElseIf tokee(x) = "oppar" Then
                                                                                            GoTo timathoppar
                                                                                        ElseIf tokee(x) = "~" Then
                                                                                            GoTo timathneg
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Expected operand after operator")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                            GoTo tilopsymbol
                                                                                        End If
                                                                                    ElseIf tokee(x) = "!+" Then '@a!+
                                                                                        x += 1
                                                                                        If tokee(x) = "id" Then '@a!+@b
                                                                                            x += 1
                                                                                            If tokee(x) = "mathOp" Then '@a!+@b *
                                                                                                GoTo timathope
                                                                                            ElseIf tokee(x) = "\" Then
                                                                                                GoTo incredecrenext
                                                                                            Else
                                                                                                errorCtr += 1
                                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                                objList.SubItems.Add(linee(x))
                                                                                                objList.SubItems.Add("Expected math operator/terminator after board access")
                                                                                                k = x
                                                                                                While tokee(k) <> "newline"
                                                                                                    k += 1
                                                                                                End While
                                                                                                x = k + 1
                                                                                                GoTo tilopsymbol
                                                                                            End If
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Expected identifier after '!+'")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                            GoTo tilopsymbol
                                                                                        End If
                                                                                    ElseIf tokee(x) = "opsquare" Then '@a[
                                                                                        x += 1
                                                                                        If tokee(x) = "id" Or tokee(x) = "wholelit" Then '@a[7
                                                                                            x += 1
                                                                                            If tokee(x) = "clsquare" Then '@a[7]
                                                                                                x += 1
                                                                                                If tokee(x) = "opsquare" Then '@a[9][
                                                                                                    x += 1
                                                                                                    If tokee(x) = "id" Or tokee(x) = "wholelit" Then '@a[9][8
                                                                                                        x += 1
                                                                                                        If tokee(x) = "clsquare" Then '@a[9][8]
                                                                                                            x += 1
                                                                                                            If tokee(x) = "mathOp" Then
                                                                                                                GoTo timathope
                                                                                                            ElseIf tokee(x) = "\" Then
                                                                                                                GoTo incredecrenext
                                                                                                            Else
                                                                                                                errorCtr += 1
                                                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                                                objList.SubItems.Add(linee(x))
                                                                                                                objList.SubItems.Add("Expected math operator/terminator after array")
                                                                                                                k = x
                                                                                                                While tokee(k) <> "newline"
                                                                                                                    k += 1
                                                                                                                End While
                                                                                                                x = k + 1
                                                                                                                GoTo tilopsymbol
                                                                                                            End If
                                                                                                        Else
                                                                                                            errorCtr += 1
                                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                                            objList.SubItems.Add(linee(x))
                                                                                                            objList.SubItems.Add("Expected reserved symbol: ']'")
                                                                                                            k = x
                                                                                                            While tokee(k) <> "newline"
                                                                                                                k += 1
                                                                                                            End While
                                                                                                            x = k + 1
                                                                                                            GoTo tilopsymbol
                                                                                                        End If
                                                                                                    Else
                                                                                                        errorCtr += 1
                                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                                        objList.SubItems.Add(linee(x))
                                                                                                        objList.SubItems.Add("Invalid index for array")
                                                                                                        k = x
                                                                                                        While tokee(k) <> "newline"
                                                                                                            k += 1
                                                                                                        End While
                                                                                                        x = k + 1
                                                                                                        GoTo tilopsymbol
                                                                                                    End If
                                                                                                ElseIf tokee(x) = "mathOp" Then '@a[9]+
                                                                                                    GoTo timathope
                                                                                                ElseIf tokee(x) = "\" Then
                                                                                                    GoTo incredecrenext
                                                                                                Else
                                                                                                    errorCtr += 1
                                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                                    objList.SubItems.Add(linee(x))
                                                                                                    objList.SubItems.Add("Expected math operator/terminator after array")
                                                                                                    k = x
                                                                                                    While tokee(k) <> "newline"
                                                                                                        k += 1
                                                                                                    End While
                                                                                                    x = k + 1
                                                                                                    GoTo tilopsymbol
                                                                                                End If
                                                                                            Else
                                                                                                errorCtr += 1
                                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                                objList.SubItems.Add(linee(x))
                                                                                                objList.SubItems.Add("Expected reserved symbol: ']'")
                                                                                                k = x
                                                                                                While tokee(k) <> "newline"
                                                                                                    k += 1
                                                                                                End While
                                                                                                x = k + 1
                                                                                                GoTo tilopsymbol
                                                                                            End If
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Invalid index for array")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                            GoTo tilopsymbol
                                                                                        End If
                                                                                    ElseIf tokee(x) = "clpar" Then
                                                                                        GoTo timathclpar
                                                                                    ElseIf tokee(x) = "\" Then 'till(@i=0\@i<@a\
incredecrenext:                                                                         x += 1
                                                                                        'CHECK
                                                                                        parCtr = 0
                                                                                        k = x
                                                                                        While tokee(k) <> "relOp1"
                                                                                            If tokee(k) = "oppar" Then
                                                                                                parCtr += 1
                                                                                            ElseIf tokee(k) = "clpar" Then
                                                                                                parCtr -= 1
                                                                                            End If
                                                                                            k -= 1
                                                                                        End While
                                                                                        If parCtr > 0 Then
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Missing ')'")
                                                                                        End If
                                                                                        If parCtr < 0 Then
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Missing '('")
                                                                                        End If
                                                                                        'NEXT
                                                                                        If tokee(x) = "increOp" Or tokee(x) = "decreOp" Then 'till(@i=0\@i<@a\++
                                                                                            x += 1
                                                                                            If tokee(x) = "id" Then 'till(@i=0\@i<@a\++@a
                                                                                                x += 1
tilclpar:                                                                                       If tokee(x) = "clpar" Then 'till(@i=0\@i<@a\++@a)
                                                                                                    MessageBox.Show(tokee(x))
                                                                                                    x += 1
tilopsymbol:                                                                                        If tokee(x) = "opsymbol" Then 'till(@i=0\@i<@a\++@a) <<
                                                                                                        MessageBox.Show(tokee(x))
                                                                                                        x += 1
                                                                                                        GoTo state
                                                                                                    ElseIf tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                                                        k = x
                                                                                                        While tokee(k) = "newline" Or tokee(k) = "comment"
                                                                                                            k += 1
                                                                                                        End While
                                                                                                        x = k
                                                                                                        If tokee(x) = "opsymbol" Then
                                                                                                            MessageBox.Show(tokee(x))
                                                                                                            x += 1
                                                                                                            GoTo state
                                                                                                        End If
                                                                                                    Else
                                                                                                        MessageBox.Show(tokee(x))
                                                                                                        errorCtr += 1
                                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                                        objList.SubItems.Add(linee(x))
                                                                                                        objList.SubItems.Add("Expected reserved symbol: '<<'")
                                                                                                        GoTo majornoop
                                                                                                    End If
                                                                                                Else
                                                                                                    errorCtr += 1
                                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                                    objList.SubItems.Add(linee(x))
                                                                                                    objList.SubItems.Add("Expected reserved symbol: ')' after till update")
                                                                                                    k = x
                                                                                                    While tokee(k) <> "newline"
                                                                                                        k += 1
                                                                                                    End While
                                                                                                    x = k + 1
                                                                                                    GoTo tilopsymbol
                                                                                                End If
                                                                                            Else
                                                                                                errorCtr += 1
                                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                                objList.SubItems.Add(linee(x))
                                                                                                objList.SubItems.Add("Expected id after incre/decre operator in till update")
                                                                                                k = x
                                                                                                While tokee(k) <> "newline"
                                                                                                    k += 1
                                                                                                End While
                                                                                                x = k + 1
                                                                                                GoTo tilopsymbol
                                                                                            End If
                                                                                        ElseIf tokee(x) = "id" Then 'till(@i=0\@i<@a\@a
                                                                                            x += 1
                                                                                            If tokee(x) = "increOp" Or tokee(x) = "decreOp" Then 'till(@i=0\@i<@a\@a--
                                                                                                x += 1
                                                                                                GoTo tilclpar
                                                                                            ElseIf tokee(x) = "assgnOp2" Then 'till(@i=0\@i<@a\@a-=
                                                                                                x += 1
                                                                                                If tokee(x) = "wholelit" Or tokee(x) = "fraclit" Then
                                                                                                    x += 1
                                                                                                    GoTo tilclpar
                                                                                                Else
                                                                                                    errorCtr += 1
                                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                                    objList.SubItems.Add(linee(x))
                                                                                                    objList.SubItems.Add("Expected wholelit/fraclit after operator in till update")
                                                                                                    k = x
                                                                                                    While tokee(k) <> "newline"
                                                                                                        k += 1
                                                                                                    End While
                                                                                                    x = k + 1
                                                                                                    GoTo tilopsymbol
                                                                                                End If
                                                                                            Else
                                                                                                errorCtr += 1
                                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                                objList.SubItems.Add(linee(x))
                                                                                                objList.SubItems.Add("Invalid value after operator in till update")
                                                                                                k = x
                                                                                                While tokee(k) <> "newline"
                                                                                                    k += 1
                                                                                                End While
                                                                                                x = k + 1
                                                                                                GoTo tilopsymbol
                                                                                            End If
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Invalid operator/value for till update")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                            GoTo tilopsymbol
                                                                                        End If
                                                                                    Else
                                                                                        errorCtr += 1
                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                        objList.SubItems.Add(linee(x))
                                                                                        objList.SubItems.Add("Expected math operator/terminator after operand")
                                                                                        k = x
                                                                                        While tokee(k) <> "newline"
                                                                                            k += 1
                                                                                        End While
                                                                                        x = k + 1
                                                                                        GoTo tilopsymbol
                                                                                    End If
                                                                                ElseIf tokee(x) = "wholelit" Or tokee(x) = "fraclit" Then
timathwhole:                                                                        x += 1
                                                                                    If tokee(x) = "mathOp" Then
                                                                                        x += 1
                                                                                        If tokee(x) = "id" Then
                                                                                            GoTo timathid
                                                                                        ElseIf tokee(x) = "wholelit" Or tokee(x) = "fraclit" Then
                                                                                            GoTo timathwhole
                                                                                        ElseIf tokee(x) = "oppar" Then
                                                                                            GoTo timathoppar
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Expected operand after operator")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                            GoTo tilopsymbol
                                                                                        End If
                                                                                    ElseIf tokee(x) = "clpar" Then
timathclpar:                                                                            x += 1
                                                                                        If tokee(x) = "clpar" Then
                                                                                            GoTo timathclpar
                                                                                        ElseIf tokee(x) = "\" Then
                                                                                            GoTo incredecrenext
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Expected math operator/terminator after operand")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                            GoTo tilopsymbol
                                                                                        End If
                                                                                    ElseIf tokee(x) = "\" Then
                                                                                        GoTo incredecrenext
                                                                                    Else
                                                                                        errorCtr += 1
                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                        objList.SubItems.Add(linee(x))
                                                                                        objList.SubItems.Add("Expected math operator/terminator after operand")
                                                                                        k = x
                                                                                        While tokee(k) <> "newline"
                                                                                            k += 1
                                                                                        End While
                                                                                        x = k + 1
                                                                                        GoTo tilopsymbol
                                                                                    End If
                                                                                ElseIf tokee(x) = "oppar" Then
timathoppar:                                                                        x += 1
                                                                                    If tokee(x) = "id" Then
                                                                                        GoTo timathid
                                                                                    ElseIf tokee(x) = "wholelit" Or tokee(x) = "fraclit" Then
                                                                                        GoTo timathwhole
                                                                                    ElseIf tokee(x) = "oppar" Then
                                                                                        GoTo timathoppar
                                                                                    ElseIf tokee(x) = "~" Then
                                                                                        GoTo timathneg
                                                                                    Else
                                                                                        errorCtr += 1
                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                        objList.SubItems.Add(linee(x))
                                                                                        objList.SubItems.Add("Expected operand after '('")
                                                                                        k = x
                                                                                        While tokee(k) <> "newline"
                                                                                            k += 1
                                                                                        End While
                                                                                        x = k + 1
                                                                                        GoTo tilopsymbol
                                                                                    End If
                                                                                ElseIf tokee(x) = "~" Then
timathneg:                                                                          x += 1
                                                                                    If tokee(x) = "oppar" Then
                                                                                        GoTo timathoppar
                                                                                    Else
                                                                                        errorCtr += 1
                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                        objList.SubItems.Add(linee(x))
                                                                                        objList.SubItems.Add("Expected open parenthesis after '~'")
                                                                                        k = x
                                                                                        While tokee(k) <> "newline"
                                                                                            k += 1
                                                                                        End While
                                                                                        x = k + 1
                                                                                        GoTo tilopsymbol
                                                                                    End If
                                                                                Else
                                                                                    errorCtr += 1
                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                    objList.SubItems.Add(linee(x))
                                                                                    objList.SubItems.Add("Expected/Invalid value after relational operator in condition")
                                                                                    k = x
                                                                                    While tokee(k) <> "newline"
                                                                                        k += 1
                                                                                    End While
                                                                                    x = k + 1
                                                                                    GoTo tilopsymbol
                                                                                End If
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add("Expected relational operator after id in condition")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                                x = k + 1
                                                                                GoTo tilopsymbol
                                                                            End If
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected identifier in condition")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                            GoTo tilopsymbol
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Expected terminator '\' after initialization")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                        GoTo tilopsymbol
                                                                    End If
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Expected wholelit or id after '=' in initialization")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                    GoTo tilopsymbol
                                                                End If
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected assignment operator after id in initialization")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                                GoTo tilopsymbol
                                                            End If
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Expected identifier after '(' in initialization")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                            GoTo tilopsymbol
                                                        End If
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Expected reserved symbol: '('")
                                                        k = x
                                                        While tokee(k) <> "newline"
                                                            k += 1
                                                        End While
                                                        x = k + 1
                                                        GoTo tilopsymbol
                                                    End If
                                                ElseIf tokee(x) = "during" Then
                                                    x += 1
duroppar:                                           If tokee(x) = "oppar" Then 'during (
                                                        x += 1
                                                        If tokee(x) = "id" Then 'during (@a
durid:                                                      x += 1
                                                            If tokee(x) = "relOp1" Then 'during (@a<
                                                                x += 1
durrelope:                                                      If tokee(x) = "id" Then 'during (@a<@b
dumathid:                                                           x += 1
                                                                    If tokee(x) = "mathOp" Then 'during (@a<@b-
dumathope:                                                              x += 1
                                                                        If tokee(x) = "id" Then
                                                                            GoTo dumathid
                                                                        ElseIf tokee(x) = "wholelit" Or tokee(x) = "fraclit" Then
                                                                            GoTo dumathwhole
                                                                        ElseIf tokee(x) = "oppar" Then
                                                                            GoTo dumathoppar
                                                                        ElseIf tokee(x) = "~" Then
                                                                            GoTo dumathneg
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected operand after operator")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                            GoTo duropsym
                                                                        End If
                                                                    ElseIf tokee(x) = "!+" Then '@a!+
                                                                        x += 1
                                                                        If tokee(x) = "id" Then '@a!+@b
                                                                            x += 1
                                                                            If tokee(x) = "mathOp" Then '@a!+@b *
                                                                                GoTo dumathope
                                                                            Else
                                                                                GoTo duropsym
                                                                            End If
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected identifier after '!+'")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                            GoTo duropsym
                                                                        End If
                                                                    ElseIf tokee(x) = "opsquare" Then '@a[
                                                                        x += 1
                                                                        If tokee(x) = "id" Or tokee(x) = "wholelit" Then '@a[7
                                                                            x += 1
                                                                            If tokee(x) = "clsquare" Then '@a[7]
                                                                                x += 1
                                                                                If tokee(x) = "opsquare" Then '@a[9][
                                                                                    x += 1
                                                                                    If tokee(x) = "id" Or tokee(x) = "wholelit" Then '@a[9][8
                                                                                        x += 1
                                                                                        If tokee(x) = "clsquare" Then '@a[9][8]
                                                                                            x += 1
                                                                                            If tokee(x) = "mathOp" Then
                                                                                                GoTo dumathope
                                                                                            Else
                                                                                                GoTo duropsym
                                                                                            End If
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Expected reserved symbol: ']'")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                            GoTo duropsym
                                                                                        End If
                                                                                    Else
                                                                                        errorCtr += 1
                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                        objList.SubItems.Add(linee(x))
                                                                                        objList.SubItems.Add("Invalid index for array")
                                                                                        k = x
                                                                                        While tokee(k) <> "newline"
                                                                                            k += 1
                                                                                        End While
                                                                                        x = k + 1
                                                                                        GoTo duropsym
                                                                                    End If
                                                                                ElseIf tokee(x) = "mathOp" Then '@a[9]+
                                                                                    GoTo dumathope
                                                                                Else
                                                                                    GoTo duropsym
                                                                                End If
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add("Expected reserved symbol: ']'")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                                x = k + 1
                                                                                GoTo duropsym
                                                                            End If
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Invalid index for array")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                            GoTo duropsym
                                                                        End If
                                                                    ElseIf tokee(x) = "clpar" Then
                                                                        GoTo dumathclpar
                                                                    Else
                                                                        GoTo duropsym
                                                                    End If
                                                                ElseIf tokee(x) = "wholelit" Or tokee(x) = "fraclit" Then '(@a<3
dumathwhole:                                                        x += 1
                                                                    If tokee(x) = "mathOp" Then
                                                                        x += 1
                                                                        If tokee(x) = "id" Then
                                                                            GoTo dumathid
                                                                        ElseIf tokee(x) = "wholelit" Or tokee(x) = "fraclit" Then
                                                                            GoTo dumathwhole
                                                                        ElseIf tokee(x) = "oppar" Then
                                                                            GoTo dumathoppar
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected operand after operator")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                            GoTo duropsym
                                                                        End If
                                                                    ElseIf tokee(x) = "clpar" Then
dumathclpar:                                                            x += 1
                                                                        If tokee(x) = "clpar" Then
                                                                            GoTo dumathclpar
                                                                        ElseIf tokee(x) = "logOp" Then
                                                                            x += 1
                                                                            GoTo duroppar
                                                                        Else
                                                                            GoTo duropsym
                                                                        End If
                                                                    Else
                                                                        GoTo duropsym
                                                                    End If
                                                                ElseIf tokee(x) = "oppar" Then
dumathoppar:                                                        x += 1
                                                                    If tokee(x) = "id" Then
                                                                        GoTo dumathid
                                                                    ElseIf tokee(x) = "wholelit" Or tokee(x) = "fraclit" Then
                                                                        GoTo dumathwhole
                                                                    ElseIf tokee(x) = "oppar" Then
                                                                        GoTo dumathoppar
                                                                    ElseIf tokee(x) = "~" Then
                                                                        GoTo dumathneg
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Expected operand after '('")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                        GoTo duropsym
                                                                    End If
                                                                ElseIf tokee(x) = "~" Then
dumathneg:                                                          x += 1
                                                                    If tokee(x) = "oppar" Then
                                                                        GoTo dumathoppar
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Expected open parenthesis after '~'")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                        GoTo duropsym
                                                                    End If
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Expected/Invalid value after relational operator in condition")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                    GoTo duropsym
                                                                End If
                                                            ElseIf tokee(x) = "relOp2" Then
                                                                x += 1
                                                                If tokee(x) = "textlit" Or tokee(x) = "flaglit" Then
                                                                    x += 1
                                                                    If tokee(x) = "clpar" Then
                                                                        x += 1
                                                                        GoTo duropsym
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Expected reserved symbol: ')'")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                        GoTo duropsym
                                                                    End If
                                                                ElseIf tokee(x) = "id" Or tokee(x) = "wholelit" Or tokee(x) = "fraclit" Or tokee(x) = "oppar" Or tokee(x) = "~" Then
                                                                    GoTo durrelope
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Invalid value in condition after relational operator")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                    GoTo duropsym
                                                                End If
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Invalid value in condition after identifier")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                                GoTo duropsym
                                                            End If
                                                        ElseIf tokee(x) = "oppar" Then
                                                            x += 1
                                                            GoTo duroppar
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Invalid value in condition after '('")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                            GoTo duropsym
                                                        End If
                                                    ElseIf tokee(x) = "!" Then 'during !
                                                        x += 1
                                                        If tokee(x) = "flaglit" Then 'during !true
                                                            x += 1
duropsym:                                                   parCtr = 0
                                                            k = x
                                                            While tokee(k) <> "during"
                                                                If tokee(k) = "oppar" Then
                                                                    parCtr += 1
                                                                ElseIf tokee(k) = "clpar" Then
                                                                    parCtr -= 1
                                                                End If
                                                                k -= 1
                                                            End While
                                                            If parCtr > 0 Then
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Missing ')'")
                                                            End If
                                                            If parCtr < 0 Then
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Missing '('")
                                                            End If
                                                            'START TALAGA DURING
                                                            If tokee(x) = "opsymbol" Then 'during !true <<
                                                                x += 1
                                                                GoTo state
                                                            ElseIf tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                k = x
                                                                While tokee(k) = "newline" Or tokee(k) = "comment"
                                                                    k += 1
                                                                End While
                                                                x = k
                                                                If tokee(x) = "opsymbol" Then
                                                                    x += 1
                                                                    GoTo state
                                                                End If
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected reserved symbol: '<<'")
                                                                GoTo majornoop
                                                            End If
                                                        ElseIf tokee(x) = "id" Then
                                                            x += 1
                                                            GoTo duropsym
                                                        ElseIf tokee(x) = "oppar" Then
                                                            GoTo duroppar
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Invalid value in condition after '!'")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                            GoTo duropsym
                                                        End If
                                                    ElseIf tokee(x) = "id" Then
                                                        GoTo durid
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Invalid value in condition")
                                                        k = x
                                                        While tokee(k) <> "newline"
                                                            k += 1
                                                        End While
                                                        x = k + 1
                                                        GoTo duropsym
                                                    End If
                                                ElseIf tokee(x) = "run" Then
                                                    x += 1
                                                    If tokee(x) = "opsymbol" Then
runopsymbol:                                            x += 1
                                                        While x < dGridLexi.Items.Count
runnoop:                                                    If tokee(x) = "checkin" Or tokee(x) = "checkout" Or tokee(x) = "when" Or tokee(x) = "take" Or tokee(x) = "till" _
                                                                  Or tokee(x) = "id" Or tokee(x) = "during" Or tokee(x) = "run" Or tokee(x) = "clearfield" Or tokee(x) = "increOp" Or tokee(x) = "decreOp" Then
                                                                GoTo state
                                                            ElseIf tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                x += 1
                                                            ElseIf tokee(x) = "clsymbol" Then
runclsymbol:                                                    x += 1
                                                                If tokee(x) = "during" Then
                                                                    '***********************************************
rundur:                                                             x += 1
runoppar:                                                           If tokee(x) = "oppar" Then 'during (
                                                                        x += 1
                                                                        If tokee(x) = "id" Then 'during (@a
runid:                                                                      x += 1
                                                                            If tokee(x) = "relOp1" Then 'during (@a<
                                                                                x += 1
runrelope:                                                                      If tokee(x) = "id" Then 'during (@a<@b
runmathid:                                                                          x += 1
                                                                                    If tokee(x) = "mathOp" Then 'during (@a<@b-
runmathope:                                                                             x += 1
                                                                                        If tokee(x) = "id" Then
                                                                                            GoTo runmathid
                                                                                        ElseIf tokee(x) = "wholelit" Or tokee(x) = "fraclit" Then
                                                                                            GoTo runmathwhole
                                                                                        ElseIf tokee(x) = "oppar" Then
                                                                                            GoTo runmathoppar
                                                                                        ElseIf tokee(x) = "~" Then
                                                                                            GoTo runmathneg
                                                                                        ElseIf tokee(x) = "\" Then
                                                                                            GoTo runter
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Expected/Invalid value after math operator in condition")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                            GoTo state
                                                                                        End If
                                                                                    ElseIf tokee(x) = "!+" Then '@a!+
                                                                                        x += 1
                                                                                        If tokee(x) = "id" Then '@a!+@b
                                                                                            x += 1
                                                                                            If tokee(x) = "mathOp" Then '@a!+@b *
                                                                                                GoTo runmathope
                                                                                            ElseIf tokee(x) = "\" Then
                                                                                                GoTo runter
                                                                                            Else
                                                                                                errorCtr += 1
                                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                                objList.SubItems.Add(linee(x))
                                                                                                objList.SubItems.Add("Expected operator after identifier")
                                                                                                k = x
                                                                                                While tokee(k) <> "newline"
                                                                                                    k += 1
                                                                                                End While
                                                                                                x = k + 1
                                                                                                GoTo state
                                                                                            End If
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Expected identifier after '!+'")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                            GoTo state
                                                                                        End If
                                                                                    ElseIf tokee(x) = "opsquare" Then '@a[
                                                                                        x += 1
                                                                                        If tokee(x) = "id" Or tokee(x) = "wholelit" Then '@a[7
                                                                                            x += 1
                                                                                            If tokee(x) = "clsquare" Then '@a[7]
                                                                                                x += 1
                                                                                                If tokee(x) = "opsquare" Then '@a[9][
                                                                                                    x += 1
                                                                                                    If tokee(x) = "id" Or tokee(x) = "wholelit" Then '@a[9][8
                                                                                                        x += 1
                                                                                                        If tokee(x) = "clsquare" Then '@a[9][8]
                                                                                                            x += 1
                                                                                                            If tokee(x) = "mathOp" Then
                                                                                                                GoTo runmathope
                                                                                                            ElseIf tokee(x) = "\" Then
                                                                                                                GoTo runter
                                                                                                            Else
                                                                                                                errorCtr += 1
                                                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                                                objList.SubItems.Add(linee(x))
                                                                                                                objList.SubItems.Add("Expected terminator after array in condition")
                                                                                                                k = x
                                                                                                                While tokee(k) <> "newline"
                                                                                                                    k += 1
                                                                                                                End While
                                                                                                                x = k + 1
                                                                                                                GoTo state
                                                                                                            End If
                                                                                                        Else
                                                                                                            errorCtr += 1
                                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                                            objList.SubItems.Add(linee(x))
                                                                                                            objList.SubItems.Add("Expected reserved symbol: ']'")
                                                                                                            k = x
                                                                                                            While tokee(k) <> "newline"
                                                                                                                k += 1
                                                                                                            End While
                                                                                                            x = k + 1
                                                                                                            GoTo state
                                                                                                        End If
                                                                                                    Else
                                                                                                        errorCtr += 1
                                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                                        objList.SubItems.Add(linee(x))
                                                                                                        objList.SubItems.Add("Invalid index for array")
                                                                                                        k = x
                                                                                                        While tokee(k) <> "newline"
                                                                                                            k += 1
                                                                                                        End While
                                                                                                        x = k + 1
                                                                                                        GoTo state
                                                                                                    End If
                                                                                                ElseIf tokee(x) = "mathOp" Then '@a[9]+
                                                                                                    GoTo runmathope
                                                                                                ElseIf tokee(x) = "\" Then
                                                                                                    GoTo runter
                                                                                                Else
                                                                                                    errorCtr += 1
                                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                                    objList.SubItems.Add(linee(x))
                                                                                                    objList.SubItems.Add("Expected terminator after array in condition")
                                                                                                    k = x
                                                                                                    While tokee(k) <> "newline"
                                                                                                        k += 1
                                                                                                    End While
                                                                                                    x = k + 1
                                                                                                    GoTo state
                                                                                                End If
                                                                                            Else
                                                                                                errorCtr += 1
                                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                                objList.SubItems.Add(linee(x))
                                                                                                objList.SubItems.Add("Expected reserved symbol: ']'")
                                                                                                k = x
                                                                                                While tokee(k) <> "newline"
                                                                                                    k += 1
                                                                                                End While
                                                                                                x = k + 1
                                                                                                GoTo state
                                                                                            End If
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Invalid index for array")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                            GoTo state
                                                                                        End If
                                                                                    ElseIf tokee(x) = "clpar" Then
                                                                                        GoTo runmathclpar
                                                                                    ElseIf tokee(x) = "\" Then
                                                                                        GoTo runter
                                                                                    End If
                                                                                ElseIf tokee(x) = "wholelit" Or tokee(x) = "fraclit" Then '(@a<3
runmathwhole:                                                                       x += 1
                                                                                    If tokee(x) = "mathOp" Then
                                                                                        x += 1
                                                                                        If tokee(x) = "id" Then
                                                                                            GoTo runmathid
                                                                                        ElseIf tokee(x) = "wholelit" Or tokee(x) = "fraclit" Then
                                                                                            GoTo runmathwhole
                                                                                        ElseIf tokee(x) = "oppar" Then
                                                                                            GoTo runmathoppar
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Expected operand after operator")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                            GoTo state
                                                                                        End If
                                                                                    ElseIf tokee(x) = "clpar" Then
runmathclpar:                                                                           x += 1
                                                                                        If tokee(x) = "clpar" Then
                                                                                            GoTo runmathclpar
                                                                                        ElseIf tokee(x) = "logOp" Then
                                                                                            x += 1
                                                                                            GoTo runoppar
                                                                                        ElseIf tokee(x) = "\" Then
                                                                                            GoTo runter
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Expected terminator after ')' in condition")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                            GoTo state
                                                                                        End If
                                                                                    ElseIf tokee(x) = "\" Then
                                                                                        GoTo runter
                                                                                    Else
                                                                                        errorCtr += 1
                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                        objList.SubItems.Add(linee(x))
                                                                                        objList.SubItems.Add("Expected terminator after wholelit/fraclit in condition")
                                                                                        k = x
                                                                                        While tokee(k) <> "newline"
                                                                                            k += 1
                                                                                        End While
                                                                                        x = k + 1
                                                                                        GoTo state
                                                                                    End If
                                                                                ElseIf tokee(x) = "oppar" Then
runmathoppar:                                                                       x += 1
                                                                                    If tokee(x) = "id" Then
                                                                                        GoTo runmathid
                                                                                    ElseIf tokee(x) = "wholelit" Or tokee(x) = "fraclit" Then
                                                                                        GoTo runmathwhole
                                                                                    ElseIf tokee(x) = "oppar" Then
                                                                                        GoTo runmathoppar
                                                                                    ElseIf tokee(x) = "~" Then
                                                                                        GoTo runmathneg
                                                                                    Else
                                                                                        errorCtr += 1
                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                        objList.SubItems.Add(linee(x))
                                                                                        objList.SubItems.Add("Expected operand after '('")
                                                                                        k = x
                                                                                        While tokee(k) <> "newline"
                                                                                            k += 1
                                                                                        End While
                                                                                        x = k + 1
                                                                                        GoTo state
                                                                                    End If
                                                                                ElseIf tokee(x) = "~" Then
runmathneg:                                                                         x += 1
                                                                                    If tokee(x) = "oppar" Then
                                                                                        GoTo runmathoppar
                                                                                    Else
                                                                                        errorCtr += 1
                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                        objList.SubItems.Add(linee(x))
                                                                                        objList.SubItems.Add("Expected open parenthesis after '~'")
                                                                                        k = x
                                                                                        While tokee(k) <> "newline"
                                                                                            k += 1
                                                                                        End While
                                                                                        x = k + 1
                                                                                        GoTo state
                                                                                    End If
                                                                                ElseIf tokee(x) = "\" Then
runter:                                                                             x += 1
                                                                                    parCtr = 0
                                                                                    k = x
                                                                                    While tokee(k) <> "during"
                                                                                        If tokee(k) = "oppar" Then
                                                                                            parCtr += 1
                                                                                        ElseIf tokee(k) = "clpar" Then
                                                                                            parCtr -= 1
                                                                                        End If
                                                                                        k -= 1
                                                                                    End While
                                                                                    If parCtr > 0 Then
                                                                                        errorCtr += 1
                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                        objList.SubItems.Add(linee(x))
                                                                                        objList.SubItems.Add("Missing ')'")
                                                                                    End If
                                                                                    If parCtr < 0 Then
                                                                                        errorCtr += 1
                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                        objList.SubItems.Add(linee(x))
                                                                                        objList.SubItems.Add("Missing '('")
                                                                                    End If
                                                                                    GoTo state
                                                                                Else
                                                                                    errorCtr += 1
                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                    objList.SubItems.Add(linee(x))
                                                                                    objList.SubItems.Add("Expected/Invalid value after relational operator in condition")
                                                                                    k = x
                                                                                    While tokee(k) <> "newline"
                                                                                        k += 1
                                                                                    End While
                                                                                    x = k + 1
                                                                                    GoTo state
                                                                                End If
                                                                            ElseIf tokee(x) = "relOp2" Then
                                                                                x += 1
                                                                                If tokee(x) = "textlit" Or tokee(x) = "flaglit" Then
                                                                                    x += 1
                                                                                    If tokee(x) = "clpar" Then
                                                                                        x += 1
                                                                                        If tokee(x) = "\" Then
                                                                                            GoTo runter
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Expected terminator after condition in run")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                            GoTo state
                                                                                        End If
                                                                                    Else
                                                                                        errorCtr += 1
                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                        objList.SubItems.Add(linee(x))
                                                                                        objList.SubItems.Add("Expected reserved symbol: ')'")
                                                                                        k = x
                                                                                        While tokee(k) <> "newline"
                                                                                            k += 1
                                                                                        End While
                                                                                        x = k + 1
                                                                                        GoTo state
                                                                                    End If
                                                                                ElseIf tokee(x) = "id" Or tokee(x) = "wholelit" Or tokee(x) = "fraclit" Or tokee(x) = "oppar" Or tokee(x) = "~" Then
                                                                                    GoTo runrelope
                                                                                Else
                                                                                    errorCtr += 1
                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                    objList.SubItems.Add(linee(x))
                                                                                    objList.SubItems.Add("Invalid value in condition after relational operator")
                                                                                    k = x
                                                                                    While tokee(k) <> "newline"
                                                                                        k += 1
                                                                                    End While
                                                                                    x = k + 1
                                                                                    GoTo state
                                                                                End If
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add("Invalid value in condition after identifier")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                                x = k + 1
                                                                                GoTo state
                                                                            End If
                                                                        ElseIf tokee(x) = "oppar" Then
                                                                            x += 1
                                                                            GoTo runoppar
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Invalid value in condition after '('")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                            GoTo state
                                                                        End If
                                                                    ElseIf tokee(x) = "!" Then 'during !
                                                                        x += 1
                                                                        If tokee(x) = "flaglit" Then 'during !true
                                                                            x += 1
                                                                            If tokee(x) = "\" Then
                                                                                GoTo runter
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add("Expected terminator after condition in run")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                                x = k + 1
                                                                                GoTo state
                                                                            End If
                                                                        ElseIf tokee(x) = "id" Then
                                                                            x += 1
                                                                            If tokee(x) = "\" Then
                                                                                GoTo runter
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add("Expected terminator after condition in run")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                                x = k + 1
                                                                                GoTo state
                                                                            End If
                                                                        ElseIf tokee(x) = "oppar" Then
                                                                            GoTo runoppar
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Invalid value in condition after '!'")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                            GoTo state
                                                                        End If
                                                                    ElseIf tokee(x) = "id" Then
                                                                        GoTo runid
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Invalid value in condition")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                        GoTo state
                                                                    End If
                                                                    '************************************************
                                                                ElseIf tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                    k = x
                                                                    While tokee(k) = "newline" Or tokee(k) = "comment"
                                                                        k += 1
                                                                    End While
                                                                    x = k
                                                                    If tokee(x) = "clsymbol" Then
                                                                        GoTo runclsymbol
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("expected reserved symbol: '>>'")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                        'wait goto
                                                                    End If
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("expected reserved word: 'during'")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            ElseIf tokee(x) = "during" Then
                                                                'WAIT
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Invalid statement in run")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        End While
                                                    ElseIf tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                        k = x
                                                        While tokee(k) = "newline" Or tokee(k) = "comment"
                                                            k += 1
                                                        End While
                                                        x = k
                                                        If tokee(x) = "opsymbol" Then
                                                            GoTo runopsymbol
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Expected reserved symbol: '<<'")
                                                            GoTo runnoop
                                                        End If
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Expected reserved symbol: '<<'")
                                                        GoTo runnoop
                                                    End If
                                                ElseIf tokee(x) = "id" Then '@n
                                                    x += 1
                                                    If tokee(x) = "oppar" Then '@n(
                                                        x += 1
                                                        If tokee(x) = "clpar" Then '@n()
                                                            x += 1
                                                            If tokee(x) = "\" Then '@n()\
                                                                x += 1
                                                                If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                    x += 1
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Only single statement is allowed")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected statement terminator")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Function call statement should be with data type vacant and should not have a parameter")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    ElseIf tokee(x) = "assgnOp" Then '@k=
assgnstate:                                             x += 1
                                                        If tokee(x) = "id" Then '@k=@a
                                                            Dim isMath As Boolean = False
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                If tokee(k) = "mathOp" Then
                                                                    isMath = True
                                                                    Exit While
                                                                Else
                                                                    k += 1
                                                                End If
                                                            End While
                                                            If isMath = False Then
                                                                x += 1
                                                                If tokee(x) = "opsquare" Then '@k=@a[
                                                                    x += 1
                                                                    If tokee(x) = "id" Or tokee(x) = "wholelit" Then '@k=@a[4
                                                                        x += 1
                                                                        If tokee(x) = "clsquare" Then '@k=@a[4]
                                                                            x += 1
                                                                            If tokee(x) = "opsquare" Then '@k=@a[4][
                                                                                x += 1
                                                                                If tokee(x) = "wholelit" Or tokee(x) = "id" Then '@k=@a[4][7
                                                                                    x += 1
                                                                                    If tokee(x) = "clsquare" Then '@k=@a[4][7]
                                                                                        x += 1
                                                                                        If tokee(x) = "\" Then '@k=@a[4][7]\
                                                                                            x += 1
                                                                                            If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                                                x += 1
                                                                                            Else
                                                                                                errorCtr += 1
                                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                                objList.SubItems.Add(linee(x))
                                                                                                objList.SubItems.Add("Only single statement is allowed")
                                                                                                k = x
                                                                                                While tokee(k) <> "newline"
                                                                                                    k += 1
                                                                                                End While
                                                                                                x = k + 1
                                                                                            End If
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Expected statement terminator")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                        End If
                                                                                    Else
                                                                                        errorCtr += 1
                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                        objList.SubItems.Add(linee(x))
                                                                                        objList.SubItems.Add("Expected reserved symbol: ']'")
                                                                                        k = x
                                                                                        While tokee(k) <> "newline"
                                                                                            k += 1
                                                                                        End While
                                                                                        x = k + 1
                                                                                    End If
                                                                                Else
                                                                                    errorCtr += 1
                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                    objList.SubItems.Add(linee(x))
                                                                                    objList.SubItems.Add("Invalid index for array")
                                                                                    k = x
                                                                                    While tokee(k) <> "newline"
                                                                                        k += 1
                                                                                    End While
                                                                                    x = k + 1
                                                                                End If
                                                                            ElseIf tokee(x) = "\" Then '@k=@a[6]\
                                                                                x += 1
                                                                                If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                                    x += 1
                                                                                Else
                                                                                    errorCtr += 1
                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                    objList.SubItems.Add(linee(x))
                                                                                    objList.SubItems.Add("Only single statement is allowed")
                                                                                    k = x
                                                                                    While tokee(k) <> "newline"
                                                                                        k += 1
                                                                                    End While
                                                                                    x = k + 1
                                                                                End If
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add("Expected statement terminator")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                                x = k + 1
                                                                            End If
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected reserved symbol: ']'")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Invalid index for array")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = "oppar" Then '@k=@a(
                                                                    x += 1
                                                                    If tokee(x) = "wholelit" Or tokee(x) = "textlit" Or tokee(x) = "fraclit" Or tokee(x) = "flaglit" Then '@k=@a(1
assfunclit:                                                             x += 1
                                                                        If tokee(x) = "clpar" Then '@k=@a(1)
assfuncclpar:                                                               x += 1
                                                                            If tokee(x) = "\" Then
                                                                                x += 1
                                                                                If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                                    x += 1
                                                                                Else
                                                                                    errorCtr += 1
                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                    objList.SubItems.Add(linee(x))
                                                                                    objList.SubItems.Add("Only single statement is allowed")
                                                                                    k = x
                                                                                    While tokee(k) <> "newline"
                                                                                        k += 1
                                                                                    End While
                                                                                    x = k + 1
                                                                                End If
                                                                            End If
                                                                        ElseIf tokee(x) = "," Then '@k=@a(1,
assfunccomma:                                                               x += 1
                                                                            If tokee(x) = "wholelit" Or tokee(x) = "textlit" Or tokee(x) = "fraclit" Or tokee(x) = "flaglit" Then '@k=@a(1,4
                                                                                GoTo assfunclit
                                                                            ElseIf tokee(x) = "id" Then '@k=@a(1,@d
                                                                                GoTo assfuncid
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add("Invalid parameter for function call")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                            End If
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected reserved symbol: ')'")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    ElseIf tokee(x) = "id" Then '@k=@a(@b
assfuncid:                                                              x += 1
                                                                        If tokee(x) = "clpar" Then '@k=@a(@b)
                                                                            GoTo assfuncclpar
                                                                        ElseIf tokee(x) = "," Then '@k=@a(@b,
                                                                            GoTo assfunccomma
                                                                        ElseIf tokee(x) = "opsquare" Then '@k=@a(@b[
                                                                            x += 1
                                                                            If tokee(x) = "id" Or tokee(x) = "wholelit" Then '@k=@a(@b[6
                                                                                x += 1
                                                                                If tokee(x) = "clsquare" Then '@k=@a(@b[6]
                                                                                    x += 1
                                                                                    If tokee(x) = "opsquare" Then '@k=@a(@b[6][
                                                                                        x += 1
                                                                                        If tokee(x) = "wholelit" Or tokee(x) = "id" Then '@k=@a(@b[6][7
                                                                                            x += 1
                                                                                            If tokee(x) = "clsquare" Then
                                                                                                x += 1
                                                                                                If tokee(x) = "clpar" Then '@k=@a(@b[6])
                                                                                                    GoTo assfuncclpar
                                                                                                ElseIf tokee(x) = "," Then
                                                                                                    GoTo assfunccomma
                                                                                                Else
                                                                                                    errorCtr += 1
                                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                                    objList.SubItems.Add(linee(x))
                                                                                                    objList.SubItems.Add("Expected reserved symbol: ')'")
                                                                                                    k = x
                                                                                                    While tokee(k) <> "newline"
                                                                                                        k += 1
                                                                                                    End While
                                                                                                    x = k + 1
                                                                                                End If
                                                                                            Else
                                                                                                errorCtr += 1
                                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                                objList.SubItems.Add(linee(x))
                                                                                                objList.SubItems.Add("Expected reserved symbol: ']'")
                                                                                                k = x
                                                                                                While tokee(k) <> "newline"
                                                                                                    k += 1
                                                                                                End While
                                                                                                x = k + 1
                                                                                            End If
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Invalid index for array")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                        End If
                                                                                    ElseIf tokee(x) = "clpar" Then '@k=@a(@b[6])
                                                                                        GoTo assfuncclpar
                                                                                    ElseIf tokee(x) = "," Then
                                                                                        GoTo assfunccomma
                                                                                    Else
                                                                                        errorCtr += 1
                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                        objList.SubItems.Add(linee(x))
                                                                                        objList.SubItems.Add("Expected reserved symbol: ')'")
                                                                                        k = x
                                                                                        While tokee(k) <> "newline"
                                                                                            k += 1
                                                                                        End While
                                                                                        x = k + 1
                                                                                    End If
                                                                                Else
                                                                                    errorCtr += 1
                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                    objList.SubItems.Add(linee(x))
                                                                                    objList.SubItems.Add("Expected reserved symbol: ']'")
                                                                                    k = x
                                                                                    While tokee(k) <> "newline"
                                                                                        k += 1
                                                                                    End While
                                                                                    x = k + 1
                                                                                End If
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add("Invalid index for array")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                                x = k + 1
                                                                            End If
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected reserved symbol: ')'")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Expected/Invalid parameter for function call")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = "!+" Then '@k=@a!+
                                                                    x += 1
                                                                    If tokee(x) = "id" Then '@k=@a!+@b
                                                                        x += 1
                                                                        If tokee(x) = "\" Then '@k=@a!+@b\
                                                                            x += 1
                                                                            If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                                x += 1
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add("Only single statement is allowed")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                                x = k + 1
                                                                            End If
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected statement terminator")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Expected identifier after '!+'")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = ".+" Then '@k=@a.+
                                                                    x += 1
                                                                    If tokee(x) = "id" Then '@k=@a.+@b
                                                                        x += 1
                                                                        If tokee(x) = "\" Then '@k=@a.+@b\
                                                                            x += 1
                                                                            If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                                x += 1
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add("Only single statement is allowed")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                                x = k + 1
                                                                            End If
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected statement terminator")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Expected identifier after '.+'")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = "\" Then '@k=@a\
                                                                    x += 1
                                                                    If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                        x += 1
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Only single statement is allowed")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Expected statement terminator")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            Else
amathid:                                                        x += 1
                                                                If tokee(x) = "mathOp" Then '@a+
amathope:                                                           x += 1
                                                                    If tokee(x) = "id" Then
                                                                        GoTo amathid
                                                                    ElseIf tokee(x) = "wholelit" Or tokee(x) = "fraclit" Then
                                                                        GoTo amathwhole
                                                                    ElseIf tokee(x) = "oppar" Then
                                                                        GoTo amathoppar
                                                                    ElseIf tokee(x) = "~" Then
                                                                        GoTo amathneg
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Expected operand after operator")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = "!+" Then '@a!+
                                                                    x += 1
                                                                    If tokee(x) = "id" Then '@a!+@b
                                                                        x += 1
                                                                        If tokee(x) = "mathOp" Then '@a!+@b *
                                                                            GoTo amathope
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected math operator after board access")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Expected identifier after '!+'")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = "opsquare" Then '@a[
                                                                    x += 1
                                                                    If tokee(x) = "id" Or tokee(x) = "wholelit" Then '@a[7
                                                                        x += 1
                                                                        If tokee(x) = "clsquare" Then '@a[7]
                                                                            x += 1
                                                                            If tokee(x) = "opsquare" Then '@a[9][
                                                                                x += 1
                                                                                If tokee(x) = "id" Or tokee(x) = "wholelit" Then '@a[9][8
                                                                                    x += 1
                                                                                    If tokee(x) = "clsquare" Then '@a[9][8]
                                                                                        x += 1
                                                                                        If tokee(x) = "mathOp" Then
                                                                                            GoTo amathope
                                                                                        Else
                                                                                            errorCtr += 1
                                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                                            objList.SubItems.Add(linee(x))
                                                                                            objList.SubItems.Add("Expected math operator after array")
                                                                                            k = x
                                                                                            While tokee(k) <> "newline"
                                                                                                k += 1
                                                                                            End While
                                                                                            x = k + 1
                                                                                        End If
                                                                                    Else
                                                                                        errorCtr += 1
                                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                                        objList.SubItems.Add(linee(x))
                                                                                        objList.SubItems.Add("Expected reserved symbol: ']'")
                                                                                        k = x
                                                                                        While tokee(k) <> "newline"
                                                                                            k += 1
                                                                                        End While
                                                                                        x = k + 1
                                                                                    End If
                                                                                Else
                                                                                    errorCtr += 1
                                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                                    objList.SubItems.Add(linee(x))
                                                                                    objList.SubItems.Add("Invalid index for array")
                                                                                    k = x
                                                                                    While tokee(k) <> "newline"
                                                                                        k += 1
                                                                                    End While
                                                                                    x = k + 1
                                                                                End If
                                                                            ElseIf tokee(x) = "mathOp" Then '@a[9]+
                                                                                GoTo amathope
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add("Expected math operator after array")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                                x = k + 1
                                                                            End If
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected reserved symbol: ']'")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Invalid index for array")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                ElseIf tokee(x) = "clpar" Then
                                                                    GoTo amathclpar
                                                                ElseIf tokee(x) = "\" Then
                                                                    x += 1
                                                                    If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                        x += 1
                                                                        parCtr = 0
                                                                        k = x
                                                                        While tokee(k) <> "assgnOp"
                                                                            If tokee(k) = "oppar" Then
                                                                                parCtr += 1
                                                                            ElseIf tokee(k) = "clpar" Then
                                                                                parCtr -= 1
                                                                            End If
                                                                            k -= 1
                                                                        End While
                                                                        If parCtr > 0 Then
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Missing ')'")
                                                                        End If
                                                                        If parCtr < 0 Then
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Missing '('")
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Only single statement is allowed")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Expected math operator after identifier")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            End If
                                                        ElseIf tokee(x) = "wholelit" Or tokee(x) = "fraclit" Then
amathwhole:                                                 x += 1
                                                            If tokee(x) = "mathOp" Then
                                                                x += 1
                                                                If tokee(x) = "id" Then
                                                                    GoTo amathid
                                                                ElseIf tokee(x) = "wholelit" Or tokee(x) = "fraclit" Then
                                                                    GoTo amathwhole
                                                                ElseIf tokee(x) = "oppar" Then
                                                                    GoTo amathoppar
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Expected operand after operator")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            ElseIf tokee(x) = "clpar" Then
amathclpar:                                                     x += 1
                                                                If tokee(x) = "clpar" Then
                                                                    GoTo amathclpar
                                                                ElseIf tokee(x) = "\" Then
                                                                    x += 1
                                                                    If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                        x += 1
                                                                        parCtr = 0
                                                                        k = x
                                                                        While tokee(k) <> "assgnOp"
                                                                            If tokee(k) = "oppar" Then
                                                                                parCtr += 1
                                                                            ElseIf tokee(k) = "clpar" Then
                                                                                parCtr -= 1
                                                                            End If
                                                                            k -= 1
                                                                        End While
                                                                        If parCtr > 0 Then
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Missing ')'")
                                                                        End If
                                                                        If parCtr < 0 Then
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Missing '('")
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Only single statement is allowed")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Expected math operator after operand")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            ElseIf tokee(x) = "\" Then
                                                                x += 1
                                                                If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                    x += 1
                                                                    parCtr = 0
                                                                    k = x
                                                                    While tokee(k) <> "assgnOp"
                                                                        If tokee(k) = "oppar" Then
                                                                            parCtr += 1
                                                                        ElseIf tokee(k) = "clpar" Then
                                                                            parCtr -= 1
                                                                        End If
                                                                        k -= 1
                                                                    End While
                                                                    If parCtr > 0 Then
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Missing ')'")
                                                                    End If
                                                                    If parCtr < 0 Then
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Missing '('")
                                                                    End If
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Only single statement is allowed")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected math operator/terminator after operand")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        ElseIf tokee(x) = "oppar" Then
amathoppar:                                                 x += 1
                                                            If tokee(x) = "id" Then
                                                                GoTo amathid
                                                            ElseIf tokee(x) = "wholelit" Or tokee(x) = "fraclit" Then
                                                                GoTo amathwhole
                                                            ElseIf tokee(x) = "oppar" Then
                                                                GoTo amathoppar
                                                            ElseIf tokee(x) = "~" Then
                                                                GoTo amathneg
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected operand after '('")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        ElseIf tokee(x) = "~" Then
amathneg:                                                   x += 1
                                                            If tokee(x) = "oppar" Then
                                                                GoTo amathoppar
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected open parenthesis after '~'")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        ElseIf tokee(x) = "textlit" Or tokee(x) = "flaglit" Then
                                                            x += 1
                                                            If tokee(x) = "\" Then
                                                                x += 1
                                                                If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                    x += 1
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Only single statement is allowed")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected statement terminator after flaglit/ textlit")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Invalid value after assigment operator")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    ElseIf tokee(x) = "assgnOp2" Then '@a*=
                                                        x += 1
                                                        If tokee(x) = "wholelit" Or tokee(x) = "fraclit" Then '@a*=3
                                                            x += 1
                                                            If tokee(x) = "\" Then '@a*=3\
                                                                x += 1
                                                                If tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                                    x += 1
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Only single statement is allowed")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected statement terminator")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Expected wholelit or fraclit after operator")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    ElseIf tokee(x) = "opsquare" Then '@a[
                                                        x += 1
                                                        If tokee(x) = "wholelit" Or tokee(x) = "id" Then '@a[4
                                                            x += 1
                                                            If tokee(x) = "clsquare" Then '@a[4]
                                                                x += 1
                                                                If tokee(x) = "assgnOp" Then
                                                                    GoTo assgnstate
                                                                ElseIf tokee(x) = "opsquare" Then '@a[4][
                                                                    x += 1
                                                                    If tokee(x) = "wholelit" Or tokee(x) = "id" Then
                                                                        x += 1
                                                                        If tokee(x) = "clsquare" Then
                                                                            x += 1
                                                                            If tokee(x) = "assgnOp" Then
                                                                                GoTo assgnstate
                                                                            Else
                                                                                errorCtr += 1
                                                                                objList = dGridError.Items.Add(errorCtr)
                                                                                objList.SubItems.Add(linee(x))
                                                                                objList.SubItems.Add("Expected assignment operator after array")
                                                                                k = x
                                                                                While tokee(k) <> "newline"
                                                                                    k += 1
                                                                                End While
                                                                                x = k + 1
                                                                            End If
                                                                        Else
                                                                            errorCtr += 1
                                                                            objList = dGridError.Items.Add(errorCtr)
                                                                            objList.SubItems.Add(linee(x))
                                                                            objList.SubItems.Add("Expected reserved symbol: ']'")
                                                                            k = x
                                                                            While tokee(k) <> "newline"
                                                                                k += 1
                                                                            End While
                                                                            x = k + 1
                                                                        End If
                                                                    Else
                                                                        errorCtr += 1
                                                                        objList = dGridError.Items.Add(errorCtr)
                                                                        objList.SubItems.Add(linee(x))
                                                                        objList.SubItems.Add("Invalid index for array")
                                                                        k = x
                                                                        While tokee(k) <> "newline"
                                                                            k += 1
                                                                        End While
                                                                        x = k + 1
                                                                    End If
                                                                Else
                                                                    errorCtr += 1
                                                                    objList = dGridError.Items.Add(errorCtr)
                                                                    objList.SubItems.Add(linee(x))
                                                                    objList.SubItems.Add("Expected assigment operator after array")
                                                                    k = x
                                                                    While tokee(k) <> "newline"
                                                                        k += 1
                                                                    End While
                                                                    x = k + 1
                                                                End If
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected reserved symbol: ']'")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Invalid index for array")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    ElseIf tokee(x) = "!+" Then '@a!+
                                                        x += 1
                                                        If tokee(x) = "id" Then '@a!+@b
                                                            x += 1
                                                            If tokee(x) = "assgnOp" Then '@a!+@b=
                                                                GoTo assgnstate
                                                            Else
                                                                errorCtr += 1
                                                                objList = dGridError.Items.Add(errorCtr)
                                                                objList.SubItems.Add(linee(x))
                                                                objList.SubItems.Add("Expected assignment operator after board access")
                                                                k = x
                                                                While tokee(k) <> "newline"
                                                                    k += 1
                                                                End While
                                                                x = k + 1
                                                            End If
                                                        Else
                                                            errorCtr += 1
                                                            objList = dGridError.Items.Add(errorCtr)
                                                            objList.SubItems.Add(linee(x))
                                                            objList.SubItems.Add("Expected identifier after '!+'")
                                                            k = x
                                                            While tokee(k) <> "newline"
                                                                k += 1
                                                            End While
                                                            x = k + 1
                                                        End If
                                                    Else
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Expected assignment operator/ open parenthesis")
                                                        k = x
                                                        While tokee(k) <> "newline"
                                                            k += 1
                                                        End While
                                                        x = k + 1
                                                    End If
                                                End If
                                                'part ng statement
                                            ElseIf tokee(x) = "newline" Or tokee(x) = "comment" Then
                                                x += 1
                                            ElseIf tokee(x) = "deport" Then
                                                x += 1
                                                GoTo majclsym
                                            ElseIf tokee(x) = "clsymbol" Then
majclsym:                                       x += 1
                                                k = x
                                                While tokee(k) = "newline" Or tokee(k) = "comment"
                                                    k += 1
                                                End While
                                                x = k
                                                If tokee(x) = "whole" Or tokee(x) = "text" Or tokee(x) = "flag" Or tokee(x) = "frac" Or tokee(x) = "vacant" Then
                                                    GoTo dtypeerror
                                                ElseIf tokee(x) = "depart" Then
                                                    k = x
                                                    Dim symCtr As Integer = 0
                                                    While tokee(k) <> "major"
                                                        If tokee(k) = "opsymbol" Then
                                                            symCtr += 1
                                                        ElseIf tokee(k) = "clsymbol" Then
                                                            symCtr -= 1
                                                        End If
                                                        k -= 1
                                                    End While
                                                    If symCtr > 0 Then
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x - 1))
                                                        objList.SubItems.Add("Missing reserved symbol: '>>'")
                                                    ElseIf symCtr < 0 Then
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Missing reserved symbol: '<<'")
                                                    End If
                                                    GoTo depdef
                                                ElseIf tokee(x) = "during" Then
                                                    GoTo rundur
                                                Else
                                                    GoTo majornoop
                                                End If
                                            ElseIf tokee(x) = "whole" Or tokee(x) = "text" Or tokee(x) = "flag" Or tokee(x) = "frac" Or tokee(x) = "vacant" Then
dtypeerror:                                     k = x + 1
                                                While tokee(k) <> "newline" And tokee(k) <> "comment"
                                                    k += 1
                                                End While
                                                If tokee(k - 1) = "clpar" Or tokee(k - 1) = "opsymbol" Then
                                                    k = x
                                                    Dim symCtr As Integer = 0
                                                    While tokee(k) <> "major"
                                                        If tokee(k) = "opsymbol" Then
                                                            symCtr += 1
                                                        ElseIf tokee(k) = "clsymbol" Then
                                                            symCtr -= 1
                                                        End If
                                                        k -= 1
                                                    End While
                                                    If symCtr > 0 Then
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x - 1))
                                                        objList.SubItems.Add("Expected reserved symbol: '>>'")
                                                    ElseIf symCtr < 0 Then
                                                        errorCtr += 1
                                                        objList = dGridError.Items.Add(errorCtr)
                                                        objList.SubItems.Add(linee(x))
                                                        objList.SubItems.Add("Expected reserved symbol: '<<'")
                                                    End If
                                                    ifFunction = True
                                                    'WAIT goto func na to/ tokee(x) parin ipa-pass
                                                    GoTo depdef
                                                    Exit While
                                                ElseIf tokee(k - 1) <> "clpar" Or tokee(k - 1) <> "opsymbol" Then
                                                    MessageBox.Show(tokee(k - 1) & "= tokee(k-1)")
                                                    errorCtr += 1
                                                    objList = dGridError.Items.Add(errorCtr)
                                                    objList.SubItems.Add(linee(x))
                                                    objList.SubItems.Add("Local declaration should be before statement/s")
                                                    k = x
                                                    While tokee(k) <> "newline"
                                                        k += 1
                                                    End While
                                                    x = k + 1
                                                End If
                                            ElseIf tokee(x) = "depart" Then
                                                k = x
                                                Dim symCtr As Integer = 0
                                                While tokee(k) <> "major"
                                                    If tokee(k) = "opsymbol" Then
                                                        symCtr += 1
                                                    ElseIf tokee(k) = "clsymbol" Then
                                                        symCtr -= 1
                                                    End If
                                                    k -= 1
                                                End While
                                                If symCtr > 0 Then
                                                    errorCtr += 1
                                                    objList = dGridError.Items.Add(errorCtr)
                                                    objList.SubItems.Add(linee(x - 1))
                                                    objList.SubItems.Add("Missing reserved symbol: '>>'")
                                                ElseIf symCtr < 0 Then
                                                    errorCtr += 1
                                                    objList = dGridError.Items.Add(errorCtr)
                                                    objList.SubItems.Add(linee(x))
                                                    objList.SubItems.Add("Missing reserved symbol: '<<'")
                                                End If
                                                errorCtr += 1
                                                objList = dGridError.Items.Add(errorCtr)
                                                objList.SubItems.Add(linee(x - 1))
                                                objList.SubItems.Add("Expected reserved symbol: '>>'")
                                                GoTo depdef
                                            Else
                                                errorCtr += 1
                                                objList = dGridError.Items.Add(errorCtr)
                                                objList.SubItems.Add(linee(x))
                                                objList.SubItems.Add("Invalid statement for major function" & tokee(x))
                                                k = x
                                                While tokee(k) <> "newline"
                                                    k += 1
                                                End While
                                                x = k + 1
                                            End If
                                        End While
                                        'end ng STATEMENT
                                    ElseIf tokee(x) = "newline" Or tokee(x) = "comment" Then
                                        k = x
                                        While tokee(k) = "newline" Or tokee(k) = "comment"
                                            k += 1
                                        End While
                                        x = k
                                        If tokee(x) = "opsymbol" Then
                                            GoTo majoropsym
                                        Else
                                            errorCtr += 1
                                            objList = dGridError.Items.Add(errorCtr)
                                            objList.SubItems.Add(linee(x))
                                            objList.SubItems.Add("Expected reserved symbol: '<<'")
                                            GoTo majornoop
                                        End If
                                    Else
                                        errorCtr += 1
                                        objList = dGridError.Items.Add(errorCtr)
                                        objList.SubItems.Add(linee(x))
                                        objList.SubItems.Add("Expected reserved symbol: '<<'")
                                        GoTo majornoop
                                    End If
                                Else
                                    errorCtr += 1
                                    objList = dGridError.Items.Add(errorCtr)
                                    objList.SubItems.Add(linee(x))
                                    objList.SubItems.Add("Expected reserved symbol: ')'")
                                    k = x
                                    While tokee(k) <> "newline"
                                        k += 1
                                    End While
                                    x = k + 1
                                End If
                            Else
                                errorCtr += 1
                                objList = dGridError.Items.Add(errorCtr)
                                objList.SubItems.Add(linee(x))
                                objList.SubItems.Add("Expected reserved symbol: '('")
                                k = x
                                While tokee(k) <> "newline"
                                    k += 1
                                End While
                                x = k + 1
                            End If
                        End If
                    End If
                    'end ng MAJOR

                    'MINORFUNC
                    'end ng MINORFUNC
depdef:             x += 1
                End While
            End If
            '-----END NG SYNTAX ANA NG BUONG PROGRAM


        End If

    End Sub

    'Public Sub translate()
    '    'MessageBox.Show(dGridLexi.Items.Count)
    '    Dim s As Integer = 0
    '    Dim t As Integer = 0
    '    Dim str As String = ""
    '    RichTextBox1.Text = ""
    '    RichTextBox1.Text = RichTextBox1.Text + "#include<iostream>" + vbNewLine
    '    RichTextBox1.Text = RichTextBox1.Text + "#include<stdio.h>" + vbNewLine
    '    RichTextBox1.Text = RichTextBox1.Text + "#include<conio.h>" + vbNewLine
    '    RichTextBox1.Text = RichTextBox1.Text + "#include<math.h>" + vbNewLine
    '    RichTextBox1.Text = RichTextBox1.Text + "#include<cstdlib>" + vbNewLine
    '    RichTextBox1.Text = RichTextBox1.Text + "#include<cstring>" + vbNewLine + vbNewLine
    '    RichTextBox1.Text = RichTextBox1.Text + "using namespace std;" + vbNewLine + vbNewLine
    '    'RichTextBox1.Text = RichTextBox1.Text + "int main()"

    '    For i As Integer = 0 To dGridLexi.Items.Count - 1
    '        tokee(i) = dGridLexi.Items.Item(i).SubItems(3).Text() 'TOKEN
    '    Next

    '    While s < dGridLexi.Items.Count
    '        If tokee(s) = "newline" Then
    '            RichTextBox1.Text = RichTextBox1.Text + vbNewLine
    '        End If

    '        If tokee(s) = "valuu" Then
    '            str = dGridLexi.Items.Item(s).SubItems(2).Text
    '            RichTextBox1.Text = RichTextBox1.Text + str + " "
    '        End If

    '        If tokee(s) = "comment" Then
    '            str = dGridLexi.Items.Item(s).SubItems(2).Text
    '            str = str.Replace("#", "//")
    '            RichTextBox1.Text = RichTextBox1.Text + str
    '        End If

    '        If tokee(s) = "id" And tokee(s + 1) <> ".+" Then
    '            str = dGridLexi.Items.Item(s).SubItems(2).Text
    '            str = str.Replace("@", "")
    '            RichTextBox1.Text = RichTextBox1.Text + str
    '        End If

    '        If tokee(s) = "board" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "struct "
    '        End If

    '        If tokee(s) = "xlear" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "clear"
    '        End If

    '        If tokee(s) = "xnore" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "ignore"
    '        End If

    '        If tokee(s) = "xfail" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "fail"
    '        End If

    '        If tokee(s) = "vr" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "break"
    '        End If

    '        If tokee(s) = "ind" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "char "
    '        End If

    '        If tokee(s) = "indi" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "getch();"
    '        End If

    '        If tokee(s) = "'\0'" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "'\0'"
    '        End If

    '        If tokee(s) = "''" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "' '"
    '        End If

    '        If tokee(s) = "'*'" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "'*'"
    '        End If

    '        If tokee(s) = "deport" Then
    '            'str = dGridLexi.Items.Item(s + 1).SubItems(2).Text
    '            'If str <> "0" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "return "
    '            'Else
    '            '   RichTextBox1.Text = RichTextBox1.Text + "getch(); return "
    '            'End If
    '        End If

    '        If tokee(s) = "during" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "while "
    '        End If

    '        If tokee(s) = "gate" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "default "
    '        End If

    '        If tokee(s) = "halt" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "break"
    '        End If

    '        If tokee(s) = "major" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "int main"
    '        End If

    '        If tokee(s) = "ztr" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "strlen"
    '        End If

    '        If tokee(s) = "zcat" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "strcat"
    '        End If

    '        If tokee(s) = "null" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "0"
    '        End If

    '        If tokee(s) = "otherwise" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "else "
    '        End If

    '        If tokee(s) = "otherwisewhen" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "else if "
    '        End If

    '        If tokee(s) = "run" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "do "
    '        End If

    '        If tokee(s) = "set" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "const "
    '        End If

    '        If tokee(s) = "terminal" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "case "
    '        End If

    '        If tokee(s) = "take" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "switch "
    '        End If

    '        If tokee(s) = "till" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "for"
    '        End If

    '        If tokee(s) = "vacant" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "void "
    '        End If

    '        If tokee(s) = "when" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "if "
    '        End If

    '        If tokee(s) = "checkin" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "cin"
    '        End If

    '        If tokee(s) = "checkout" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "cout"
    '        End If

    '        If tokee(s) = "clearfield" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "system(""cls"")"
    '        End If

    '        If tokee(s) = "assgnOp" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "="
    '        End If

    '        If tokee(s) = "\" Then
    '            RichTextBox1.Text = RichTextBox1.Text + ";"
    '        End If

    '        If tokee(s) = "opsymbol" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "{"
    '        End If

    '        If tokee(s) = "clsymbol" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "}"
    '        End If

    '        If tokee(s) = "oppar" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "("
    '        End If

    '        If tokee(s) = "clpar" Then
    '            RichTextBox1.Text = RichTextBox1.Text + ")"
    '        End If

    '        If tokee(s) = "opsquare" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "["
    '        End If

    '        If tokee(s) = "clsquare" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "]"
    '        End If

    '        If tokee(s) = "opcurly" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "{"
    '        End If

    '        If tokee(s) = "clcurly" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "}"
    '        End If

    '        If tokee(s) = "!+" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "."
    '        End If

    '        If tokee(s) = "!" Then
    '            RichTextBox1.Text = RichTextBox1.Text + " ! "
    '        End If

    '        If tokee(s) = ":<" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "<<"
    '        End If

    '        If tokee(s) = ":>" Then
    '            RichTextBox1.Text = RichTextBox1.Text + ">>"
    '        End If

    '        If tokee(s) = ":n" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "endl"
    '        End If

    '        If tokee(s) = ":t" Then
    '            RichTextBox1.Text = RichTextBox1.Text + """   """
    '        End If

    '        If tokee(s) = ";" Then
    '            RichTextBox1.Text = RichTextBox1.Text + ": "
    '        End If

    '        If tokee(s) = "," Then
    '            RichTextBox1.Text = RichTextBox1.Text + ", "
    '        End If

    '        If tokee(s) = "?" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "? "
    '        End If

    '        If tokee(s) = ".+" Then
    '            Dim id1 As String = dGridLexi.Items.Item(s - 1).SubItems(2).Text
    '            id1 = id1.Replace("@", " ")
    '            Dim id2 As String = dGridLexi.Items.Item(s + 1).SubItems(2).Text
    '            id2 = id2.Replace("@", " ")
    '            str = tokee(s - 1) + tokee(s) + tokee(s + 1)
    '            str = "strcat(" + id1 + "," + id2 + ")"
    '            RichTextBox1.Text = RichTextBox1.Text + str
    '            s += 1
    '        End If

    '        If tokee(s) = "increOp" Or tokee(s) = "decreOp" Or tokee(s) = "relOp2" Or tokee(s) = "relOp1" Or tokee(s) = "assgnOp2" _
    '            Or tokee(s) = "mathOp" Then
    '            str = dGridLexi.Items.Item(s).SubItems(2).Text
    '            RichTextBox1.Text = RichTextBox1.Text + str + " "
    '        End If

    '        If tokee(s) = "logOp" Then
    '            str = dGridLexi.Items.Item(s).SubItems(2).Text
    '            RichTextBox1.Text = RichTextBox1.Text + str + str
    '        End If

    '        If tokee(s) = "wholelit" Then
    '            str = dGridLexi.Items.Item(s).SubItems(2).Text
    '            If str.Contains("~") Then
    '                str = str.Replace("~", "-")
    '                RichTextBox1.Text = RichTextBox1.Text + " (" + str + ") "
    '            Else
    '                RichTextBox1.Text = RichTextBox1.Text + str
    '            End If
    '        End If

    '        If tokee(s) = "fraclit" Then
    '            str = dGridLexi.Items.Item(s).SubItems(2).Text
    '            If str.Contains("~") Then
    '                str = str.Replace("~", "-")
    '                RichTextBox1.Text = RichTextBox1.Text + " (" + str + ") "
    '            Else
    '                RichTextBox1.Text = RichTextBox1.Text + str + " "
    '            End If
    '        End If

    '        If tokee(s) = "flaglit" Then
    '            str = dGridLexi.Items.Item(s).SubItems(2).Text
    '            RichTextBox1.Text = RichTextBox1.Text + str + " "
    '        End If

    '        If tokee(s) = "textlit" Then
    '            str = dGridLexi.Items.Item(s).SubItems(2).Text
    '            RichTextBox1.Text = RichTextBox1.Text + str + " "
    '        End If

    '        If tokee(s) = "whole" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "int "
    '        End If

    '        If tokee(s) = "text" Then
    '            Dim strln As Integer
    '            If tokee(s + 3) = "opsquare" Then
    '                strln = dGridLexi.Items.Item(s + 8).SubItems(2).Text.Length
    '                If strln > 3 Then
    '                    RichTextBox1.Text = RichTextBox1.Text + "string "
    '                Else
    '                    RichTextBox1.Text = RichTextBox1.Text + "char "
    '                End If
    '            Else
    '                RichTextBox1.Text = RichTextBox1.Text + "string "
    '            End If
    '        End If

    '        If tokee(s) = "frac" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "float "
    '        End If

    '        If tokee(s) = "flag" Then
    '            RichTextBox1.Text = RichTextBox1.Text + "bool "
    '        End If
    '        s += 1
    '    End While
    'End Sub

    'Public Sub output()
    '    If Not My.Computer.FileSystem.DirectoryExists("C:\Users\sarah\Documents") Then
    '        My.Computer.FileSystem.CreateDirectory("C:\Users\sarah\Documents")
    '    End If
    '    '<><>CHECK FOR OLD FILES<><>
    '    If My.Computer.FileSystem.FileExists("C:\Users\sarah\Documents\compiler.cpp") Then
    '        My.Computer.FileSystem.DeleteFile("C:\Users\sarah\Documents\compiler.cpp")
    '    End If
    '    If My.Computer.FileSystem.FileExists("C:\Users\sarah\Documents\compiler.exe") Then
    '        My.Computer.FileSystem.DeleteFile("C:\Users\sarah\Documents\compiler.exe")
    '    End If
    '    '<><>WRITING<><>
    '    Using sw As New System.IO.StreamWriter("C:\Users\sarah\Documents\compiler.cpp")
    '        sw.WriteLine(RichTextBox1.Text)
    '        sw.Close()
    '    End Using
    '    '<><>COMPILING<><>
    '    Dim CPath As String = "C:\MinGW\bin"
    '    Process.Start("cmd", "/c g++ C:\Users\sarah\Documents\compiler.cpp -o C:\Users\sarah\Documents\compiler.exe").WaitForExit()
    '    If Not My.Computer.FileSystem.FileExists("C:\Users\sarah\Documents\compiler.exe") Then
    '        MsgBox("Unsuccessful Build. Please check your code.")
    '    Else
    '        Process.Start("C:\Users\sarah\Documents\compiler").WaitForExit()
    '    End If
    'End Sub

    'Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
    '    Clipboard.SetDataObject(rTBCode.SelectedText)
    '    Dim S As String = rTBCode.Text
    '    Dim SelStart As Integer = rTBCode.SelectionStart
    '    Dim SelLen As Integer = rTBCode.SelectionLength

    '    S = S.Remove(SelStart, SelLen)

    '    rTBCode.Text = S

    '    rTBCode.Focus()
    'End Sub

    'Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
    '    Clipboard.SetDataObject(rTBCode.SelectedText)
    '    rTBCode.Focus()
    'End Sub

    'Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
    '    Dim oDataObject As IDataObject
    '    oDataObject = Clipboard.GetDataObject()
    '    If oDataObject.GetDataPresent(DataFormats.Text) Then
    '        rTBCode.SelectedText = CType(oDataObject.GetData(DataFormats.Text), String)
    '    End If
    '    rTBCode.Focus()
    'End Sub

    Public Sub RowCol()

        Dim index As Integer
        Dim line As Integer
        Dim col As Integer
        Dim pt As Point

        ' get the current line 
        index = Me.rTBCode.SelectionStart
        line = Me.rTBCode.GetLineFromCharIndex(index) + 1
        ' get the caret position in pixel coordinates 
        pt = Me.rTBCode.GetPositionFromCharIndex(index)
        ' now get the character index at the start of the line, and subtract from the current index to get the column 
        pt.X = 0
        col = index - Me.rTBCode.GetCharIndexFromPosition(pt) + 1

        ' finally, update the display in the status bar, incrementing the line and column values so that the first line & first character position is shown as "1, 1" 
        'Me.ToolStripStatusLabel1.Text = "Ln " + (++line).ToString() + ", Col " + (++col).ToString()

    End Sub

    Private Sub rTBCode_SelectionChanged(sender As Object, e As EventArgs) Handles rTBCode.SelectionChanged
        RowCol()
    End Sub

    Public Function inArray(ByVal input As String, ByVal array() As String, ByVal lim As Integer)
        Dim bool As Boolean = True
        For x As Integer = 0 To lim
            If input = array(x) Then
                bool = True
                Exit For
            Else
                bool = False
            End If
        Next
        Return bool
    End Function

    Private Sub DrawRichTextBoxLineNumbers(ByRef g As Graphics)
        'Calculate font heigth as the difference in Y coordinate 
        'between line 2 and line 1
        'Note that the RichTextBox text must have at least two lines. 
        '  So the initial Text property of the RichTextBox 
        '  should not be an empty string. It could be something 
        '  like vbcrlf & vbcrlf & vbcrlf 
        With rTBCode
            Dim font_height As Single
            font_height = .GetPositionFromCharIndex(.GetFirstCharIndexFromLine(2)).Y _
                  - .GetPositionFromCharIndex(.GetFirstCharIndexFromLine(1)).Y
            If font_height = 0 Then Exit Sub

            'Get the first line index and location
            Dim first_index As Integer
            Dim first_line As Integer
            Dim first_line_y As Integer
            first_index = .GetCharIndexFromPosition(New _
                  Point(0, g.VisibleClipBounds.Y + font_height / 3))
            first_line = .GetLineFromCharIndex(first_index)
            first_line_y = .GetPositionFromCharIndex(first_index).Y

            'Print on the PictureBox the visible line numbers of the RichTextBox
            'g.Clear(Control.DefaultBackColor)
            Dim i As Integer = first_line
            Dim y As Single
            Do While y < g.VisibleClipBounds.Y + g.VisibleClipBounds.Height
                y = first_line_y + 2 + font_height * (i - first_line - 1)
                g.DrawString((i).ToString, .Font, Brushes.White, lineNum.Width _
                      - g.MeasureString((i).ToString, .Font).Width, y)
                i += 1
            Loop
            'Debug.WriteLine("Finished: " & firstLine + 1 & " " & i - 1)
        End With
    End Sub

    Private Sub r_Resize(ByVal sender As Object, ByVal e As System.EventArgs) _
     Handles rTBCode.Resize
        lineNum.Invalidate()
    End Sub

    Private Sub r_VScroll(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles rTBCode.VScroll
        lineNum.Invalidate()
    End Sub

    Private Sub p_Paint(ByVal sender As Object,
            ByVal e As System.Windows.Forms.PaintEventArgs) _
            Handles lineNum.Paint
        DrawRichTextBoxLineNumbers(e.Graphics)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles MyBase.Load
        rTBCode.Text = vbCrLf & vbCrLf & vbCrLf
    End Sub

    'Private Sub open_but_Click(sender As Object, e As EventArgs) Handles open_but.Click
    '    OpenFileDialog1.Filter = "(*.txt) | *.txt"
    '    If (OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
    '        rTBCode.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
    '    End If

    'End Sub

    'Private Sub save_but_Click(sender As Object, e As EventArgs) Handles save_but.Click
    '    SaveFileDialog1.Title = "Save File As..."
    '    SaveFileDialog1.Filter = "(*.txt) | *.txt"
    '    If (SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
    '        rTBCode.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.PlainText)
    '    End If
    'End Sub

    'Private Sub close_but_Click(sender As Object, e As EventArgs) Handles close_but.Click
    '    Me.Close()
    'End Sub

    'Private Sub min_but_Click(sender As Object, e As EventArgs) Handles min_but.Click
    '    Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
    'End Sub

    'Private Sub new_but_Click(sender As Object, e As EventArgs) Handles new_but.Click
    '    rTBCode.Clear()
    '    dGridLexi.Items.Clear()
    '    dGridError.Items.Clear()
    '    dGridIden.Items.Clear()
    '    semant_table.Items.Clear()
    '    dGridBoard.Items.Clear()
    'End Sub

    Private Sub lineNum_Click(sender As Object, e As EventArgs) Handles lineNum.Click

    End Sub

    Private Sub rTBCode_TextChanged(sender As Object, e As EventArgs) Handles rTBCode.TextChanged

    End Sub
End Class
