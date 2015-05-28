
# 樂透模擬程式 

此程式模擬台灣樂透開獎，<br>

當使用者按下想要開獎的項目，系統會進行搖獎<br>
<br>


以下舉例：當使用者想要搖539的獎號<br><br>

code:<br><br>

private void 539lottery_Click(object sender, EventArgs e)<br>
{
<br>
CreateLotteryNumber(49, 5);<br>

//49為總共幾個號碼﹐5為開出幾個號碼被帶入參數<br>

}<br>

private void CreateLotteryNumber(int n,int a)<br>
{

lottery = new int[n-1]; //共39個號碼<br>
for (int i = 0; i <= lottery.GetUpperBound(0); i++)<br>
{<br>
lottery[i] = i + 1;<br>
}<br>

number = new int[a]; //產生陣列,放入開獎的五個號碼<br>
Random r = new Random();<br>
for (int k = 0; k <= number.GetUpperBound(0); k++) //產生五個號碼<br>
{<br>

int t = r.Next(1, n-1);<br>
if (lottery[t] == 0)<br>
{<br>

k--; //如果是0表示已經用過 故重新產生.<br>
}<br>
else<br>
{<br>

number[k] = lottery[t];<br>
lottery[t] = 0;//開出的號碼設為0,以便偵測是否為重複號碼<br>
}<br>
}<br>

}<br>

<br>
    yucheng
