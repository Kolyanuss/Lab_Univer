package Myconflict;

public class ConflictModify {
    private final String name;
    private boolean isInUse = false;

    public ConflictModify(String name) {
        this.name = name;
    }

    public String getName() {
        return this.name;
    }

    public synchronized void bow(ConflictModify bower) {
        System.out.format(
                "%s: %s" + " пропускає мене!%n",
                this.name,
                bower.getName());
        bower.bowBack(this);
    }

    public synchronized void bowBack(ConflictModify bower) {
        System.out.format(
                "%s: %s" + " пропускає мене у вiдповiдь!%n",
                this.name,
                bower.getName());
    }

    public synchronized void checkIsInUse() {
        while (isInUse) {
            try {
                wait();
            } catch (InterruptedException e) {}
        }
    }

    public synchronized void changeIsInUse(boolean var) {
        isInUse = var;
        notifyAll();
    }
}