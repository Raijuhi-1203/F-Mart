<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demo.aspx.cs" Inherits="demo" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Spin Wheel</title>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: 'Poppins', sans-serif;
        }

        body {
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            background: #333;
        }

        .container {
            position: relative;
            width: 400px;
            height: 400px;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        container.spinBtn {
            position: absolute;
            width: 60px;
            height: 60px;
            background: #fff;
            border-radius: 50%;
            z-index: 10;
            display: flex;
            justify-content: center;
            align-items: center;
            text-transform: uppercase;
            font-weight: 600;
            color: #333;
            letter-spacing: 0.1em;
            border: 4px solid rgba(0,0,0,0.75);
            cursor: pointer;
            user-select: none;
        }

            container.spinBtn::before {
                content: '';
                position: absolute;
                top: -28px;
                width: 20px;
                height: 30px;
                background: #fff;
                clip-path: polygon (50% 0%, 15% 100%, 85% 100%);
            }

        .container.wheel {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: #333;
            border-radius: 50%;
            box-shadow: 0 0 5px #333, 0 0 0 15px #fff, 0 0 0 18px #111;
            transition: transform 5s ease-in-out;
        }

        .container wheel .number {
            position: absolute;
            width: 50%;
            height: 50%;
            background: var(--clr);
            transform-origin: bottom right;
            transform: rotate(calc(45deg var (--i)));
            clip-path: polygon (00, 56% 0, 100% 100%, 0 56%);
            display: flex;
            justify-content: center;
            align-items: center;
            user-select: none;
            cursor: pointer;
        }

        .container.wheel.number span {
            position: relative;
            transform: rotate(45deg);
            font-size: 2em;
            font-weight: 700;
            color: #fff;
            text-shadow: 3px 5px 2px rgba(0,0,0,0.15);
        }

            .container.wheel.number span::after {
                content: '$';
                position: absolute;
                font-size: 8.75em;
                font-weight: 500;
            }
    </style>
</head>
<body>

    <div>
        <div class="spinBtn"></div>
        <div class="wheel">

            <div class="number" style="--i: 1; --clr: #db7093"><span>100</span></div>
            <div class="number" style="--i: 2; --clr: #20b2aa"><span>1</span></div>
            <div class="number" style="--i: 3; --clr: #d63e92"><span>50</span></div>
            <div class="number" style="--i: 4; --clr: #daa520"><span>0</span></div>
            <div class="number" style="--i: 5; --clr: #ff340f"><span>1000</span></div>
            <div class="number" style="--i: 6; --clr: #ff7f50"><span>10</span></div>
            <div class="number" style="--i: 7; --clr: #3cb371"><span>5</span></div>
            <div class="number" style="--i: 8; --clr: #4169e1"><span>20</span></div>

        </div>
    </div>

    <script>

        Let wheel document.querySelector('.wheel');
        Let spinBtn = document.querySelector('.spinBtn');
        Let value Math.ceil(Math.random() * 3600);

        spinBtn.onclick = function () {
            wheel.style.transform = "rotate(" + value + " deg)"
            value += Math.ceil(Math.random() * 3600);
        }
    </script>


</body>
</html>





