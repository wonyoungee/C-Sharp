using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex08_List_Board_Comments
{
    /*
     *  App     -------      DataBase
     *              CRUD
     *  1. select
     *  2. insert
     *  3. update
     *  4. delete
     *  
     *  create table Board(boadid int ...);
     *  create table comments(commentid int ...);
     *  
     *  App : select boardid, title, content    from board;
     *  객체지향언어
     *  객체 맵핑
     *  
     *  class Board{
     *      private int boardid;
     *      ......
     *  }
     *  
     *  class Comments{
     *      private int commentid;
     *  }
     *  
     *  1. CASE_1
     *      select boardid, title   from board      where boardid = 2;
     *      
     *      Board borad = new Board();
     *      board.Boardid = 데이터;
     *      
     *  2. CASE_2
     *      select boardid, title   from board      // 데이터 건수 150건
     *      List<Board> boardlist = new ...
     *      boardlist.add(new Board());
     *      ... ... ....
     *      boardlist 안에 Board객체 150개
     */

    class Board
    {
        // ... title, contents ,,,
        private List<Comment> comments;     // Board는 여러개의 comments를 가질 수 있음.

        public void addComment (Comment comment)
        {
            comments.Add(comment);  // 댓글 write
        }
    }
    class Comment
    {
        // .. content ...
        private Board board;    // Comment는 하나의 Board만 가질 수 있음.

        public void setBoard(Board board) { 
            this.board = board;
            board.addComment(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.addComment (new Comment());
            board.addComment(new Comment());
            board.addComment(new Comment());
        }
    }
}
