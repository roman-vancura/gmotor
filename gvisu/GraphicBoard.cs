﻿/*
 * Created by SharpDevelop.
 * User: Vančurovi
 * Date: 18.10.2014
 * Time: 22:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace gvisu
{
	/// <summary>
	/// Description of GraphicBoard.
	/// </summary>
	public partial class GraphicBoard : UserControl
	{
		Bitmap stones;
		int boardSize;
		GomokuEngine.Conversions conversions;
		
		public GraphicBoard()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void GraphicBoardLoad(object sender, EventArgs e)
		{
			string str1 = @"./skins/wood.bmp";
			
			stones = new Bitmap(str1);
		}
		
		void GraphicBoardPaint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			
			//draw row legend
			Font font = new System.Drawing.Font("Arial", 16);
    		SolidBrush brush = new SolidBrush(System.Drawing.Color.Black);
    		
			for (int row = 0; row < boardSize; row++)
			{
				g.DrawString(conversions.Row(row), font, brush,row*10,10);
			}

			//draw column legend
			for (int column = 0; column < boardSize; column++)
			{
				g.DrawString(conversions.Column(column), font, brush,10,column*10);
			}

			//draw board
//			for (int column = 0; column < engine.BoardSize; column++)
//			{
//				for (int row = 0; row < engine.BoardSize; row++)
//				{
//					picSquare = new System.Windows.Forms.PictureBox();
//					picSquare.Image = BoardImageList.Images[0];
//					picSquare.Name = "picSquare" + conversions.Complete(row , column);
//					picSquare.Size = BoardImageList.ImageSize;
//					picSquare.Top = panelBoard.Height - BoardImageList.ImageSize.Height - (row + 1) * picSquare.Size.Height;
//					picSquare.Left = BoardImageList.ImageSize.Width + column * picSquare.Size.Height;
//					picSquare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
//					picSquare.TabStop = false;
//                    picSquare.Tag = conversions.Complete(row, column); 
//                    picSquare.MouseClick +=new MouseEventHandler(picSquare_MouseClick);
//					panelBoard.Controls.Add(picSquare);
//					picSquares[row, column] = picSquare;
//				}
//			}
			
			g.DrawImage(stones,0,0);
		}
		
		public int BoardSize
		{
			set
			{
				boardSize = value;
				conversions = new GomokuEngine.Conversions(boardSize);
			}
		}
	}
}