clear;
clc;
mode(0)

function y=calcFuel(m)
    y=floor(m/3)-2
endfunction

// Part 1
printf("Part 1\n********\n")
mm=read("input.txt",-1,1);
printf("Fuel for each module")
f=floor(mm/3)-2;
f
printf("Total fuel:")
t=sum(f,1)
t

// Part 2
printf("Part 2\n********\n")
printf("Fuel for fuel for each module")

f2 = zeros(length(mm),1);
for i = 1:length(mm)
    tmp = 0;
    tfuel = calcFuel(mm(i));
    while(tfuel > 0)
        tmp = tmp + tfuel;
        tfuel = calcFuel(tfuel);
    end
    f2(i) = tmp;
end
f2
printf("Total fuel of fuel:")
t2=sum(f2,1);
t2


//4973628
//1655960

