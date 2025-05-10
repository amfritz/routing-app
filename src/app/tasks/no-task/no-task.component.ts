import { HttpClient } from '@angular/common/http';
import { Component, inject, signal } from '@angular/core';

@Component({
  selector: 'app-no-task',
  standalone: true,
  templateUrl: './no-task.component.html',
  styleUrl: './no-task.component.css',
})
export class NoTaskComponent {
  message = signal('');
  http = inject(HttpClient);

  onGetMessage() {
    // this.message.set('No task selected');
    this.http.get('/api/message', { responseType: 'text' })
      .subscribe({
        next: (data) => {
          this.message.set(data);
          console.log('Message fetched:', data);
        },
        error: (err) => {
          console.error('Error fetching message:', err);
          this.message.set('Error fetching message');
        },
        complete: () => {
          console.log('Message fetch complete');
        } 
      });
  }
}
