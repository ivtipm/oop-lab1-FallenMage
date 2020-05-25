namespace ClassTime
{
    class Time
    {
        sbyte second;
        sbyte minute;
        sbyte hour;

        public sbyte Second
        {
            get => second;
            set { second = (sbyte)((value <= 59 && value >= 0) ? value : 0); }
        }

        public sbyte Minute
        {
            get => minute;
            set { minute = (sbyte)((value <= 59 && value >= 0) ? value : 0); }
        }

        public sbyte Hour
        {
            get => hour;
            set { hour = (sbyte)((value <= 23 && value >= 0) ? value : 0); }
        }


        public Time() { } // Стандартный конструктор
        public Time(sbyte h) : this(h, 0, 0) { } // Конструктор с одним параметром устанавливает часы.
        public Time(sbyte h, sbyte m) : this(h, m, 0) { } // Конструктор с двумя параметрами устанавливает часы и минуты.
        public Time(sbyte h, sbyte m, sbyte s) // Конструктор с тремя параметрами устанавливает часы, минуты и секунды.
        {
            Hour = h;
            Minute = m;
            Second = s;
        }


        public float ToHour() => hour + (minute / 60.0f); // Метод переводящий время в часы

        public float ToMinute() => (hour * 60) + minute + (second / 60.0f); // Метод переводящий время в минуты

        public float ToSecond() => (hour * 3600.0f) + (minute * 60) + second; // Метод переводящий время в секунды

        public override string ToString() => $"[{hour}:{minute}:{second}]"; // Метод возращающий значеник класса Time в форме строки 


        public static Time operator +(Time t1, Time t2) // Метод сложения
        {
            Time Res = new Time();
            Res.hour = (sbyte)(t1.hour + t2.hour);
            Res.minute = (sbyte)(t1.minute + t2.minute);
            Res.second = (sbyte)(t1.second + t2.second);

            if (Res.second > 59)
            {
                Res.second -= 60;
                Res.minute++;
            }
            if (Res.minute > 59)
            {
                Res.minute -= 60;
                Res.hour++;
            }
            Res.hour = (sbyte)((Res.Hour > 23) ? Res.hour - 24 : Res.hour);

            return Res;
        }

        public static Time operator -(Time t1, Time t2) // Метод вычитания
        {
            Time Res = new Time();
            Res.hour = (sbyte)(t1.hour - t2.hour);
            Res.minute = (sbyte)(t1.minute - t2.minute);
            Res.second = (sbyte)(t1.second - t2.second);

            if (Res.second < 0)
            {
                Res.second *= -1;
                Res.minute--;
            }
            if (Res.minute < 0)
            {
                Res.minute *= -1;
                Res.hour--;
            }
            Res.hour = (sbyte)((Res.hour < 0) ? Res.hour * -1 : Res.hour);

            return Res;
        }


        public void Add_H(uint h) // Метод добавления часов
        {
            long AddH = hour + h;

            while (AddH > 23)
                AddH -= 24;

            hour = (sbyte)AddH;
        }

        public void Add_M(uint m) // Метод добавления минут
        {
            long AddM = minute + m;
            uint h = 0;

            while (AddM > 59)
            {
                AddM -= 60;
                h++;
            }
            minute = (sbyte)AddM;
            Add_H(h);
        }

        public void Add_S(uint s) // Метод добавления секунд
        {
            long AddS = second + s;
            uint m = 0;
            while (AddS > 59)
            {
                AddS -= 60;
                m++;
            }

            second = (sbyte)AddS;
            Add_M(m);
        }


        public void Sub_H(uint h) // Метод уменьшения часов
        {
            long SubH = hour - h;
            while (SubH < 0)
                SubH += 24;

            hour = (sbyte)SubH;
        }

        public void Sub_M(uint m) // Метод уменьшения минут
        {
            long SubM = minute - m;
            uint h = 0;

            while (SubM < 0)
            {
                SubM += 60;
                h++;
            }
            minute = (sbyte)SubM;
            Sub_H(h);
        }

        public void Sub_S(uint s) // Метод уменьшения секунд
        {
            long SubS = second - s;
            uint m = 0;

            while (SubS < 0)
            {
                SubS += 60;
                m++;
            }
            second = (sbyte)SubS;
            Sub_M(m);
        }
    }
}
