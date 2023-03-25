Imports System.Threading
Imports System.Timers

Public Class Form1
    Private randomizer As New Random
    Private addend1 As Integer
    Private addend2 As Integer
    Private minuend As Integer
    Private subtrahend As Integer
    Private multiplicand As Integer
    Private multiplier As Integer
    Private dividend As Integer
    Private divisor As Integer
    Private timeLeft As Integer
    Public Function CheckTheAnswer() As Boolean

        If addend1 + addend2 = sum.Value AndAlso
       minuend - subtrahend = difference.Value AndAlso
       multiplicand * multiplier = product.Value AndAlso
       dividend / divisor = quotient.Value Then

            Return True
        Else
            Return False
        End If

    End Function
    Private Sub Timer1_Tick() Handles Timer1.Tick

        If CheckTheAnswer() Then
            ' If CheckTheAnswer() returns true, then the user 
            ' got the answer right. Stop the timer  
            ' and show a MessageBox.
            Timer1.Stop()
            MessageBox.Show("你把所有的题目都答对了！", "提示")
            startButton.Enabled = True
        ElseIf timeLeft > 0 Then
            ' If CheckTheAnswer() returns false, keep counting
            ' down. Decrease the time left by one second and 
            ' display the new time left by updating the 
            ' Time Left label.
            timeLeft -= 1
            timeLabel.Text = timeLeft & " seconds"
        Else
            ' If the user ran out of time, stop the timer, show
            ' a MessageBox, and fill in the answers.
            Timer1.Stop()
            timeLabel.Text = "时间到！"
            MessageBox.Show("对不起，你没有在时间段内完成", "提示")
            sum.Value = addend1 + addend2
            difference.Value = minuend - subtrahend
            product.Value = multiplicand * multiplier
            quotient.Value = dividend / divisor
            startButton.Enabled = True
        End If

    End Sub
    Public Sub StartTheQuiz()
        addend1 = randomizer.Next(51)
        addend2 = randomizer.Next(51)
        plusLeftLabel.Text = addend1.ToString()
        plusRightLabel.Text = addend2.ToString()
        sum.Value = 0
        ' Fill in the subtraction problem.
        minuend = randomizer.Next(1, 101)
        subtrahend = randomizer.Next(1, minuend)
        minusLeftLabel.Text = minuend.ToString()
        minusRightLabel.Text = subtrahend.ToString()
        difference.Value = 0
        ' Fill in the multiplication problem.
        multiplicand = randomizer.Next(2, 11)
        multiplier = randomizer.Next(2, 11)
        timesLeftLabel.Text = multiplicand.ToString()
        timesRightLabel.Text = multiplier.ToString()
        product.Value = 0
        ' Fill in the division problem.
        divisor = randomizer.Next(2, 11)
        Dim temporaryQuotient As Integer = randomizer.Next(2, 11)
        dividend = divisor * temporaryQuotient
        dividedLeftLabel.Text = dividend.ToString()
        dividedRightLabel.Text = divisor.ToString()
        quotient.Value = 0
        timeLeft = 30
        timeLabel.Text = "30 seconds"
        Timer1.Start()
    End Sub
    Private Sub startButton_Click() Handles startButton.Click
        StartTheQuiz()
        startButton.Enabled = False
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles timeLabel.Click

    End Sub

    Private Sub fontLabel_Click(sender As Object, e As EventArgs) Handles textLabel.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles minusRightLabel.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles timesLeftLabel.Click

    End Sub

    Private Sub answer_Enter(sender As Object, e As EventArgs) Handles sum.Enter, quotient.Enter, product.Enter, difference.Enter
        Dim answerBox = TryCast(sender, NumericUpDown)

        If answerBox IsNot Nothing Then
            Dim lengthOfAnswer = answerBox.Value.ToString().Length
            answerBox.Select(0, lengthOfAnswer)
        End If
    End Sub
End Class
