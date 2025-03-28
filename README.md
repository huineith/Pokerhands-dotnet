# Pokerhands
<https://github.com/huineith/Pokerhands-dotnet>

## Test are contained in PokerTest.cs 

All test are written so they can check multiple cases with one test.
This is to make it easier to checkmultiple cases without having to rewrite code. 



### Test are
- <ins> ***TestCheckHighestHandHandlesWinAndTieCorrectly***:</ins>  
    
    test method to determine winner, from two hands. 
    test cases: 
    - highest card player 1,player 2 winning and tie 
    - winning on a pair both sides winning and tie, 
    - pair vs 2 pairs 
    - Royal flush vs Four of a Kind 
    - Flush + higher Card vs Flush 
    
- <ins>***TestHighestHandHandlesWinAndTieCorrectly***</ins>
   
   test method for helper functions that determine winner of highest card. 
   
    test cases: 
    - player 1 wins , player 2 wins, tie. 

- <ins>***TestIsPairHelperMethod***</ins>

    test method for helper function that check if a hand contains pair, 
    
    test cases: 
    - hands with one pair
    - hand with two pairs 
     - hand w\o pair


- <ins>***testIsTwoPairsTrueAndFalseCases***</ins>

    test method for helper function that check if a hand contains two pair, 
    
    test cases: 
    - hand with two pairs 
    - hands with one pair
     - hand w\o pair

- <ins>***testIsThreeofAKindTrueAndFalseCases***</ins>

    test method for helper function that check if a hand contains Three of a kind, 
    
    test cases: 
    - hand with Three of a kind 
    - hand w\o Three of a kind


- <ins>***testIsStraightTrueAndFalseCases***</ins>

    test method for helper function that check if a hand is a straight , 
    
    test cases: 
    - hands with straight 
    - hands w\o straight


- <ins>***testIsFlushTrueAndFalseCases***</ins>
 
    test method for helper function that check if a hand is a flush , 
    
    test cases: 
    - hands with flush 
    - hands w\o flush

- <ins>***testIsFullHouseTrueAndFalseCases***</ins>

    test method for helper function that check if a hand is a FullHouse , 
    
    test cases: 
    - hands with FullHouse 
    - hands w\o FullHouse


- <ins>***testIsFourOfAKindTrueAndFalseCases***</ins>

    test method for helper function that check if a hand contains Four of a kind , 
    
    test cases: 
    - hands with Four of a kind 
    - hands w\o Four of a kind




- <ins>***testIsStraightFlushTrueAndFalseCases***</ins>

    test method for helper function that check if a hand is a straight flush , 
    
    test cases: 
    - hands with a straight flush 
    - hands w\o a straight flush



- <ins>***testIsStraightFlushTrueAndFalseCases***</ins>

    test method for helper function that check if a hand is a straight flush , 
    
    test cases: 
    - hands with a straight flush 
    - hands w\o a straight flush




- <ins>***testIsRoyalFlushTrueAndFalseCases***</ins>

    test method for helper function that check if a hand is a straight royal flush , 
    
    test cases: 
    - hands with a straight royal flush 
    - hand with a non royal straight flush
    - hands w\o a straight flush




- <ins>***testIsRoyalStraightFlushTrueAndFalseCases***</ins>

    test method for helper function that check if a hand is a straight royal flush , 
    
    test cases: 
    - hands with a straight royal flush 
    - hand with a non royal straight flush
    - hands w\o a straight flush

n.b. the last two methods performs the same task but there are two separeat methods in the code Only the first is relevant for the actual code but we since it is present we choose to test it aswell.  





