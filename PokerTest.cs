using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using Xunit;
namespace CardGame;

/*
    }
[Theory]
    [InlineData(2)]
    [InlineData(4)]
    [InlineData(8)]
    public void MyEvenTheory(int number){
*/
//     "♥♦♣♠"
        
//"23456789TJQKA"
public class PokerTest{


    //-----"main" comparer method------// 
[Theory]
//cases to test highest card p1,p2 winning  and tie. 
    [InlineData(1,new string[]{ "♥3","♦2","♥4","♦5","♦6"}, new string[]{"♠2","♠3","♠4","♠5","♠7"} )] 
    [InlineData(0, new string[]{"♠2","♠3","♠4","♠5","♠7"},new string[]{ "♥3","♦2","♥4","♦5","♦6"} )]
    [InlineData(2, new string[]{"♠2","♦3","♠4","♠5","♠7"},new string[]{ "♥3","♦2","♥4","♦5","♦7"} )]
// winning on a pair both sides and tie, 
  [InlineData(0,new string[]{ "♥2","♦2","♥4","♦5","♦6"}, new string[]{"♠2","♠3","♠4","♠5","♠7"} )] 
  [InlineData(1, new string[]{"♠2","♠3","♠4","♠5","♠7"},new string[]{ "♥3","♦3","♥4","♦5","♦6"} )]
  [InlineData(2, new string[]{"♠3","♣3","♠4","♠5","♠7"},new string[]{ "♥3","♦3","♥4","♦5","♦7"} )] 
public void TestCheckHighestHandHandlesWinAndTieCorrectly(int winningHandId,  string[] cardInfoHandOne,string[] cardInfoHandTwo   ){
      Hand handOne= GenerateHandOfCards(cardInfoHandOne);
        Hand handTwo= GenerateHandOfCards(cardInfoHandTwo);
        Hand[] PlayerHands = new Hand[]{handOne,handTwo}; 
        Hand? winningHand;

        if(winningHandId<2 && winningHandId>-1 ){
            winningHand= PlayerHands[winningHandId]; 
        }else{
            winningHand=null;
        }


       var result= CompareHands.CheckHands(handOne,handTwo); 
       bool correctResult=result.winningHand==winningHand;   
        //Assert
        Assert.True(correctResult); 
    }




[Theory]
    [InlineData(1,new string[]{ "♥3","♦2","♥4","♦5","♦6"}, new string[]{"♠2","♠3","♠4","♠5","♠7"} )]
    [InlineData(0,new string[]{ "♥3","♦2","♥4","♦5","♦T"}, new string[]{"♠2","♠3","♠4","♠5","♠7"} )]
    [InlineData(1,new string[]{ "♥3","♦2","♥4","♦5","♦K"}, new string[]{"♠2","♠3","♠4","♠5","♠A"} )]
    [InlineData(-1,new string[]{ "♥3","♦2","♥4","♦5","♦K"}, new string[]{"♠2","♠3","♠4","♠5","♠K"} )]
    [InlineData(3,new string[]{ "♥3","♦2","♥4","♦5","♦9"}, new string[]{"♠2","♠3","♠4","♠5","♠9"} )]
    public void TestHighestHandHandlesWinAndTieCorrectly(int winningHandId,  string[] cardInfoHandOne,string[] cardInfoHandTwo   ){
        //     "♥♦♣♠"
        // Arrange 

        // Act 
        
        Hand handOne= GenerateHandOfCards(cardInfoHandOne);
        Hand handTwo= GenerateHandOfCards(cardInfoHandTwo);
        Hand[] PlayerHands = new Hand[]{handOne,handTwo}; 
        Hand? winningHand;

        if(winningHandId<2 && winningHandId>-1 ){
            winningHand= PlayerHands[winningHandId]; 
        }else{
            winningHand=null;
        }

       var result= CompareHands.CompareHighestCard(handOne,handTwo); 
       bool correctResult=result==winningHand;   
        //Assert
        Assert.True(correctResult); 
    }
    //--------------------- helper methods---------------------------------// 

[Theory]
    [InlineData(1,new string[]{"♥2","♦2","♥4","♦5","♦6"})] 
    [InlineData(1,new string[]{"♥8","♦8","♥4","♦5","♦6"})]
    [InlineData(1,new string[]{"♥2","♦2","♥T","♦T","♦6"})]  

    public void TestIsPairHelperMethodTrue(int fakeParameter,string[] cardsInfo){
        //need fake parameter to be able to pass a list    
        // Arrange 

        // Act 
        //var ranks = new char[]{'2','2','4','5','6'}; 
        //var suits=new char[]{'♥','♦','♥','♦','♦'}; 
        
        int i =fakeParameter; 
   
       Hand pairHand=  GenerateHandOfCards(cardsInfo); 
       var result= CompareHands.IsPair(pairHand);
       bool ContainsPair= result==pairHand ;  
        //Assert
        Assert.True(ContainsPair); 
    }

[Theory]
    [InlineData(1,new string[]{"♥3","♦2","♥4","♦5","♦6"})] 
    [InlineData(1,new string[]{"♥3","♦8","♥4","♦5","♦6"})]
    [InlineData(1,new string[]{"♥3","♦2","♥9","♦T","♦6"})]  
    public void TestIsPairHelperMethodFalse(int fakeParameter,string[] cardsInfo){
        //need fake parameter to be able to pass a list    
        // Arrange 

        // Act 
        //var ranks = new char[]{'2','2','4','5','6'}; 
        //var suits=new char[]{'♥','♦','♥','♦','♦'}; 
        
        int i =fakeParameter; 
   
       Hand pairHand=  GenerateHandOfCards(cardsInfo); 
       var result= CompareHands.IsPair(pairHand);
       bool ContainPair= result==pairHand ;  
        //Assert
        Assert.False(ContainPair); 
    }





[Theory]
    [InlineData(true,new string[]{ "♥2","♦2","♥5","♦5","♦6"})]
    [InlineData(false,new string[]{ "♥2","♦3","♥5","♦5","♦6"})]
    [InlineData(true,new string[]{ "♥6","♦4","♥4","♦5","♦6"})]
    [InlineData(true,new string[]{ "♥7","♥6","♥4","♦7","♦6"})]
    [InlineData(false,new string[]{ "♥2","♥8","♥4","♦5","♦6"})]
public void testIsTwoPairsTrueAndFalseCases(bool isTwoPairs,string[] cardsInfo){
        // Arrange 
        // Act 
       Hand pairHand=  GenerateHandOfCards(cardsInfo); 
       var result= CompareHands.IsTwoPair(pairHand);
       bool containsTwoPairs= result==pairHand; 
       bool correctResult = containsTwoPairs == isTwoPairs;   
        //Assert
        Assert.True(correctResult); 

}

//     "♥♦♣♠"
[Theory] 
 [InlineData(true,new string[]{ "♥5","♦2","♣5","♦5","♦6"})]
 [InlineData(true,new string[]{ "♥2","♦2","♣6","♦6","♠6"})]
 [InlineData(true,new string[]{ "♥2","♠T","♣T","♦T","♦6"})]
 [InlineData(false,new string[]{ "♥T","♦J","♣K","♦D","♦6"})]
public void testIsThreeofAKindTrueAndFalseCases(bool expectedResult,string[] cardsInfo){
        // Arrange 
        // Act 
       Hand PlayerHand=  GenerateHandOfCards(cardsInfo); 
       var result= CompareHands.IsThreeOfAKind(PlayerHand);
       bool containsThreeOfAKind= result==PlayerHand; 
       bool correctResult = containsThreeOfAKind ==  expectedResult;   
        //Assert
        Assert.True(correctResult); 

}

[Theory] 
 [InlineData(true,new string[]{ "♠3", "♦4", "♣5" ,"♥6" ,"♠7"})]
 [InlineData(true,new string[]{"♣8", "♦9", "♥T", "♠J", "♣Q"})]
 [InlineData(true,new string[]{ "♠5", "♦6", "♣7", "♥8", "♠9"})]
 [InlineData(false,new string[]{ "♦2", "♠7", "♣3", "♥K", "♦J"})]
 [InlineData(false,new string[]{ "♠4", "♣10", "♦9", "♥7", "♠Q"})]
 [InlineData(false,new string[]{ "♥5", "♠3", "♦K", "♣8", "♦J"})]
public void testIsStraightTrueAndFalseCases( bool expectedResult,string[] cardsInfo){
        // Arrange 
        // Act 
       Hand PlayerHand=  GenerateHandOfCards(cardsInfo); 
       var result= CompareHands.IsStraight(PlayerHand);
       bool containsStraight= result==PlayerHand; 
       bool correctResult = containsStraight ==  expectedResult;   
        //Assert
        Assert.True(correctResult); 

}


[Theory] 
 [InlineData(true,new string[]{ "♠3", "♠7", "♠5", "♠K", "♠T"})]
 [InlineData(true,new string[]{"♦2", "♦4", "♦9", "♦J", "♦Q"})]
 [InlineData(true,new string[]{ "♥6", "♥T", "♥3", "♥8", "♥7"})]
 [InlineData(false,new string[]{ "♦2", "♠7", "♣3", "♥K", "♦J"})]
 [InlineData(false,new string[]{ "♠4", "♣10", "♦9", "♥7", "♠Q"})]
 [InlineData(false,new string[]{ "♥5", "♠3", "♦K", "♣8", "♦J"})]
public void testIsFlushTrueAndFalseCases( bool expectedResult,string[] cardsInfo){
        // Arrange 
        // Act 
       Hand PlayerHand=  GenerateHandOfCards(cardsInfo); 
       var result= CompareHands.IsFlush(PlayerHand);
       bool containsFlush= result==PlayerHand; 
       bool correctResult = containsFlush ==  expectedResult;   
        //Assert
        Assert.True(correctResult); 

}


[Theory] 
 [InlineData(true,new string[]{ "♠9", "♠9", "♣9", "♦K", "♦K"})]
 [InlineData(true,new string[]{"♥T", "♥T", "♠T", "♦Q", "♣Q"})]
 [InlineData(true,new string[]{ "♦3", "♦3", "♠3", "♥J", "♣J"})]
 [InlineData(false,new string[]{ "♦2", "♠7", "♣3", "♥K", "♦J"})]
 [InlineData(false,new string[]{ "♠4", "♣10", "♦9", "♥7", "♠Q"})]
 [InlineData(false,new string[]{ "♥5", "♠3", "♦K", "♣8", "♦J"})]
public void testIsFullHouseTrueAndFalseCases( bool expectedResult,string[] cardsInfo){
        // Arrange 
        // Act 
       Hand PlayerHand=  GenerateHandOfCards(cardsInfo); 
       var result= CompareHands.IsFullHouse(PlayerHand);
       bool containsFullHouse= result==PlayerHand; 
       bool correctResult = containsFullHouse ==  expectedResult;   
        //Assert
        Assert.True(correctResult); 

}

[Theory] 
 [InlineData(true,new string[]{"♠9", "♦9", "♣9", "♥9", "♠K"})]
 [InlineData(true,new string[]{"♠T", "♣T", "♦T", "♥T", "♠J"})]
 [InlineData(true,new string[]{ "♦3", "♠3", "♣3", "♥3", "♦Q"})]
 [InlineData(false,new string[]{ "♦2", "♠7", "♣3", "♥K", "♦J"})]
 [InlineData(false,new string[]{ "♠4", "♣10", "♦9", "♥7", "♠Q"})]
 [InlineData(false,new string[]{ "♥5", "♠3", "♦K", "♣8", "♦J"})]
public void testIsForOfAKindTrueAndFalseCases( bool expectedResult,string[] cardsInfo){
        // Arrange 
        // Act 
       Hand PlayerHand=  GenerateHandOfCards(cardsInfo); 
       var result= CompareHands.IsFourOfAKind(PlayerHand);
       bool containsFourOfAKind= result==PlayerHand; 
       bool correctResult = containsFourOfAKind ==  expectedResult;   
        //Assert
        Assert.True(correctResult); 

}



[Theory] 
 [InlineData(true,new string[]{ "♠3", "♠4", "♠5", "♠6", "♠7"})]
 [InlineData(true,new string[]{"♦9", "♦T", "♦J", "♦Q", "♦K"})]
 [InlineData(true,new string[]{ "♣6", "♣7", "♣8", "♣9", "♣T"})]
 [InlineData(false,new string[]{ "♦2", "♠7", "♣3", "♥K", "♦J"})]
 [InlineData(false,new string[]{ "♠4", "♣10", "♦9", "♥7", "♠Q"})]
 [InlineData(false,new string[]{ "♥5", "♠3", "♦K", "♣8", "♦J"})]
public void testIsStraightFlushTrueAndFalseCases( bool expectedResult,string[] cardsInfo){
        // Arrange 
        // Act 
       Hand PlayerHand=  GenerateHandOfCards(cardsInfo); 
       var result= CompareHands.IsStraightFlush(PlayerHand);
       bool containsStraightFlush= result==PlayerHand; 
       bool correctResult = containsStraightFlush ==  expectedResult;   
        //Assert
        Assert.True(correctResult); 

}



[Theory] 
 [InlineData(true,new string[]{ "♠A", "♠K", "♠Q", "♠J", "♠T"})]
 [InlineData(true,new string[]{"♦A", "♦K", "♦Q", "♦J", "♦T"})]
 [InlineData(true,new string[]{ "♥A", "♥K", "♥Q", "♥J", "♥T"})]
 [InlineData(false,new string[]{ "♦2", "♠7", "♣3", "♥K", "♦J"})]
 [InlineData(false,new string[]{ "♠4", "♣10", "♦9", "♥7", "♠Q"})]
 [InlineData(false,new string[]{ "♥5", "♠3", "♦K", "♣8", "♦J"})]
public void testIsRoyalFlushTrueAndFalseCases( bool expectedResult,string[] cardsInfo){
        // Arrange 
        // Act 
       Hand PlayerHand=  GenerateHandOfCards(cardsInfo); 
       var result= CompareHands.IsRoyalFlush(PlayerHand);
       bool containsRoyalFlush= result==PlayerHand; 
       bool correctResult = containsRoyalFlush ==  expectedResult;   
        //Assert
        Assert.True(correctResult); 

}

//----------------------- These methods do the samething ????????????????? -------------------//

[Theory] 
 [InlineData(true,new string[]{ "♠A", "♠K", "♠Q", "♠J", "♠T"})]
 [InlineData(true,new string[]{"♦A", "♦K", "♦Q", "♦J", "♦T"})]
 [InlineData(true,new string[]{ "♥A", "♥K", "♥Q", "♥J", "♥T"})]
 [InlineData(false,new string[]{ "♦2", "♠7", "♣3", "♥K", "♦J"})]
 [InlineData(false,new string[]{ "♠4", "♣10", "♦9", "♥7", "♠Q"})]
 [InlineData(false,new string[]{ "♥5", "♠3", "♦K", "♣8", "♦J"})]
public void testIsRoyalStraightFlushTrueAndFalseCases( bool expectedResult,string[] cardsInfo){
        // Arrange 
        // Act 
       Hand PlayerHand=  GenerateHandOfCards(cardsInfo); 
       var result= CompareHands.IsRoyalStraightFlush(PlayerHand);
       bool containsRoyalStraightFlush= result==PlayerHand; 
       bool correctResult = containsRoyalStraightFlush ==  expectedResult;   
        //Assert
        Assert.True(correctResult); 

}


  Hand GenerateHandOfCards(string[] cardsInfo){
   List<Card> cards= new(); 

    foreach( string card in cardsInfo ){ 
        cards.Add(new Card(card[0],card[1])); 
    }

    return new Hand(cards) ; 
}
}