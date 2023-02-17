package com.example.diceroller

import android.os.Bundle
import android.widget.Button
import android.widget.ImageView
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity

class MainActivity : AppCompatActivity() {
    private val dice = Dice(6)
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val rollButton: Button = findViewById(R.id.button)
        rollButton.setOnClickListener {rollDice()}
    }
    private fun rollDice() {
        val num1: Int = dice.roll()
        val num2: Int = dice.roll()
        // change 2 text View
        var resultTextView: TextView = findViewById(R.id.textView)
        resultTextView.text = num1.toString()
        resultTextView = findViewById(R.id.textView2)
        resultTextView.text = num2.toString()

        // change first image View
        var diceImage: ImageView = findViewById<ImageView>(R.id.imageView)
        var drawableResource = when (num1) {
            1 -> R.drawable.dice_1
            2 -> R.drawable.dice_2
            3 -> R.drawable.dice_3
            4 -> R.drawable.dice_4
            5 -> R.drawable.dice_5
            else -> R.drawable.dice_6
        }
        diceImage.setImageResource(drawableResource)
        diceImage.contentDescription = num1.toString()

        // change second image View
        diceImage = findViewById(R.id.imageView2)
        drawableResource = when (num2) {
            1 -> R.drawable.dice_1
            2 -> R.drawable.dice_2
            3 -> R.drawable.dice_3
            4 -> R.drawable.dice_4
            5 -> R.drawable.dice_5
            else -> R.drawable.dice_6
        }
        diceImage.setImageResource(drawableResource)
        diceImage.contentDescription = num2.toString()
    }
}

class Dice(private val numSides: Int) {
    fun roll(): Int {
        return (1..numSides).random()
    }
}