import Myconflict.ConflictModify;

public class Main2 {
    public static void main(String[] args) throws InterruptedException {
        ConflictModify conflict_1 = new ConflictModify("conflict_1");
        ConflictModify conflict_2 = new ConflictModify("conflict_2");

        Thread thread1 = new Thread(() -> conflict_1.bow(conflict_2));
        Thread thread2 = new Thread(() -> conflict_2.bow(conflict_1));

        thread1.start();
        thread2.start();
    }
}